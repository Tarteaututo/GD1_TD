using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _speed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            damageable.DoDamage(_damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        // On se déplace de 1m en direction du forward de l'actor
        transform.position = transform.position + (transform.forward * _speed * Time.deltaTime);
    }
}
