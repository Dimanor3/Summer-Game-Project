using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	// Damage
	private int damage;

	// Fireball speed
	private float speed;

	// Use this for initialization
	void Start () {
		speed = 1f;
	}

	void Update(){
		if(gameObject.activeSelf == true){
			setDamage();
		}

		// Move the fireball
		transform.position += new Vector3(0f, 0f, speed);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemy"){
			gameObject.SetActive(false);
		}
	}

	public void setDamage(){
		damage = GetComponentInParent<MagicUse>().getDamage();
	}
}
