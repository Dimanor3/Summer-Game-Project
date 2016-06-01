using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	// Access to the main characters rigid body
	private Rigidbody rb;

	// Move main character
	[SerializeField] private Vector3 movement;

	// Rotate main character
	private Vector3 rotation;

	// Rotation speed
	private float rotationSpeed = 0f;

	// Rotate the player
	Quaternion newRotation;

	// Use this for initialization
	void Start () {
		// Initialize rigid body
		rb = GetComponent<Rigidbody>();

		// Initializes movement
		movement = Vector3.zero;

		// Initializes rotation
		rotation = Vector3.zero;

		newRotation = new Quaternion(0f, 0f, 0f, 1f);
	}

	// Run every physics iteration
	void FixedUpdate(){
		PerformMovement();
		//PerformRotation();
	}

	// Gets a movement vector
	public void Move(Vector3 move){
		movement = move;
	}

	// Gets a rotation vector
	public void Rotate(Vector3 rot){//, float horizontal, float vertical){
		rotation = rot;
		/*
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(rotation, Vector3.up);

		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		*/
	}

	// Perform movement
	void PerformMovement(){
		if(movement != Vector3.zero){
			rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
		}
	}

	// Perform rotation
	public void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		//rb.MoveRotation(newRotation);
	}

	// Set rotationSpeed
	public void setRotationSpeed(float rS){
		rotationSpeed = rS;
	}
}
