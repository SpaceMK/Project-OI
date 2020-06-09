using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string animationTrigger;
    [SerializeField] InteractiveWeapon weapon;
    void Start()
    {
        weapon.WeaponShoot += AnimateWeapon;
    }

    void AnimateWeapon()
    {
        animator.SetTrigger(animationTrigger);
    }
}
