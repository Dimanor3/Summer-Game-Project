using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class DummyEnemy : MonoBehaviour {
	private Health hp;

	[SerializeField] private int enemyHealth;

	private bool use;

	// Use this for initialization
	void Start () {
		hp = new Health();
		enemyHealth = 100;

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
			hp.decreaseHealth(10);
			enemyHealth -= 10;
			use = true;
		}
	}
}
