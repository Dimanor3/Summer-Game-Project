using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerStamina))]
public class PlayerController : MonoBehaviour {
	// Movement and rotation speed
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float runSpeed;

	// Player stamina control
	[SerializeField] private float staminaDecrease;
	[SerializeField] private float staminaRegen;
	[SerializeField] private float playerStamina;

	// Gives us access to all required outside classes
	private PlayerMotor motor;
	private PlayerStamina stamina;

	// Running?
	private float run;

	// Use this for initialization
	void Start () {
		// Initialize access to all outside classes
		motor = GetComponent<PlayerMotor>();
		stamina = GetComponent<PlayerStamina>();

		// Initialize necessary variables
		moveSpeed = 10f;
		rotationSpeed = 3f;
		runSpeed = 20f;
		staminaDecrease = 5f;
		staminaRegen = 2f;
		playerStamina = 1000f;

		// Initialize stamina properties
		stamina.setRegen(staminaRegen);
		stamina.setStaminaLoss(staminaDecrease);
		stamina.setStamina(playerStamina);
	}

	// Update is called once per frame
	void Update () {
		// Running?
		float run = Input.GetAxisRaw("Run");

		// Main characters left, right, up and down movement
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		// Turn the main characters on the y axis
		float yRot = Input.GetAxisRaw("Mouse X");

		// Player using free rotation?
		float freeRot = Input.GetAxisRaw("FreeLook");

		// Calculations for main characters movement
		Vector3 moveHorizontal = transform.right * horizontalMovement;
		Vector3 moveVertical = transform.forward * verticalMovement;
		Vector3 movement = (moveHorizontal + moveVertical).normalized;

		if(run > 0 && stamina.getStamina() > 0){
			movement *= runSpeed;

			if(horizontalMovement != 0 || verticalMovement != 0){
				stamina.decreaseStamina();
			}
		}

		if(!(run > 0) || run > 0 && stamina.getStamina() <= 0){
			movement *= moveSpeed;
		}

		// Calculations for main characters rotation
		Vector3 rot = new Vector3(0f, yRot, 0f) * rotationSpeed;

		// Move player
		motor.Move(movement);

		// Rotate the main character so long as the player isn't using free
		// rotation
		if(!(freeRot > 0)){
			motor.Rotate(rot);
		}
	}
}
