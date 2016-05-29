using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	[SerializeField] private float rotation;
	[SerializeField] private float xRot;
	[SerializeField] private float yRot;

	private float camX;
	private float camY;

	// Use this for initialization
	void Start () {
		rotation = 1f;
		xRot = 0f;
		yRot = 0f;

		camX = transform.rotation.x;
		camY = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {

		xRot -= Input.GetAxis("Mouse Y");
		yRot += Input.GetAxis("Mouse X");

		xRot = Mathf.Clamp(xRot, -45f, 45f);

		Vector3 mousePos = new Vector3(xRot, yRot, 0f);

		if(Input.GetKeyDown(KeyCode.Mouse2)){
			camX = transform.rotation.x;
			camY = transform.rotation.y;
		}

		if(Input.GetKey(KeyCode.Mouse2)){
			transform.eulerAngles = mousePos;
		}
	}
}
