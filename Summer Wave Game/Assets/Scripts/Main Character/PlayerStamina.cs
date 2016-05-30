using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {
	// Player's stamina
	[SerializeField] private float stamina;
	private float maxStamina;

	// Stamina lost per frame
	private float staminaLoss;

	// Stamina regained per frame
	private float staminaRegen;

	void Start(){
		// Initialize necessary variables
		stamina = 0f;
		staminaLoss = 0f;
		staminaRegen = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(stamina < maxStamina && !(Input.GetAxisRaw("Run") > 0)){
			regen();
		}
	}

	void regen(){
		stamina += staminaRegen;
	}

	// Get stamina
	public float getStamina(){
		return stamina;
	}

	// Decrease stamina
	public void decreaseStamina(){
		stamina -= staminaLoss;
	}

	// Set stamina loss
	public void setStaminaLoss(float sL){
		staminaLoss = sL;
	}

	// Set stamina regen
	public void setRegen(float r){
		staminaRegen = r;
	}

	// Set stamina
	public void setStamina(float s){
		stamina = s;
		maxStamina = s;
	}
}
