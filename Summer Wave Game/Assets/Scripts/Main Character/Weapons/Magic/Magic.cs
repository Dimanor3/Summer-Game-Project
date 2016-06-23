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

	// Player object
	private GameObject player;

	// Cause explosion
	private GameObject explosion;

	// Use this for initialization
	void Start () {
		// Initialize player object
		player = GameObject.FindWithTag ("Player");

		// Initialize explosion
		explosion = GameObject.FindWithTag("Explosion");

		// Initialize speed
		speed = 200f;

		// Initialize timer
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
			gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			timer = resetTimer;
		}
	}

	void FixedUpdate(){
		// Move the fireball
		//gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * Time.fixedDeltaTime);
		gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision col){
		timer = 0;
	}

	private void setDamage(){
		damage = GameObject.FindWithTag("MagicController").GetComponentInChildren<MagicUse>().getDamage();
	}

	public int getDamage(){
		return damage;
	}

	public void destroy(){
		timer = 0;
	}
}
