using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
	public void MoveHorizontal(float horizMove){
		transform.RotateAround(transform.parent.position, Vector3.up, horizMove);
	}

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
}
