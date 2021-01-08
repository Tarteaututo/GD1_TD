using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectProjectile : AProjectile
{
    [SerializeField]
    private Projectile projectile = null;

    protected override void OnDamageableFound(Damageable damageable)
    {
        base.OnDamageableFound(damageable);

        // Get the hit normal
        //public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo) == true)
        {
            //hitInfo.
        }

        // Get the source vector and hit normal
        //Vector3.Dot(

        Projectile instance = Instantiate<Projectile>(projectile);
    }
}
