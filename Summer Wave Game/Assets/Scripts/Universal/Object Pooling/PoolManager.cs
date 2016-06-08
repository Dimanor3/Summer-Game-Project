using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {
	Dictionary<int,Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>();

	static PoolManager _instance;

	public static PoolManager instance{
		get{
			if(_instance == null){
				_instance = FindObjectOfType<PoolManager>();
			}

			return _instance;
		}
	}

	public void CreatePool(GameObject prefab, int poolSize){
		int poolKey = prefab.GetInstanceID();

		if(!poolDictionary.ContainsKey(poolKey)){
			poolDictionary.Add(poolKey, new Queue<ObjectInstance>());

			for(int i = 0; i < poolSize; i++){
				ObjectInstance newObject = new ObjectInstance((prefab) as GameObject);
				//newObject.SetActive(false);
				poolDictionary[poolKey].Enqueue(newObject);
			}
		}
	}

	public void ReuseObject(GameObject prefab, Vector3 pos, Quaternion rot){
		int poolKey = prefab.GetInstanceID();

		if(poolDictionary.ContainsKey(poolKey)){
			ObjectInstance objToReuse = poolDictionary[poolKey].Dequeue();
			poolDictionary[poolKey].Enqueue(objToReuse);

			objToReuse.Reuse(pos, rot);
		}
	}

	public class ObjectInstance{
		GameObject gameObj;
		Transform trans;

		bool hasPoolObjComponent;
		PoolObject poolObjScript;

		public ObjectInstance(GameObject objectInstance){
			gameObj = objectInstance;
			trans = gameObj.transform;
			gameObj.SetActive(false);

			if(gameObj.GetComponent<PoolObject>()){
				hasPoolObjComponent = true;
				poolObjScript = gameObj.GetComponent<PoolObject>();
			}
		}

		public void Reuse(Vector3 pos, Quaternion rot){
			gameObj.SetActive(true);
			trans.position = pos;
			trans.rotation = rot;

			if(hasPoolObjComponent){
				poolObjScript.OnObjReuse();
			}
		}
	}
}
