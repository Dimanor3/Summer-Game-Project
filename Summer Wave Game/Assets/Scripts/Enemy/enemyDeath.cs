using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class enemyDeath : MonoBehaviour {
	private Health hp;

	[SerializeField] private int enemyHealth;

	[SerializeField] private bool use;

	// Use this for initialization
	void Start () {
		hp = new Health();
		enemyHealth = 10;

		hp.setHealth(enemyHealth);

		use = false;
	}

	// Update is called once per frame
	void Update () {
		if(hp.getHealth() <= 0){
			transform.position = new Vector3(999f, 999f, 999f);
		}

		if(Input.GetAxisRaw("Fire1") == 0f){
			use = false;
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Sword" && Input.GetAxisRaw("Fire1") != 0f && !use){
			hp.damage(col.gameObject.GetComponent<Sword>().getDamage());
			enemyHealth = hp.getHealth();
			use = true;
		}

		if(col.gameObject.tag == "Sword" && hp.getHealth() <= 0){
			col.gameObject.GetComponent<Sword>().levelUp();
			print(col.gameObject.GetComponent<Sword>().getDamage());
		}


		if(col.gameObject.tag == "Magic" && hp.getHealth() <= 0){
			col.gameObject.GetComponent<Magic>().levelUp();
		}
	}

	public int getHealth(){
		return hp.getHealth();
	}
}
