using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // vérifier si le collider est un damageable
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            damageable.DoDamage(1);
        }

        // si oui
        // damageable.DoDamage()
        // Destroy itself
    }
}
