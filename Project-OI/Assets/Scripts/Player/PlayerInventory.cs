using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int pistolAmmo,rifleAmmo;

    public int GetCurrentAmmo(WeaponType weaponType)
    {
        int ammo = weaponType == WeaponType.Pistol ? pistolAmmo : rifleAmmo;
        return ammo;
    }

    public void RemoveAmmoFromInventory(WeaponType weaponType)
    {
        if (weaponType == WeaponType.Pistol)
            pistolAmmo--;
        else
            rifleAmmo--;
    }


    public void AddAmmo(AmmoBox ammoBox)
    { 
        int addToAmmo = ammoBox.GetAmmo();
        if (ammoBox.GetAmmoType() == WeaponType.Pistol)
            pistolAmmo += addToAmmo;
        else
            rifleAmmo += addToAmmo;
    }
}


