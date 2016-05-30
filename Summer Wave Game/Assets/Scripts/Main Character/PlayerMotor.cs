using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	// Access to the main characters rigid body
	private Rigidbody rb;

	// Move main character
	private Vector3 movement;

	// Rotate main character
	private Vector3 rotation;

	// Use this for initialization
	void Start () {
		
		// Initialize rigid body
		rb = GetComponent<Rigidbody>();

		// Initializes movement
		movement = Vector3.zero;

		// Initializes rotation
		rotation = Vector3.zero;

	}

	// Run every physics iteration
	void FixedUpdate(){
		PerformMovement();
		PerformRotation();
	}

	// Gets a movement vector
	public void Move(Vector3 move){
		movement = move;
	}

	// Gets a rotation vector
	public void Rotate(Vector3 rot){
		rotation = rot;
	}

	// Perform movement
	void PerformMovement(){
		if(movement != Vector3.zero){
			rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
		}
	}

	// Perform rotation
	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
	}

}
