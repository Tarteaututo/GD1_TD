using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSlotPickableWithMenu : Pickable
{
    [SerializeField]
    private TowerSelectionMenu _towerSelectionMenu = null;

    [SerializeField]
    private Tower[] _towerPrefabs = null;

    [SerializeField]
    private Transform _instanceOffset = null;

    private Tower _towerInstance = null;

    private void Awake()
    {
        _towerSelectionMenu.Initialize(_towerPrefabs, _instanceOffset.position);
        _towerSelectionMenu.Hide();
    }

    public override void Pick(RaycastHit hit)
    {
        _towerSelectionMenu.Show();
    }
}
