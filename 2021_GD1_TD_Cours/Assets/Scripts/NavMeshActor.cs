using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshActor : MonoBehaviour
{
    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private NavMeshAgent _agent = null;

    [SerializeField]
    private LayerMask _layerMask = 0;

    [SerializeField]
    private WeaponController _weaponController = null;

    [SerializeField]
    private KeyCode _fire = KeyCode.Space;

    [SerializeField]
    private KeyCode _switch = KeyCode.E;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, _layerMask) == true)
            {
                _agent.SetDestination(hit.point);
            }
            // Déplacer mon agent à la position cliquée
        }

        if (Input.GetKeyDown(_switch) == true)
        {
            _weaponController.Switch();
        }

        if (Input.GetKeyDown(_fire) == true)
        {
            _weaponController.Fire();
        }
    }

}
