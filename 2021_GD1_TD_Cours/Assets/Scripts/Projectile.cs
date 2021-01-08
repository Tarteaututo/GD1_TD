using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AProjectile
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Debug.Log("Projectile.OnTriggerEnter");
    }

    protected override void Move()
    {
        // Base pointe vers AProjectile
        base.Move();
    }
}
