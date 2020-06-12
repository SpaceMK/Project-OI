using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int pistolAmmo,rifleAmmo;
    WeaponAmmo currentUsedWeapon;
    public int GetCurrentAmmo(WeaponAmmo weaponType)
    {
        int ammo = weaponType == WeaponAmmo.Pistol ? pistolAmmo : rifleAmmo;
        return ammo;
    }

    public void RemoveAmmoFromInventory(WeaponAmmo weaponType)
    {
        if (weaponType == WeaponAmmo.Pistol)
            pistolAmmo--;
        else
            rifleAmmo--;
    }

    public void AddAmmoToInventory(WeaponAmmo weaponType,int ammo)
    {
        currentUsedWeapon = weaponType;
        if (weaponType == WeaponAmmo.Pistol)
            pistolAmmo += ammo;
        else
            rifleAmmo += ammo;
    }

    public void AddAmmoFromBox(AmmoBox ammoBox)
    { 
        int addToAmmo = ammoBox.GetAmmo();
        if (ammoBox.GetAmmoType() == WeaponAmmo.Pistol)
            pistolAmmo += addToAmmo;
        else
            rifleAmmo += addToAmmo;
    }

    public int GetPistolAmmo()
    {
        return pistolAmmo;
    }

    public int GetRifleAmmo()
    {
        return rifleAmmo;
    }

}


