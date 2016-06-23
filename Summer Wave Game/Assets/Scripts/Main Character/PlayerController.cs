using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerStamina))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour {
	// Movement, rotation and dodge speed
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float runSpeed;
	[SerializeField] private float dodgeSpeed;

	// Damping time
	[SerializeField] private float speedDampTime = .1f;

	// Player stamina control
	[SerializeField] private float staminaDecrease;
	[SerializeField] private float staminaRegen;
	[SerializeField] private float playerStamina;

	// Gives us access to all required outside classes
	private PlayerMotor motor;
	private PlayerStamina stamina;
	private CameraOrbit cam;
	private Health health;
	private BarScript healthBar;
	private BarScript staminaBar;
	private WeaponActive WA;

	// Control which weapon is being used
	private bool sword = true;

	// Player Health
	private int hp;

	// Control switch weapon so player can't hold button down
	private bool switchedWeapon;

	// Use this for initialization
	void Start () {
		// Initialize access to all outside classes
		motor = GetComponent<PlayerMotor>();
		stamina = GetComponent<PlayerStamina>();
		cam = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();
		health = GetComponent<Health>();
		healthBar = GameObject.FindWithTag("PlayerHealthBar").GetComponent<BarScript>();
		staminaBar = GameObject.FindWithTag("PlayerStaminaBar").GetComponent<BarScript>();
		WA = gameObject.GetComponent<WeaponActive> ();

		// Initialize necessary variables
		moveSpeed = 5f;
		rotationSpeed = 1.1f;
		dodgeSpeed = 20f;
		runSpeed = 7f;
		staminaDecrease = 5f;
		staminaRegen = 2f;
		playerStamina = 1000f;
		hp = 100;
		switchedWeapon = false;

		// Initialize stamina properties
		stamina.setRegen(staminaRegen);
		stamina.setStaminaLoss(staminaDecrease);
		stamina.setStamina(playerStamina);

		// Initialize Rotation properties
		motor.setRotationSpeed(rotationSpeed);

		// Set players health
		health.setHealth(hp);

		// Set players health to draw
		healthBar.MaxValue = (float)hp;
		healthBar.Value = (float)hp;

		// Set players stamina to draw
		staminaBar.MaxValue = playerStamina;
		staminaBar.Value = playerStamina;

		// Initialize GUI to display sword and not magic
		WA.switchActive(sword);
	}

	// Update is called once per frame
	void Update () {
		// Running?
		float run = Input.GetAxisRaw("Run");

		// Dodging?
		float dodge = Input.GetAxisRaw("Dodge");

		// Main characters left, right, up and down movement
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		// Camera controls
		float camX = Input.GetAxis("Mouse Y");
		float camY = Input.GetAxis("Mouse X");

		// Switch between weapons
		float switchWep = Input.GetAxisRaw("Switch Weapons");

		// Free look?
		float freeLook = Input.GetAxisRaw("FreeLook");

		// Zoom in/out
		float zoom = Input.GetAxisRaw("Mouse ScrollWheel");

		healthBar.Value = health.getHealth();
		staminaBar.Value = stamina.getStamina();

		// Switch between weapons
		if(switchWep != 0 && !switchedWeapon){
			if(sword){
				sword = false;
				WA.switchActive (sword);
			}else{
				sword = true;
				WA.switchActive (sword);
			}

			switchedWeapon = true;
		}

		// Make sure that switchedWeapon is turned off after use
		if(switchWep == 0){
			switchedWeapon = false;
		}

		// Calculations for main characters movement
		Vector3 moveHorizontal = transform.right * horizontalMovement;
		Vector3 moveVertical = transform.forward * verticalMovement;
		Vector3 movement = (moveHorizontal + moveVertical).normalized;
		//Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

		// Rotate player
		/*if(horizontalMovement != 0f || verticalMovement != 0f){
			Rotating(horizontalMovement, verticalMovement);
		}
		*/
		Vector3 rot = new Vector3(0f, camY, 0f) * rotationSpeed;

		// The players movement speed
		if(dodge == 0){
			movement *= running(run);
		}

		// Using stamina?
		useStamina(run, horizontalMovement, verticalMovement);

		// Move/Rotate player
		motor.Move(movement);

		// Set Zoom
		cam.setZoom(zoom);

		// Rotate player so long as free look isn't activated
		if(freeLook == 0 && camX != 0 && camY != 0){
			motor.Rotate(rot);
			motor.PerformRotation();
		}

		// Oribital Camera
		if(freeLook != 0){
			cam.MoveHorizontal(camY);
			cam.MoveVertical(camX);
		}

		if(health.getHealth() > hp){
			health.setHealth(hp);
		}
	}
		
	/*
	void Rotating(float horizontal, float vertical){
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		motor.Rotate(targetDirection, horizontal, vertical);
	}
	*/

	// Checks to see whether the player is running or not,
	// if they are then runSpeed is returned, else moveSpeed
	// is returned, or if they're standing still 0f is returned
	float running(float run){
		if(run > 0 && stamina.getStamina() > 0){
			return runSpeed;
		}

		if(!(run > 0) || run > 0 && stamina.getStamina() <= 0){
			return moveSpeed;
		}

		return 0f;
	}

	// Uses stamina so that the player can't run forever
	void useStamina(float run, float hM, float vM){
		if(run > 0 && stamina.getStamina() > 0){
			if(hM != 0 || vM != 0){
				stamina.decreaseStamina();
			}
		}
	}

	// Returns true or false depending on whether or not
	// the player is using sword or magic
	public bool getSword(){
		return sword;
	}

	// Damage the player
	public void hurt(int dmg){
		health.damage(dmg);
	}

	// Heal player
	public void heal(int heal){
		health.heal(heal);
	}

	// Return Player Health
	public int getHealth(){
		return health.getHealth();
	}
}
