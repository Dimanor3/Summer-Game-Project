using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class Sword : MonoBehaviour {
	// Number of sword kills
	[SerializeField] private int swordKills;

	// Gives access to required outside classes
	private WeaponLevel SL;
	private PlayerDamageMath PDM;

	// Base sword damage
	[SerializeField] private int baseDmg;

	// Sword damage
	[SerializeField] private int swordDmg;

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
		SL = GetComponent<WeaponLevel>();
		PDM = GetComponent<PlayerDamageMath>();

		// Initialize required variables
		swordDmg = 0;
		swordKills = 0;
		baseDmg = 5;
		constLvlMod = 2;
		constTenLvlMod = 5;
		lvl50Mod = 15;
		lvl99Mod = 30;

		// Set Base Damage
		PDM.setBaseDmg(baseDmg);
	}
	
	// Update is called once per frame
	void Update () {
		swordDmg = PDM.getNewDmg(swordKills + 1, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}
}
