using UnityEngine;
using System.Collections;

public class MagicPooling : MonoBehaviour {
	private EZObjectPools.EZObjectPool magicPool;
	[SerializeField] private GameObject fireball;

	// Use this for initialization
	void Start () {
		magicPool = EZObjectPools.EZObjectPool.CreateObjectPool(fireball, "Magic", 20, false, true, false);
	}

	// Spawn fireball
	public void spawn(){
		magicPool.TryGetNextObject(Vector3.zero, new Quaternion(0f, 0f, 0f, 0f));
	}

	public int getNumberOfActiveFireBalls(){
		return magicPool.ActiveObjectCount();
	}

	public void deactivate(GameObject gO){
		gO.SetActive(false);
	}
}
