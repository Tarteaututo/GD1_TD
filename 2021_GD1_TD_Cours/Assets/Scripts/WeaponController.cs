using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Projectile _projectile = null;

    [SerializeField]
    private Transform _projectileOffset = null;

    public void Fire()
    {
        Projectile instance = Instantiate<Projectile>(_projectile);
        instance.transform.position = _projectileOffset.position;
        instance.transform.rotation = _projectileOffset.rotation;
    }

    //public void Switch()
    //{
    //}
}
