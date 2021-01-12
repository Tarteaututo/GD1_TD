using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private Transform _headTransform = null;

    [SerializeField]
    private Transform _canonTransform = null;

    [SerializeField]
    private Transform _muzzle = null;

    [SerializeField]
    private float _fireRate = 0.5f;

    [SerializeField]
    private AProjectile _projectile = null;

    private Damageable _currentTarget = null;

    private Timer _timer = null;

    private void Awake()
    {
        _timer = new Timer(_fireRate);
    }

    private void OnTriggerEnter(Collider other)
    {
        // On retient le dernier damageable qui entre dans la zone
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            _currentTarget = damageable;
            _timer.Start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // On oublie le damageable "_currentTarget" qui sort dans la zone
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable == _currentTarget)
        {
            _currentTarget = null;
            _timer.Stop();
        }
    }

    private void Update()
    {
        if (_currentTarget != null)
        {
            RotateHeadTo(_currentTarget.transform);
            RotateCanonTo(_currentTarget.transform);

            if (_timer.Update() == true)
            {
                Fire();
            }
        }
    }

    private void RotateHeadTo(Transform target)
    {
        Vector3 direction = target.position - _headTransform.position;
        direction.y = 0;
        _headTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void RotateCanonTo(Transform target)
    {
        Vector3 direction = target.position - _canonTransform.position;
        _canonTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void Fire()
    {
        AProjectile instance = Instantiate<AProjectile>(_projectile);
        instance.transform.position = _muzzle.position;
        instance.transform.rotation = _muzzle.rotation;

        if (instance is AutoguidedProjectile autoguidedProjectile)
        {
            autoguidedProjectile.SetTarget(_currentTarget.transform);
        }
    }

    private void CastExplanation()
    {
        AProjectile instance = null;
        // Lance une erreur si faux
        AutoguidedProjectile autoguidedProjectile = (AutoguidedProjectile)instance;

        // set autoguidedProjectile2 à null si faux
        AutoguidedProjectile autoguidedProjectile2 = instance as AutoguidedProjectile;

        if (instance is AutoguidedProjectile)
        {
            // alors
            (instance as AutoguidedProjectile).SetTarget(null);
        }

        if (instance is AutoguidedProjectile autoguidedProjectile3)
        {
            autoguidedProjectile3.SetTarget(null);
            // alors
        }

    }
}
