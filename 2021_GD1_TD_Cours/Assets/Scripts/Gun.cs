using UnityEngine;

public class Gun : AWeapon
{
    [SerializeField]
    private Transform _projectileOffset = null;

    public override void Fire()
    {
        AProjectile instance = Instantiate<AProjectile>(projectile);
        instance.transform.position = _projectileOffset.position;
        instance.transform.rotation = _projectileOffset.rotation;
    }
}
