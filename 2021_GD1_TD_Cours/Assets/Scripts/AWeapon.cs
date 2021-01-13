﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    // protected : accessible uniquement par les classes qui héritent de AWeapon
    [SerializeField]
    protected AProjectile projectile = null;

    public abstract void Fire();

    public virtual void Enable()
    {
        Debug.Log("AWeapon.Enable()");
    }

    protected virtual void Awake()
    {
        Debug.Log("AWeapon.Awake()");
    }
}