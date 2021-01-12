using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoguidedProjectile : AProjectile
{
    private Transform _currentTarget = null;

    public void SetTarget(Transform target)
    {
        _currentTarget = target;
    }

    protected override void Move()
    {
        // Trouver la direction vers la target et s'y orienter
        Vector3 direction = _currentTarget.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        // On appelle la methode de base Move ( == se déplacer tout droit devant soi)
        base.Move();
    }
}
