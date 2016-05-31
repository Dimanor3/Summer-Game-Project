using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerStamina))]
public class PlayerController : MonoBehaviour {
	// Movement and rotation speed
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float runSpeed;

	// Damping time
	[SerializeField] private float speedDampTime = .1f;

	// Player stamina control
	[SerializeField] private float staminaDecrease;
	[SerializeField] private float staminaRegen;
	[SerializeField] private float playerStamina;

	// Gives us access to all required outside classes
	private PlayerMotor motor;
	private PlayerStamina stamina;
	[SerializeField] private CameraOrbit cam;

	// Running?
	private float run;

	// Use this for initialization
	void Start () {
		// Initialize access to all outside classes
		motor = GetComponent<PlayerMotor>();
		stamina = GetComponent<PlayerStamina>();
		cam = GameObject.Find("Main Camera").GetComponent<CameraOrbit>();

		// Initialize necessary variables
		moveSpeed = 10f;
		rotationSpeed = 15f;
		runSpeed = 20f;
		staminaDecrease = 5f;
		staminaRegen = 2f;
		playerStamina = 1000f;

		// Initialize stamina properties
		stamina.setRegen(staminaRegen);
		stamina.setStaminaLoss(staminaDecrease);
		stamina.setStamina(playerStamina);

		// Initialize Rotation properties
		motor.setRotationSpeed(rotationSpeed);
	}

	// Update is called once per frame
	void Update () {
		// Running?
		float run = Input.GetAxisRaw("Run");

		// Main characters left, right, up and down movement
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		// Camera controls
		float camX = Input.GetAxis("Mouse Y");
		float camY = Input.GetAxis("Mouse X");

		// Turn the main characters on the y axis
		float yRot = Input.GetAxisRaw("Mouse X");

		// Calculations for main characters movement
		//Vector3 moveHorizontal = transform.right * horizontalMovement;
		//Vector3 moveVertical = transform.forward * verticalMovement;
		//Vector3 movement = (moveHorizontal + moveVertical).normalized;
		Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

		if(horizontalMovement != 0f || verticalMovement != 0f){
			Rotating(horizontalMovement, verticalMovement);
		}

		movement *= running(run);
		useStamina(run, horizontalMovement, verticalMovement);

		// Calculations for main characters rotation
		Vector3 rot = new Vector3(0f, yRot, 0f) * rotationSpeed;

		// Move player
		motor.Move(movement);
		//motor.Rotate(rot);

		camX = Mathf.Clamp(camX, -45f, 45f);

		cam.MoveHorizontal(camY);
		cam.MoveVertical(camX);
	}

	void Rotating(float horizontal, float vertical){
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		motor.Rotate(targetDirection, horizontal, vertical);
	}

	float running(float run){
		if(run > 0 && stamina.getStamina() > 0){
			return runSpeed;
		}

		if(!(run > 0) || run > 0 && stamina.getStamina() <= 0){
			return moveSpeed;
		}

		return 0f;
	}

	void useStamina(float run, float hM, float vM){
		if(run > 0 && stamina.getStamina() > 0){
			if(hM != 0 || vM != 0){
				stamina.decreaseStamina();
			}
		}
	}
}
