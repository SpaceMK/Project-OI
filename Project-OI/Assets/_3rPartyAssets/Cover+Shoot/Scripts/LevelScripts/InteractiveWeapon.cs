using UnityEngine;
using UnityEngine.UI;

// This class corresponds to any in-game weapon interactions.
public class InteractiveWeapon : MonoBehaviour
{
	public string WeaponID;
    public bool Pickable { private set; get; }
    public AudioClip ShotSound, ReloadSound,PickSound,DropSound;
    public Transform Muzzle;
    public Vector3 RightHandPosition;                         // Position offsets relative to the player's right hand.
	public Vector3 RelativeRotation;                          // Rotation Offsets relative to the player's right hand.
    public float BulletDamage = 10f;                          // Damage of one shot.    
	public float RecoilAngle;                                 // Angle of weapon recoil.
	public WeaponType Type = WeaponType.NONE;                 // Default weapon type, change in Inspector.
	public WeaponMode Mode = WeaponMode.SEMI;                 // Default weapon mode, change in Inspector.
    public int BurstSize = 0;                                 // How many shot are fired on burst mode.

	[SerializeField] int mag;                                 // Current mag capacity and total amount of bullets being carried.
	[SerializeField] SphereCollider interactiveRadius;                 // In-game radius of interaction with player.
	[SerializeField] BoxCollider col;                                  // Weapon collider.
	[SerializeField] Rigidbody rbody;                                  // Weapon rigidbody.

  
    private int fullMag, maxBullets;                          // Default mag capacity and total bullets for reset purposes.
    private ShootBehaviour playerInventory;                   // Player's inventory to store weapons.

    void Awake()
	{
		fullMag = mag;
        Pickable = true;
	}

    public void PickUPWeapon(ShootBehaviour shootBehaviour)
    {
        playerInventory = shootBehaviour;
        rbody.isKinematic = true;
        this.col.enabled = false;
        playerInventory.AddWeapon(this);
        interactiveRadius.enabled=false;
        this.Pickable = false;
    }


	// Manage the drop action.
	public void Drop()
	{
		this.gameObject.SetActive(true);
		this.transform.position += Vector3.up;
		rbody.isKinematic = false;
		this.transform.parent = null;
		this.col.enabled = true;
        playerInventory = null;
	}

	// Start the reload action (called by shoot behaviour).
	public bool StartReload()
	{
		if (mag == fullMag || maxBullets == 0)
			return false;
		else if(maxBullets < fullMag - mag)
		{
			mag += maxBullets;
			maxBullets = 0; 
		}
		else
		{
			maxBullets -= fullMag - mag;
			mag = fullMag;
		}

		return true;
	}

	// End the reload action (called by shoot behaviour).
	public void EndReload()
	{
	
	}

	// Manage shoot action.
	public bool Shoot()
	{
		if (mag > 0)
		{
            mag--;
			return true;
		}
		return false;
	}

	// Reset the bullet parameters.
	public void ResetBullets()
	{
        mag = fullMag;
	}

	// Update weapon screen HUD;
}


[System.Serializable]
public enum WeaponType                                    
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
