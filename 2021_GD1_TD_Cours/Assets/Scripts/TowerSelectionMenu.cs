using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerSelectionMenu : AMenu
{
    [SerializeField]
    private UITower _uiTowerPrefab = null;

    private List<UITower> _currentTowers = null;

    public void Initialize(Tower[] towerPrefab, Vector3 instanceOffset)
    {
        _currentTowers = new List<UITower>(towerPrefab.Length);
        for (int i = 0, length = towerPrefab.Length; i < length; i++)
        {
            UITower instance = Instantiate(_uiTowerPrefab, transform);
            instance.transform.position = transform.position;
            instance.Initialize(towerPrefab[i], instanceOffset);
            instance.ButtonClicked += OnButtonClicked;
            _currentTowers.Add(instance);
        }
    }

    private void OnButtonClicked(UITower sender, Tower towerInstance)
    {
        Hide();
        if (towerInstance != null)
        {
            //TODO AL : nothing to do ?
        }
    }
}
