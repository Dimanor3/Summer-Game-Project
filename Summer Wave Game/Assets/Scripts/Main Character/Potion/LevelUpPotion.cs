using UnityEngine;
using System.Collections;

public class LevelUpPotion : MonoBehaviour {
	// Level up
	private int levelUp;

	// Use this for initialization
	void Start () {
		// Initialize necessary variables
		levelUp = 5;
	}

	void OnCollisionEnter(Collision col){
		// Level up weapons
		if(col.gameObject.tag == "Player"){
			if(col.gameObject.GetComponent<PlayerController>().getSword()){
				GameObject.FindWithTag("Sword").GetComponent<Sword>().levelUpPotion(levelUp);
			}else{
				
			}

			gameObject.SetActive(false);
		}
	}
}
