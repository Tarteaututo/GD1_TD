using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AProjectile
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Debug.Log("Projectile.OnCollisionEnter");
    }

    protected override void Move()
    {
        // Base pointe vers AProjectile
        base.Move();
    }
}
