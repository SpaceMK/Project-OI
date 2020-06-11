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
            case InteractiveWeapon weapon:
                uiInstruction.DisplayText(InteractionType.Weapon, weapon.WeaponID);
                break;
            case AmmoBox box:
                uiInstruction.DisplayText(InteractionType.AmmoBox, null);
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
