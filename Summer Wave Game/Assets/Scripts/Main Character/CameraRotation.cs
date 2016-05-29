using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	//[SerializeField] private float rotation;

	// Freely rotate the camera along the x and y axis
	[SerializeField] private float xRot;
	[SerializeField] private float yRot;

	// Reset the cameras rotation after free rotation is
	// deactivated
	[SerializeField] private float camX;
	[SerializeField] private float camY;
	[SerializeField] private float camZ;

	// Free rotation keycode
	private KeyCode freeRotation;

	// Reset the camera after free rotation has stopped
	[SerializeField] Vector3 resetCam;

	// Use this for initialization
	void Start () {
		
		//rotation = 1f;

		// Initialize free rotation across the x and y axis
		xRot = 0f;
		yRot = 0f;

		// Initialize the camera's natural rotation
		// (not supposed to change)
		camX = 22f;
		camY = 0f;
		camZ = 0f;

		// Initialize resetCam
		resetCam = new Vector3(camX, camY, camZ);

		// Initialize freeRotation
		freeRotation = KeyCode.Mouse1;
	}
	
	// Update is called once per frame
	void Update () {

		// Set camera's free rotation
		xRot -= Input.GetAxis("Mouse Y");
		yRot += Input.GetAxis("Mouse X");

		// Restrict free rotation around the y axis
		xRot = Mathf.Clamp(xRot, -45f, 45f);

		// Setup the camera's free rotation
		Vector3 camRotation = new Vector3(xRot, yRot, 0f);

		// Freely rotate the camera
		if(Input.GetKey(freeRotation)){
			transform.eulerAngles = camRotation;
		}

		// Reset camera rotation after free rotation is released
		if(Input.GetKeyUp(freeRotation)){
			Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(camX, camY, camZ));
		}
	}
}
