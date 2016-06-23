﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class Sword : MonoBehaviour {
	// Number of sword kills
	[SerializeField] private int swordKills;

	// Gives access to required outside classes
	private PlayerDamageMath PDM;

	// Base sword damage
	[SerializeField] private int baseDmg;

	// Sword damage
	[SerializeField] private int swordDmg;

	public int swordLevel;

	// The constant level modifier (occurs every level)
	[SerializeField] private int constLvlMod;

	// The constant level modifier (occurs every 10 levels)
	[SerializeField] private int constTenLvlMod;

	// Occurs once at level 50
	[SerializeField] private int lvl50Mod;

	// Occurs once at level 99
	[SerializeField] private int lvl99Mod;

	// Use this for initialization
	void Start () {
		// Initialize outside classes
		PDM = GetComponent<PlayerDamageMath>();

		// Initialize required variables
		swordKills = 0;
		baseDmg = 5;
		swordDmg = baseDmg;
		swordLevel = 1;
		constLvlMod = 2;
		constTenLvlMod = 5;
		lvl50Mod = 15;
		lvl99Mod = 30;
	}

	public void levelUp(){
		swordKills++;
		swordLevel++;
		swordDmg = PDM.getNewDmg(swordKills, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}

	/*public int SwordLevel(){
		return swordLevel;
	}*/

	public int getDamage(){
		return swordDmg;
	}

	public void levelUpPotion(int lU){
		swordKills += lU;
		swordLevel += lU;
		swordDmg = PDM.getNewDmg(swordKills, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}
}
