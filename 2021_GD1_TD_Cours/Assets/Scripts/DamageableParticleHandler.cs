using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quand il se passe un truc dans un damageable (health réduite ou perte de vie)
// On fait des trucs
public class DamageableParticleHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _killParticle = null;

    [SerializeField]
    private Damageable _damageable = null;

    private void OnEnable()
    {
        _damageable.HealthChanged -= OnHealthChanged;
        _damageable.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _damageable.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(Damageable sender, int previousHealth, int currentHealth, int maxHealth)
    {
        Debug.LogFormat(
            "{0} : {1} [previousHealth:{2}] [currentHealth:{3}] [maxHealth:{4}]", 
            GetType().Name, 
            sender.GetType().Name, 
            previousHealth, 
            currentHealth, 
            maxHealth
        );
    }
}
