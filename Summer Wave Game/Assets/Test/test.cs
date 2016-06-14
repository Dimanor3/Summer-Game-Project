using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public EZObjectPools.EZObjectPool pools;
	[SerializeField] private GameObject gO;

	// Use this for initialization
	void Start () {
		pools = EZObjectPools.EZObjectPool.CreateObjectPool(gO, "Test", 3, false, true, false);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			pools.TryGetNextObject(Vector3.zero, new Quaternion(0f,0f,0f,0f));
			print(pools.AvailableObjectCount());
		}
	}

	public void deactivate(GameObject test){
		test.SetActive(false);
	}
}
