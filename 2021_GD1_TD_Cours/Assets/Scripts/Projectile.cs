using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            damageable.DoDamage(_damage);
            Destroy(this.gameObject);
        }
    }
}
