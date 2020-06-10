using DG.Tweening;
using UnityEngine;

public class WeaponsAnimationController : MonoBehaviour
{
    [SerializeField] InteractiveWeapon weapon;
    [SerializeField] Transform gunSlide;
    [SerializeField] Vector3 backPosition;
    [SerializeField] [Range(0f, 1f)] float animationTime;
    Vector3 startingPosition = new Vector3();
    
    void Start()
    {
        weapon.WeaponAnimation += AnimateWeaponSlide;
        startingPosition = gunSlide.localPosition;
    }

    void Update()
    {
       
    }

    void AnimateWeaponSlide(int ammo)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(gunSlide.DOLocalMoveZ(backPosition.z, animationTime, false));
        if(ammo>0)
            mySequence.Append(gunSlide.DOLocalMoveZ(startingPosition.z, animationTime, false));
    }


    void LockSlideAnimation()
    {
        gunSlide.DOLocalMoveZ(backPosition.z, animationTime, false);
    }
}
