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

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		speed = 200f;
		resetTimer = 200;
		timer = resetTimer;
	}

	void Update(){
		if(gameObject.activeSelf == true){
			setDamage();
		}

		timer--;

		if(timer <= 0){
			gameObject.SetActive(false);
			timer = resetTimer;
		}
	}

	void FixedUpdate(){
		// Move the fireball
		//gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * Time.fixedDeltaTime);
		gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
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
