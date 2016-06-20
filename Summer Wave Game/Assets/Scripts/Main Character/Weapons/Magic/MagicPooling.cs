using UnityEngine;
using System.Collections;

public class MagicPooling : MonoBehaviour {
	private EZObjectPools.EZObjectPool magicPool;
	[SerializeField] private GameObject fireball;

	// Use this for initialization
	void Start () {
		//fireball = Instantiate(Resources.Load("test/testPref")) as GameObject;
		magicPool = EZObjectPools.EZObjectPool.CreateObjectPool(fireball, "Magic", 20, false, true, false);
	}

	// Spawn fireball
	public void spawn(Vector3 vec, Quaternion rot){
		magicPool.TryGetNextObject(vec, rot);
	}

	public int getNumberOfAvailableFireballs(){
		return magicPool.AvailableObjectCount();
	}

	public void despawn(GameObject gO){
		gO.SetActive(false);
	}
}
