using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	// Health
	[SerializeField] private float hp;

	// Decrease Health
	public void decreaseHealth(float dHP){
		hp -= dHP;
	}

	// Increase Health
	public void increaseHealth(float iHP){
		hp += iHP;
	}

	// Return Health
	public float getHealth(){
		return hp;
	}

	// Set health
	public void setHealth(float sHP){
		hp = sHP;
	}
}
