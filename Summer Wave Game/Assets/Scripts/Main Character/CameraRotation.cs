using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	[SerializeField] private float rotation;
	[SerializeField] private float xRot;
	[SerializeField] private float yRot;
	[SerializeField] private float camX;
	[SerializeField] private float camY;
	[SerializeField] private float camZ;

	[SerializeField] Vector3 resetCam;

	// Use this for initialization
	void Start () {
		rotation = 1f;
		xRot = 0f;
		yRot = 0f;

		camX = 22f;
		camY = 0f;
		camZ = 0f;
		resetCam = new Vector3(camX, camY, camZ);
	}
	
	// Update is called once per frame
	void Update () {

		xRot -= Input.GetAxis("Mouse Y");
		yRot += Input.GetAxis("Mouse X");

		xRot = Mathf.Clamp(xRot, -45f, 45f);

		Vector3 mousePos = new Vector3(xRot, yRot, 0f);

		if(Input.GetKey(KeyCode.Mouse2)){
			transform.eulerAngles = mousePos;
		}

		if(Input.GetKeyUp(KeyCode.Mouse2)){
			Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(camX, camY, camZ));
		}
	}
}
