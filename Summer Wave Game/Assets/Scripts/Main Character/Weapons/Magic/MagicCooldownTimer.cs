using UnityEngine;
using System.Collections;

public class MagicCooldownTimer : MonoBehaviour {
	// Cooldown timer
	[SerializeField] int timer;
	[SerializeField] int resetTimer;

	// Set the Timer
	public void setTimer(int time){
		resetTimer = time;
		timer = resetTimer;
	}

	// Reset the Timer
	public void reset(){
		timer = resetTimer;
	}

	// Reduce timer
	public void reduceTimer(){
		timer--;
	}

	// Get Timer
	public int getTimer(){
		return timer;
	}
}
