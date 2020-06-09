using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour,IInteractable
{
    [SerializeField] Animator boxAnimator;
    [SerializeField] int pistolAmmo;
    [SerializeField] string animationTrigger;

    public int OpenBox()
    {
        boxAnimator.SetTrigger(animationTrigger);
        return GetAmmo();
    }

    private int GetAmmo()
    {
        return pistolAmmo;
    }
}
