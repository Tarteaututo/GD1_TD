using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private HealthBar _healthBar = null;

    [SerializeField]
    private int _health = 2;

    [SerializeField]
    private Transform _offset = null;

    // HACK : new values
    [SerializeField]
    private bool _destroyIfHealthBelowZero = true;

    private int _currentHealth = 0;
    #endregion Fields

    #region Properties
    public bool IsAlive
    {
        get
        {
            return _currentHealth > 0;
        }
    }

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
    #endregion Properties

    #region Events
    public delegate void DamageableEvent(Damageable sender, int previousHealth, int currentHealth, int maxHealth);
    public event DamageableEvent HealthChanged = null;
    #endregion Events

    #region Methods
    private void Awake()
    {
        _currentHealth = _health;
        HealthChanged = null;
    }

    public void DoDamage(int damage)
    {
        int previousHealth = _currentHealth;
        _currentHealth -= damage;

        //if (HealthChanged != null)
        //{
        //}

        _healthBar.UpdateHealthBar(_currentHealth, _health);

        HealthChanged?.Invoke(this, previousHealth, _currentHealth, _health);

        // Quand la vie arrive à 0 : détruit l'actor
        if (_destroyIfHealthBelowZero == true && 
            _currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Methods
}