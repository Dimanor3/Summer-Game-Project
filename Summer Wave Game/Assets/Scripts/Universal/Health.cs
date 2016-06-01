using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	// Health
	[SerializeField] private int hp;

	// Decrease Health
	public void decreaseHealth(int dHP){
		hp -= dHP;
	}

	// Increase Health
	public void increaseHealth(int iHP){
		hp += iHP;
	}

	// Return Health
	public int getHealth(){
		return hp;
	}

	// Set health
	public void setHealth(int sHP){
		hp = sHP;
	}
}
