using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAdder : MonoBehaviour
{
    public enum EventType
    {
        Awake = 0,
        OnEnable,
        OnDisable,
        OnDestroy
    }

    [SerializeField]
    private EventType _eventType = 0;

    [SerializeField]
    private int _amount = 0;

    private void Awake()
    {
        if (_eventType == EventType.Awake)
        {
            DoAdd();
        }
    }

    private void OnEnable()
    {
        if (_eventType == EventType.OnEnable)
        {
            DoAdd();
        }
    }

    private void OnDisable()
    {
        if (_eventType == EventType.OnDisable)
        {
            DoAdd();
        }
    }

    private void OnDestroy()
    {
        if (LevelReferences.HasInstance == true &&
            _eventType == EventType.OnDestroy)
        {
            DoAdd();
        }
    }

    private void DoAdd()
    {
        LevelReferences.Instance.EconomyManager.TryAddOrRemoveMoney(_amount);
    }
}
