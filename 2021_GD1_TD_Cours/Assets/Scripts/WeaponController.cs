using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private AWeapon _weapon = null;

    // Command
    public void Fire()
    {
        _weapon.Fire();
    }

    //public void Switch()
    //{
    //}
}
