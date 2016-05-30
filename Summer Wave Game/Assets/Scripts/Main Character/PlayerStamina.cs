using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {
	// Player's stamina
	[SerializeField] private float stamina = 0f;
	private float maxStamina = 0f;

	// Stamina lost per frame
	[SerializeField] private float staminaLoss = 0f;

	// Stamina regained per frame
	[SerializeField] private float staminaRegen = 0f;
	
	// Update is called once per frame
	void Update () {
		if(stamina < maxStamina){
			if(!(Input.GetAxisRaw("Run") > 0)){
				regen();
			}

			if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
				regen();
			}
		}

		if(stamina >= maxStamina){
			stamina = maxStamina;
		}

		if(stamina <= 0f){
			stamina = 0f;
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
