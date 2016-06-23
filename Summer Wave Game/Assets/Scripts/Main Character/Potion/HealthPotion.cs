using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour {
	// Heal player
	private int heal;

	// Use this for initialization
	void Start () {
		// Initialize necessary variables
		heal = 25;
	}

	void OnCollisionEnter(Collision col){
		// Heal the player and deactivate
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerController>().heal(heal);
			Destroy(gameObject);
		}
	}
}
