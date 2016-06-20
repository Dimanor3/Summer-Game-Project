using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	// Damage
	[SerializeField] int dmg;

	// Damage timer
	[SerializeField] int timer;
	[SerializeField] int resetTimer;

	// Use this for initialization
	void Start () {
		dmg = 15;
		timer = 30;
		resetTimer = 30;
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
	}

	void OnTriggerEnter (Collider col){
		if(col.gameObject.tag == "Player" && timer <= 0){
			col.gameObject.GetComponent<PlayerController>().hurt(dmg);

			timer = resetTimer;
		}
	}
}
