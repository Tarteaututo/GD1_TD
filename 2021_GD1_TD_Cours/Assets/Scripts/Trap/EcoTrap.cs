using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoTrap : ATrap
{
    [SerializeField]
    private int _amountOfStolenMoney = 1;

    protected override void OnActorTrapped(Actor actor)
    {
        LevelReferences.Instance.EconomyManager.TryAddOrRemoveMoney(_amountOfStolenMoney);
    }
}
