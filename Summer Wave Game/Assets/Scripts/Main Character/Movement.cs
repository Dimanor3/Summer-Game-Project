using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float rotation;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		moveSpeed = 10f;
		rotation = 10f;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			rb.AddForce(new Vector3(-1f * moveSpeed, 0f, 0f));
		}

		if(Input.GetKey(KeyCode.D)){
			rb.AddForce(new Vector3(1f * moveSpeed, 0f, 0f));
		}

		if(Input.GetKey(KeyCode.W)){
			rb.AddForce(new Vector3(0f, 0f, 1f * moveSpeed));
		}

		if(Input.GetKey(KeyCode.S)){
			rb.AddForce(new Vector3(0f, 0f, -1f * moveSpeed));
		}

	}
}
