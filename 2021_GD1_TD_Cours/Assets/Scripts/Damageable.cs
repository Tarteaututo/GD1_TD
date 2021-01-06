using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _health = 2;

    private int _currentHealth = 0;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void DoDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
