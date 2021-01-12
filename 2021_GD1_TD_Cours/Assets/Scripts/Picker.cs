using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private Transform _somePrefab = null;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private int _raycastMaxDistance = 100;

    // Input : click souris
    // raycast de la camera dans la position de la souris sur l'écran (2D) -> world (3D)
    // Construire une tour

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            Debug.Log("Mouse up");
            // lancer le raycast
            //public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, _raycastMaxDistance, _layerMask.value) == true)
            {

                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.blue, 2f, false);

                Transform instance = Instantiate(_somePrefab);
                instance.transform.position = hit.point;
            }
        }
    }
}
