using UnityEngine;

public class CheckInventory : MonoBehaviour
{
    [SerializeField] PlayerfunctionalityInput playerfunctionality;
    [SerializeField] UIInventory uiInventory;
    void Start()
    {
        playerfunctionality.CheckInventory += CheckPlayerInventory;
    }

   void CheckPlayerInventory(PlayerInventory inventory)
   {
        string message = "Pistol ammo : " + inventory.GetPistolAmmo().ToString() + "\n" + "Rifle ammo : "+ inventory.GetRifleAmmo().ToString();
        uiInventory.DisplayInventoryStatus(message);
   }
}
