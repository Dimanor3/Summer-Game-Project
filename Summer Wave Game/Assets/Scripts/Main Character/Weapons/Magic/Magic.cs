using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	// Damage
	private int damage;

	// Fireball speed
	private float speed;

	// Timer
	[SerializeField] private int timer;
	private int resetTimer;

	// Use this for initialization
	void Start () {
		speed = 200f;
		resetTimer = 200;
		timer = resetTimer;
	}

	void Update(){
		if(gameObject.activeSelf == true){
			setDamage();
		}

		// Move the fireball
		gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * Time.deltaTime);
		//gameObject.GetComponent<Rigidbody>().AddForce(GameObject.FindWithTag("Player").transform.forward * speed * Time.deltaTime);

		timer--;

		if(timer <= 0){
			gameObject.SetActive(false);
			timer = resetTimer;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			gameObject.SetActive (false);
		}
	}

	private void setDamage(){
		damage = GameObject.FindWithTag("MagicController").GetComponentInChildren<MagicUse>().getDamage();
	}

	public int getDamage(){
		return damage;
	}
}
