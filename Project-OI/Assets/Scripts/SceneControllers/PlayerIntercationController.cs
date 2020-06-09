using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntercationController : MonoBehaviour
{
    [SerializeField] PlayerObjectInteraction weaponInteraction;
    [SerializeField] UIInteractionInstruction uiInstruction;

    void Start()
    {
        weaponInteraction.CollisionInteraction += PlayerInteracted;        
    }


    private void PlayerInteracted(IInteractable interactable)
    {
        switch (interactable)
        {
            case (null):
                uiInstruction.DisplayText(InteractionType.None,"");
            break;
            case InteractiveWeapon i:
                var weapon = (InteractiveWeapon)interactable;
                uiInstruction.DisplayText(InteractionType.Weapon, weapon.WeaponID);
                break;
        }
        
    }
}


public enum InteractionType
{
    Weapon,
    AmmoBox, 
    None
}
