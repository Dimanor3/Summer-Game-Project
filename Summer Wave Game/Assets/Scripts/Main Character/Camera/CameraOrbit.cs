using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
	// Reset camera rotation and position
	private Vector3 resetCamRotation;
	private Vector3 resetCamPosition;

	// Zoom Camera
	private float zoomMax;
	private float zoomMin;
	private float zoom;
	private float zoomSpeed;
	private float zoomDist;

	void Start(){
		// Initialize resetCam
		resetCamRotation = new Vector3(22f, 0f, 0f);
		resetCamPosition = new Vector3(0f, 3.882f, -3.964f);

		// Initialize necessary variables
		zoomMax = 60f;
		zoomMin = 20f;
		zoom = 0f;
		zoomDist = (zoomMax + zoomMin) / 2;
		zoomSpeed = 10f;
	}

	void Update(){
		// Reset camera position and rotation once the user stops free looking
		if(Input.GetButtonUp("FreeLook")){
			transform.localEulerAngles = resetCamRotation;
			transform.localPosition = resetCamPosition;
		}

		PerformZoom();
	}

	// Rotate Horizontally
	public void MoveHorizontal(float horizMove){
		transform.RotateAround(transform.parent.position, Vector3.up, horizMove);
	}

	// Rotate Vertically
	public void MoveVertical(float vertMove){
		/*
		if(transform.rotation.x < -.15f){
			vertMove = 0f;
			transform.rotation.Set(-14f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		}
		
		if(transform.rotation.x > .3f){
			vertMove = 0f;
			transform.rotation.Set(29f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		}
		*/

		//print(transform.rotation.x);

		transform.RotateAround(transform.parent.position, transform.TransformDirection(Vector3.right), vertMove);
	}

	public void PerformZoom(){
		zoomDist += zoom * zoomSpeed;
		zoomDist = Mathf.Clamp(zoomDist, zoomMin, zoomMax);

		Camera.main.fieldOfView = zoomDist;
	}

	public void setZoom(float z){
		zoom = z;
	}
}
