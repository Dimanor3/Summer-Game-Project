﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class enemyDeath : MonoBehaviour{
	public EnemyHealth hp;

	[SerializeField] private int enemyHealth;

	[SerializeField] private bool use;

	public GameObject sword;

	public GameObject magicR;

	private Sword sr;

	private MagicUse mr;

	private int sl;

	private int ml;

	private int average;

	// Use this for initialization
	void Start(){
<<<<<<< HEAD
		//hp = new EnemyHealth ();
		sword = GameObject.FindGameObjectWithTag ("Sword");
		magicR = GameObject.FindGameObjectWithTag ("MagicPool");
		//sr = sword.GetComponent<Sword> ().swordLevel;
		//mr = magicR.GetComponent<MagicUse> ().magicLevel;

		sl = sword.GetComponent<Sword> ().swordLevel;
		ml = magicR.GetComponent<MagicUse> ().magicLevel;

		//hp = (EnemyHealth)this.GetComponent(typeof(EnemyHealth));
		//sr = (Sword)sword.GetComponent(typeof(Sword));
		//mr = (MagicUse)magicR.GetComponent (typeof(MagicUse));

		//sl = sr.swordLevel;
		//ml = mr.magicLevel;

		//sl = hp.gameObject.GetComponent<Sword> ().SwordLevel ();

		//ml = hp.gameObject.GetComponent<MagicUse>().MagicLevel();

		average = (sl + ml) / 2;
		//enemyHealth = 50;
		enemyHealth = 10 + (average * 2);
=======
		hp = GetComponent<Health>();
		enemyHealth = 50;
>>>>>>> a5b5f24245980383261e4befac29995cabc81459

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
