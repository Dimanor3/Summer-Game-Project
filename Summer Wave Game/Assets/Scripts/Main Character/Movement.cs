using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotation;

	private float xRot;
	private float yRot;
	private float zRot;

	[SerializeField] private Vector3 origRot;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		moveSpeed = 10f;
		rotation = 10f;

		xRot = 0f;
		yRot = 0f;
		zRot = 0f;

		rb = GetComponent<Rigidbody>();

		origRot = rb.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

		float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
		float verticleMovement = Input.GetAxis("Vertical") * moveSpeed;

		yRot += Input.GetAxis("Mouse X");

		Vector3 movement = new Vector3(horizontalMovement, transform.position.y, verticleMovement);
		Vector3 rot = new Vector3(xRot, yRot, zRot);

		rb.AddForce(Vector3.Scale(transform.rotation.eulerAngles, Vector3.Scale(movement, Vector3.forward)));

		if(Input.GetKeyDown(KeyCode.Mouse2)){
			origRot = rb.rotation.eulerAngles;
		}

		if(Input.GetKeyUp(KeyCode.Mouse2)){
			transform.eulerAngles = origRot;
		}

		if(!Input.GetKey(KeyCode.Mouse2)){
			transform.eulerAngles = rot;
		}
	}
}
