using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    [SerializeField] ShootBehaviour playerShootBehavior;
   IInteractable interactiveObject;

    public Action<IInteractable> CollisionInteraction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(playerShootBehavior.pickButton)&& interactiveObject!=null)
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        switch (interactiveObject)
        {
            case InteractiveWeapon i:
                PickUpWeapon(i);
            break;
        }
    }


    void PickUpWeapon(InteractiveWeapon weapon)
    {
        if (weapon.Pickable)
            weapon.PickUpWeapon(playerShootBehavior);
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
