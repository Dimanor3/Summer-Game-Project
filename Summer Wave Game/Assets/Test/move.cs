using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	private Vector3 temp;

	void Start(){
		temp = transform.localScale;
	}

	// Update is called once per frame
	void Update (){
		transform.position += new Vector3(0f, 0f, 5f);
		transform.localScale *= 1.1f;

		if(GameObject.Find("GameObject").GetComponent<test>().pools.ActiveObjectCount() == 3 && Input.GetKeyDown(KeyCode.Space)){
			gameObject.SetActive(false);
			transform.localScale = temp;
		}
	}
}
