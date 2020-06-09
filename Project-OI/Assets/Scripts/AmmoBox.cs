using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour,IInteractable
{
    [SerializeField] Animator boxAnimator;
    [SerializeField] BoxCollider ammoBoxCollider;
    [SerializeField] int ammoCount;
    [SerializeField] WeaponType ammoType;
    [SerializeField] string animationTrigger;
  

    public void OpenBox()
    {
        boxAnimator.SetTrigger(animationTrigger);
        ammoBoxCollider.enabled = false;
    }

    public WeaponType GetAmmoType()
    {
        return ammoType;
    }

    public int GetAmmo()
    {
        Destroy(this.gameObject,2f);
        return ammoCount;
    }
}
