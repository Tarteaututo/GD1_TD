using UnityEngine;

public class Gun : AWeapon
{
    [SerializeField]
    private Transform _projectileOffset = null;

    public override void Fire()
    {
        Projectile instance = Instantiate<Projectile>(projectile);
        instance.transform.position = _projectileOffset.position;
        instance.transform.rotation = _projectileOffset.rotation;
    }
}
