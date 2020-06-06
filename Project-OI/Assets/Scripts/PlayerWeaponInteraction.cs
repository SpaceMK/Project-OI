using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInteraction : MonoBehaviour
{
    [SerializeField] ShootBehaviour playerShootBehavior;
    InteractiveWeapon interactiveWeapon;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(playerShootBehavior.pickButton) && interactiveWeapon != null && interactiveWeapon.Pickable)
            interactiveWeapon.PickUpWeapon(playerShootBehavior);
    }

    void OnTriggerEnter(Collider collider)
    {
        var weapon = collider.gameObject.GetComponent<InteractiveWeapon>();
        if (weapon != null)
            interactiveWeapon = weapon; 
    }
}
