using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _speed = 1f;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.transform.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            OnDamageableFound(damageable);
        }
        Debug.Log("AProjectile.OnCollisionEnter");
    }

    protected virtual void Update()
    {
        // On se déplace de 1m en direction du forward de l'actor
        Move();
    }

    protected virtual void Move()
    {
        transform.position = transform.position + (transform.forward * _speed * Time.deltaTime);
    }

    protected virtual void OnDamageableFound(Damageable damageable)
    {
        damageable.DoDamage(_damage);
        Destroy(this.gameObject);
    }
}
