using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private AWeapon _weapon = null;

    [SerializeField]
    private AWeapon _alternativeWeapon = null;

    private AWeapon _selectedWeapon = null;

    private void Awake()
    {
        _selectedWeapon = _weapon;
    }

    // Command
    public void Fire()
    {
        _selectedWeapon.Fire();
    }

    public void Switch()
    {
        if (_weapon == _selectedWeapon)
        {
            _selectedWeapon = _alternativeWeapon;
        }
        else
        {
            _selectedWeapon = _weapon;
        }
        _selectedWeapon.Enable();
    }
}
