using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : AWeapon
{
    [SerializeField]
    private Transform _projectileOffset = null;

    [SerializeField]
    private float _fireRate = 0.3f;

    [SerializeField]
    private int _maxShotCount = 3;

    //[System.NonSerialized]
    private int _currentShotCount = 0;

    // timer
    private Timer _timer = null;

    protected override void Awake()
    {
        base.Awake();
        _timer = new Timer(_fireRate);
        Debug.Log("Rifle.Awake()");
    }

    public override void Fire()
    {
        // Déclencher le start du tir
        // Start timer
        _timer.Start();
    }

    private void Update()
    {
        // Utiliser un timer pour attendre selon le fire rate
        if (_timer.Update() == true)
        {
            Projectile instance = Instantiate<Projectile>(projectile);
            instance.transform.position = _projectileOffset.position;
            instance.transform.rotation = _projectileOffset.rotation;
        }
    }
}
