using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0f, 0f, 5f);
	}
}
