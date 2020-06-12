using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int pistolAmmo,rifleAmmo;
    WeaponType currentUsedWeapon;
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

    public void AddAmmoToInventory(WeaponType weaponType,int ammo)
    {
        currentUsedWeapon = weaponType;
        if (weaponType == WeaponType.Pistol)
            pistolAmmo += ammo;
        else
            rifleAmmo += ammo;
    }

    public void AddAmmoFromBox(AmmoBox ammoBox)
    { 
        int addToAmmo = ammoBox.GetAmmo();
        if (ammoBox.GetAmmoType() == WeaponType.Pistol)
            pistolAmmo += addToAmmo;
        else
            rifleAmmo += addToAmmo;
    }


    public int ReturAmmo()
    {
        int currentUsedAmmo = currentUsedWeapon == WeaponType.Pistol ? pistolAmmo : rifleAmmo;
        return currentUsedAmmo;
    }

}


