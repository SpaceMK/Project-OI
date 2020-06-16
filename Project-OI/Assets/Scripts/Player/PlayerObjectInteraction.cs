using System;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    [SerializeField] ShootBehaviour playerShootBehavior;
    [SerializeField] PlayerInventory playerInventory;
    IInteractable interactiveObject;
   
    public Action<IInteractable> CollisionInteraction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerShootBehavior.pickButton)&& interactiveObject!=null)
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        switch (interactiveObject)
        {
            case InteractiveWeapon weapon:
                PickUpWeapon(weapon);
            break;
            case AmmoBox box:
                OpenAmmoBox(box);
            break;
            case MissionObjective objective:
                PickUpMissionObjective(objective);
            break;
            case RadioSet radio:
                UserRadio(radio);
            break;
        }
    }


    void UserRadio(RadioSet radioSet)
    {
        radioSet.UseRadio(playerInventory.GetObjectiveTags());
        CollisionInteraction?.Invoke(null);
    }

    void PickUpMissionObjective(MissionObjective objective)
    {
        playerInventory.AddObjectibeTags(objective.GetTag());
        objective.DestroyObject();
        CollisionInteraction?.Invoke(null);
    }

    void OpenAmmoBox(AmmoBox ammoBox)
    {
        ammoBox.OpenBox();
        playerInventory.AddAmmoFromBox(ammoBox);
        CollisionInteraction?.Invoke(null);
    }

    void PickUpWeapon(InteractiveWeapon weapon)
    {
        if (weapon.Pickable)
            weapon.PickUpWeapon(playerShootBehavior);
        ServiceLocator.Current.Get<AudioInput>().PlayAudio(AudioActionType.PickUpWeapon);
        CollisionInteraction?.Invoke(null);
    }

    void OnTriggerEnter(Collider collider)
    {
        interactiveObject = collider.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
        CollisionInteraction?.Invoke(interactiveObject);
    }

    void OnTriggerExit(Collider collider)
    {
        interactiveObject = null;
        CollisionInteraction?.Invoke(null);
    }
}
