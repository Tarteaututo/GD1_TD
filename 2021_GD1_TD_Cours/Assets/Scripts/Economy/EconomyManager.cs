using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private EconomyUI _economyUI = null;

    [SerializeField]
    private int _startingMoney = 10;

    [System.NonSerialized]
    private int _money = 0;
    #endregion Fields

    #region Properties
    public int Money
    {
        //get => _money;
        get
        {
            return _money;
        }
        private set
        {
            _money = value;
            _economyUI.SetAmount(_money);
        }
    }
    #endregion Properties

    #region Methods
    public bool CanBuy(int cost)
    {
        return Money >= Mathf.Abs(cost);
    }

    public bool TryAddOrRemoveMoney(int amount)
    {
        if (amount > 0 || (amount < 0 && CanBuy(amount)) == true)
        {
            Money += amount;
            Debug.LogFormat("TryAddOrRemoveMoney : true (adding {1}, lasting {0})", _money, amount);
            return true;
        }
        Debug.LogFormat("TryAddOrRemoveMoney : false (adding {1} FAIL, lasting {0})", _money, amount);
        return false;
    }

    private void OnEnable()
    {
        Money = _startingMoney;
    }
    #endregion Methods

}
