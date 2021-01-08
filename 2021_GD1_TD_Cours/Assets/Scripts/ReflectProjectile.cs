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
            // On trouve la nouvelle direction à partir du forward du projectile, par rapport à la normale du plan hit
            Vector3 newDirection = Vector3.Reflect(transform.forward, hitInfo.normal);

            AProjectile instance = Instantiate(projectile);
            instance.transform.position = transform.position;
            instance.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
