using ServiceLocatorSample.ServiceLocator;
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
                string tag = box.GetAmmoType().ToString().ToLower();
                uiInstruction.DisplayText(InteractionType.AmmoBox,tag);
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
