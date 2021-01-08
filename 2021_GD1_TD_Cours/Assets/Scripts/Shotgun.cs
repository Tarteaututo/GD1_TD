using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : AWeapon
{
    public enum ShotgunType
    {
        Random,
        SphereRandom
    }

    [SerializeField]
    private ShotgunType _type = ShotgunType.Random;

    [SerializeField]
    private Transform _projectileOffset = null;

    // int qui donne le compte maximum de projectile
    [SerializeField]
    private int _maxShotCount = 6;

    [SerializeField]
    private float _spread = 1f;

    public override void Fire()
    {
        switch (_type)
        {
            case ShotgunType.Random:
                {
                    for (int i = 0; i < _maxShotCount; i++)
                    {
                        //float randomX = Random.Range(-15, 15);
                        //float randomY = Random.Range(-15, 15);
                        //Quaternion randomSpread = Quaternion.Euler(randomX, randomY, 0);
                        Quaternion randomSpread = Quaternion.Euler(Random.Range(-15, 15), Random.Range(-15, 15), 0);

                        Projectile instance = Instantiate<Projectile>(projectile);
                        instance.transform.position = _projectileOffset.position;
                        instance.transform.rotation = _projectileOffset.rotation * randomSpread;
                    }
                }
                break;
            case ShotgunType.SphereRandom:
                {
                    for (int i = 0; i < _maxShotCount; i++)
                    {
                        Projectile instance = Instantiate<Projectile>(projectile);
                        instance.transform.position = _projectileOffset.position + Random.insideUnitSphere * _spread;
                        instance.transform.rotation = _projectileOffset.rotation;
                    }
                }
                break;
            default:
                break;
        }
    }
}
