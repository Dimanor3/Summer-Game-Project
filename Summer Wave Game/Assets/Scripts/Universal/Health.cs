using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	// original Health
	[SerializeField] private int originalHP;

	// Health
	[SerializeField] private int hp;

	void Update(){
		if(hp >= originalHP){
			hp = originalHP;
		}
	}

	// Decrease Health
	public void damage(int dHP){
		hp -= dHP;
	}

	// Increase Health
	public void heal(int iHP){
		hp += iHP;
	}

	// Return Health
	public int getHealth(){
		return hp;
	}

	// Set health
	public void setHealth(int sHP){
		originalHP = sHP;
		hp = originalHP;
	}
}
