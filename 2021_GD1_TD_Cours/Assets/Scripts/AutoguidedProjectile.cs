using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoguidedProjectile : AProjectile
{
    private Damageable _currentTarget = null;

    public void SetTarget(Damageable target)
    {
        _currentTarget = target;
    }

    protected override void Move()
    {
        //if (_currentTarget) -> est ce que l'objet unity c# et c++ sont tous les deux existants (not null, not "null")
        //if (!_currentTarget) -> inverse d'au dessus
        if (_currentTarget == null)
        {
            Destroy(this.gameObject);
            return;
        }

        // Trouver la direction vers la target et s'y orienter
        Vector3 direction = _currentTarget.Offset.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        // On appelle la methode de base Move ( == se déplacer tout droit devant soi)
        base.Move();
    }
}
