using UnityEngine;
using System.Collections;

public class TestObject : PoolObject {
	// Update is called once per frame
	void Update () {
		transform.localScale += Vector3.one * Time.deltaTime * 3;
		transform.Translate(Vector3.forward * Time.deltaTime * 25);
	}

	public override void OnObjReuse(){
		transform.localScale = Vector3.one;
	}
}
