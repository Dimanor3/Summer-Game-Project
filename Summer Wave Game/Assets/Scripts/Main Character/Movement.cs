using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotation;

	private float xRot;
	private float yRot;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		moveSpeed = 10f;
		rotation = 10f;

		xRot = 0f;
		yRot = 0f;

		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
		float verticleMovement = Input.GetAxis("Vertical") * moveSpeed;

		xRot -= Input.GetAxis("Mouse Y");
		yRot += Input.GetAxis("Mouse X");

		Vector3 movement = new Vector3(horizontalMovement, transform.position.y, verticleMovement);
		Vector3 rot = new Vector3(xRot, yRot, 0f);

		rb.AddForce(movement);

		if(!Input.GetKey(KeyCode.Mouse2)){
			transform.eulerAngles = rot;
		}
	}
}
