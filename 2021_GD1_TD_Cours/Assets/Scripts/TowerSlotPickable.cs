using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlotPickable : Pickable
{
    [SerializeField]
    private Tower _towerPrefab = null;

    [SerializeField]
    private Transform _instanceOffset = null;

    private Tower _towerInstance = null;

    public override void Pick(RaycastHit hit)
    {
        Debug.LogFormat("{0}.Pick() {1} is been picked.", GetType().Name, gameObject.name);


        // Si je n'ai pas de tour
        if (_towerInstance == null)
        {
            // créer une tour et s'en rappeler
            _towerInstance = Instantiate(_towerPrefab);
            _towerInstance.transform.position = _instanceOffset.position;
        }
        else
        {
            // Sinon
            // Détruire la tour

        }
    }
}
