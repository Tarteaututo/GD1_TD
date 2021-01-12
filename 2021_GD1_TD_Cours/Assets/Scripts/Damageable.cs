using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _health = 2;

    [SerializeField]
    private Transform _offset = null;

    private int _currentHealth = 0;

    // Properties : 
    public Transform Offset
    {
        get
        {
            return _offset;
        }
        // Si je voulais permettre la modification
        //set
        //{
        //    _offset = value;
        //}
    }

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void DoDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
