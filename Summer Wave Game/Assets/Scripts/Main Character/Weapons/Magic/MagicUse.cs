﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerDamageMath))]
[RequireComponent(typeof(MagicCooldownTimer))]
public class MagicUse : MonoBehaviour {
	// Gives access to required outside classes
	private PlayerController PC;
	private MagicPooling MP;
	private PlayerDamageMath PDM;
	private MagicCooldownTimer MCDT;

	// Number of active fireballs
	[SerializeField] private int availableFireballs;

	// Base magic damage
	[SerializeField] private int baseDmg;

	// Magic damage
	[SerializeField] private int magicDmg;

	// The constant level modifier (occurs every level)
	[SerializeField] private int constLvlMod;

	private int magicLevel;

	// The constant level modifier (occurs every 10 levels)
	[SerializeField] private int constTenLvlMod;

	// Occurs once at level 50
	[SerializeField] private int lvl50Mod;

	// Occurs once at level 99
	[SerializeField] private int lvl99Mod;

	// Number of magic kills
	[SerializeField] private int magicKills;

	// One at a time
	private bool clicked;

	private Text displayMagicLevel;

	// Use this for initialization
	void Start () {
		// Initialize required variables
		PC = GetComponentInParent<PlayerController>();
		MP = GetComponent<MagicPooling>();
		PDM = GetComponent<PlayerDamageMath>();
		MCDT = GetComponent<MagicCooldownTimer>();

		// Initialize required variables
		baseDmg = 10;
		magicDmg = baseDmg;
		magicLevel = 1;
		magicKills = 0;
		constLvlMod = 1;
		constTenLvlMod = 10;
		lvl50Mod = 30;
		lvl99Mod = 50;
		availableFireballs = 0;
		clicked = false;

		// Initialize magic cool down timer
		MCDT.setTimer(50);

		displayMagicLevel = GameObject.Find ("MagicLevel").GetComponent<Text> ();
		displayMagicLevel.text = "Magic Level: " + magicLevel;
	}
	
	// Update is called once per frame
	void Update () {
		MCDT.reduceTimer();

		// Set the number of active fireballs
		availableFireballs = MP.getNumberOfAvailableFireballs();

		// Attack
		float attack = Input.GetAxisRaw("Fire1");

		// Use magic if possible
		if(!PC.getSword() && attack != 0 && availableFireballs != 0 && !clicked && MCDT.getTimer() <= 0){
			clicked = true;

			MP.spawn(gameObject.transform.position, gameObject.transform.rotation);

			MCDT.reset();
		}

		if(attack == 0){
			clicked = false;
		}

		if(availableFireballs == 0){
			MP.despawn(gameObject);
		}
	}

	public void levelUp(){
		magicKills++;
		magicLevel++;
		magicDmg = PDM.getNewDmg(magicLevel, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
		displayMagicLevel.text = "Magic Level: " + magicLevel;
	}

	public int getDamage(){
		return magicDmg;
	}

	public int getMagicLevel(){
		return magicLevel;
	}

	// Level up player and update magic;
	public void levelUp(int lU){
		magicKills += lU;
		magicLevel += lU;
		magicDmg = PDM.getNewDmg(magicLevel, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
		displayMagicLevel.text = "Magic Level: " + magicLevel;
	}
}
