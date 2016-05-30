using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	// Movement and rotation speed
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotationSpeed;

	// Gives us access to the PlayerMotor
	private PlayerMotor motor;

	// Free rotation keycode
	private KeyCode freeRotation;

	// Rotate main character
	private float yRot;

	// Use this for initialization
	void Start () {

		// Initialize access to PlayerMotor
		motor = GetComponent<PlayerMotor>();

		// Initialize movement and rotational speeds
		moveSpeed = 10f;
		rotationSpeed = 3f;

		// Initialize each rotational axis
		yRot = 0f;

		// Initialize the free rotation keycode
		freeRotation = KeyCode.Mouse1;
	}

	// Update is called once per frame
	void Update () {

		// Main characters left, right, up and down movement
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		// Turn the main characters on the y axis
		yRot = Input.GetAxisRaw("Mouse X");

		// Calculations for main characters movement
		Vector3 moveHorizontal = transform.right * horizontalMovement;
		Vector3 moveVertical = transform.forward * verticalMovement;
		Vector3 movement = (moveHorizontal + moveVertical).normalized * moveSpeed;

		// Calculations for main characters rotation
		Vector3 rot = new Vector3(0f, yRot, 0f) * rotationSpeed;

		// Move player
		motor.Move(movement);

		// Rotate the main character so long as the player isn't using free
		// rotation
		if(!Input.GetKey(freeRotation)){
			motor.Rotate(rot);
		}
	}

}
