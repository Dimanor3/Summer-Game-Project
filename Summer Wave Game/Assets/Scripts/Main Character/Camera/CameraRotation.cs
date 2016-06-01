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

		// Initialize resetCam
		resetCam = new Vector3(camX, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Set camera's free rotation
		xRot -= Input.GetAxis("Mouse Y");
		yRot += Input.GetAxis("Mouse X");

		// Restrict free rotation around the y axis
		xRot = Mathf.Clamp(xRot, -45f, 45f);

		// Free rotation mode?
		float freeRot = Input.GetAxisRaw("FreeLook");

		// Setup the camera's free rotation
		Vector3 camRotation = new Vector3(xRot, yRot, 0f);

		// Freely rotate the camera and reset when done
		if(freeRot > 0){
			transform.eulerAngles = camRotation;
		}else{
			transform.eulerAngles = resetCam;
		}
	}
}