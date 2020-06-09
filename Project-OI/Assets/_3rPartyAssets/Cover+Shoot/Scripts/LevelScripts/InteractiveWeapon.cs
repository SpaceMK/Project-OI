using UnityEngine;
using UnityEngine.UI;

// This class corresponds to any in-game weapon interactions.
public class InteractiveWeapon : MonoBehaviour, IInteractable
{
	public string WeaponID;
    public bool Pickable { private set; get; }
    public AudioClip ShotSound, ReloadSound,PickSound,DropSound;
    public Transform Muzzle;
    public Vector3 RightHandPositionAim;
    public Vector3 RightHandPositionHold;  // Position offsets relative to the player's right hand.
    public Vector3 RelativeRotationAim;
    public Vector3 RelativeRotationHold; 
    public float BulletDamage = 10f;                          // Damage of one shot.    
	public float RecoilAngle;                                 // Angle of weapon recoil.
    public WeaponType weaponType = WeaponType.Pistol;
	public AimType Type = AimType.SHORT;                 // Default weapon type, change in Inspector.
	public WeaponMode Mode = WeaponMode.SEMI;                 // Default weapon mode, change in Inspector.
    public int BurstSize = 0;                                 // How many shot are fired on burst mode.

	[SerializeField] int mag;                                 // Current mag capacity and total amount of bullets being carried.
	[SerializeField] SphereCollider interactiveRadius;                 // In-game radius of interaction with player.
	[SerializeField] BoxCollider col;                                  // Weapon collider.
	[SerializeField] Rigidbody rbody;                                  // Weapon rigidbody.

  
    private int fullMag, currentInventoryAmmoCount;                          // Default mag capacity and total bullets for reset purposes.
    private ShootBehaviour playerShootBehavior;                   // Player's inventory to store weapons.

    void Awake()
	{
		fullMag = mag;
        Pickable = true;
	}

    public void PickUpWeapon(ShootBehaviour shootBehaviour)
    {
        playerShootBehavior = shootBehaviour;
        rbody.isKinematic = true;
        this.col.enabled = false;
        playerShootBehavior.AddWeapon(this);
        interactiveRadius.enabled=false;
        this.Pickable = false;
        currentInventoryAmmoCount = playerShootBehavior.GetInventory().GetCurrentAmmo(weaponType);
    }


	public void Drop()
	{
		this.gameObject.SetActive(true);
		this.transform.position += Vector3.up;
		rbody.isKinematic = false;
		this.transform.parent = null;
		this.col.enabled = true;
        interactiveRadius.enabled = true;
        this.Pickable = true;
        playerShootBehavior = null;
	}

	public bool StartReload()
	{
        currentInventoryAmmoCount = playerShootBehavior.GetInventory().GetCurrentAmmo(weaponType);
        if (mag == fullMag || currentInventoryAmmoCount == 0)
			return false;
		else if(currentInventoryAmmoCount < fullMag - mag)
		{
			mag += currentInventoryAmmoCount;
			currentInventoryAmmoCount = 0; 
		}
		else
		{
			currentInventoryAmmoCount -= fullMag - mag;
			mag = fullMag;
		}

		return true;
	}
	public void EndReload()
	{

	}

	
	public bool Shoot()
	{
		if (mag > 0)
		{
            mag--;
            playerShootBehavior.GetInventory().RemoveAmmoFromInventory(weaponType);
            return true;
		}
		return false;
	}

	public void ResetBullets()
	{
        mag = fullMag;
	}
}


[System.Serializable]
public enum AimType                                    
{
    NONE,
    SHORT,
    LONG
}

[System.Serializable]
public enum WeaponMode      
{
    SEMI,
    BURST,
    AUTO
}

[System.Serializable]
public enum WeaponType
{
    Pistol,
    Rifle
}

