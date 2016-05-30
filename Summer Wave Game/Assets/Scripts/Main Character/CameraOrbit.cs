using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
	public void MoveHorizontal(float horizMove){
		transform.RotateAround(transform.parent.position, Vector3.up, horizMove);
	}

	public void MoveVertical(float vertMove){
		//if(transform.rotation.eulerAngles.y >= -45 && transform.rotation.eulerAngles.y <= 45){
			transform.RotateAround(transform.parent.position, transform.TransformDirection(Vector3.right), vertMove);
		//}
	}
}
