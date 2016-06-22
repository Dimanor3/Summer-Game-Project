using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class enemyDeath : MonoBehaviour{
	private Health hp;

	[SerializeField] private int enemyHealth;

	[SerializeField] private bool use;

	// Use this for initialization
	void Start(){
		hp = new Health();
		enemyHealth = 50;

		hp.setHealth(enemyHealth);

		use = false;
	}

	// Update is called once per frame
	void Update(){
		// Kill enemy if dead
		if(hp.getHealth() <= 0 || gameObject.transform.position.y <= -10){
			transform.position = new Vector3(999f, 999f, 999f);
		}

		// Control sword attack (so player can't spam)
		if(Input.GetAxisRaw("Fire1") == 0f){
			use = false;
		}
	}

	void OnTriggerEnter (Collider col){
		if(col.gameObject.tag == "Sword" && Input.GetAxisRaw("Fire1") != 0f && !use){
			hp.damage(col.gameObject.GetComponent<Sword>().getDamage());
			use = true;

			if(hp.getHealth() <= 0){
				use = false;
			}
		}

		if(col.gameObject.tag == "Sword" && hp.getHealth() <= 0 && !use){
			col.gameObject.GetComponent<Sword>().levelUp();
			use = true;
		}

		if(col.gameObject.tag == "Magic"){
			hp.damage(col.gameObject.GetComponent<Magic>().getDamage());
		}

		if(col.gameObject.tag == "Magic" && hp.getHealth() <= 0){
			GameObject.FindWithTag("MagicController").GetComponentInChildren<MagicUse>().levelUp();
		}
	}

	// Set enemy health
	public void setHealth(int healthPoints){
		enemyHealth = healthPoints;
		hp.setHealth(enemyHealth);
	}

	// Get enemy health
	public int getHealth(){
		return hp.getHealth();
	}
}
