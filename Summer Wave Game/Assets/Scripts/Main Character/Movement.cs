using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Movement and rotation speed
	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotationSpeed;

	// Free rotation keycode
	private KeyCode freeRotation;

	// Rotate main character
	private float xRot;
	private float yRot;
	private float zRot;

	// Used to set the player back to its original rotation after the free rotation is released
	[SerializeField] private Vector3 origRot;

	// Access to the main characters rigid body
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		
		// Initialize movement and rotational speeds
		moveSpeed = 10f;
		rotationSpeed = 10f;

		// Initialize each rotational axis
		xRot = 0f;
		yRot = 0f;
		zRot = 0f;

		// Initialize rigid body
		rb = GetComponent<Rigidbody>();

		// Initialize the players original rotation
		origRot = rb.rotation.eulerAngles;

		// Initialize the free rotation keycode
		freeRotation = KeyCode.Mouse1;
	}
	
	// Update is called once per frame
	void Update () {

		// Main characters left, right, up and down movement
		float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
		float verticleMovement = Input.GetAxis("Vertical") * moveSpeed;

		// Turn the main characters on the y axis
		yRot += Input.GetAxis("Mouse X");

		// Setup for main characters movement
		Vector3 movement = new Vector3(horizontalMovement, transform.position.y, verticleMovement);

		// Setup for main characters rotation
		Vector3 rot = new Vector3(xRot, yRot, zRot);

		// Move player
		rb.AddForce(Vector3.Scale(transform.rotation.eulerAngles, Vector3.Scale(movement, Vector3.forward)));

		// Save the main characters current rotation
		if(Input.GetKeyDown(freeRotation)){
			origRot = rb.rotation.eulerAngles;
		}

		// Reposition the main characters rotation back to what it originally
		// was before free rotations was used
		if(Input.GetKeyUp(freeRotation)){
			transform.eulerAngles = origRot;
		}

		// Rotate the main character so long as the player isn't using free
		// rotation
		if(!Input.GetKey(freeRotation)){
			transform.eulerAngles = rot;
		}
	}
}
