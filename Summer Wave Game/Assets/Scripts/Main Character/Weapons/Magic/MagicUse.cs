﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class MagicUse : MonoBehaviour {
	// Gives access to required outside classes
	private PlayerController PC;
	private MagicPooling MP;
	private PlayerDamageMath PDM;

	// Number of active fireballs
	[SerializeField] private int availableFireballs;

	// Base magic damage
	[SerializeField] private int baseDmg;

	// Magic damage
	[SerializeField] private int magicDmg;

	// The constant level modifier (occurs every level)
	[SerializeField] private int constLvlMod;

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

	// Use this for initialization
	void Start () {
		// Initialize required variables
		PC = GetComponentInParent<PlayerController>();
		MP = GetComponent<MagicPooling>();
		PDM = GetComponent<PlayerDamageMath>();

		// Initialize required variables
		magicDmg = 0;
		magicKills = 0;
		baseDmg = 10;
		constLvlMod = 1;
		constTenLvlMod = 10;
		lvl50Mod = 30;
		lvl99Mod = 50;
		availableFireballs = 0;
		clicked = false;

		// Set Base Damage
		PDM.setBaseDmg(baseDmg);
	}
	
	// Update is called once per frame
	void Update () {
		// Set the number of active fireballs
		availableFireballs = MP.getNumberOfAvailableFireballs();

		// Attack
		float attack = Input.GetAxisRaw("Fire1");

		// Use magic if possible
		if(!PC.getSword() && attack != 0 && availableFireballs != 0 && !clicked){
			clicked = true;

			MP.spawn(gameObject.transform.position, transform.rotation);
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
		magicDmg = PDM.getNewDmg(magicKills + 1, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}

	public int getDamage(){
		return magicDmg;
	}

	public void levelUpPotion(int lU){
		magicKills += lU;
		magicDmg = PDM.getNewDmg(magicKills + 1, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}
}
