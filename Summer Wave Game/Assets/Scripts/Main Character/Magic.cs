using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class Magic : MonoBehaviour {
	// Number of magic kills
	[SerializeField] private int magicKills;

	// Gives access to required outside classes
	private WeaponLevel ML;
	private PlayerDamageMath PDM;

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

	// Use this for initialization
	void Start () {
		// Initialize outside classes
		ML = GetComponent<WeaponLevel>();
		PDM = GetComponent<PlayerDamageMath>();

		// Initialize required variables
		magicDmg = 0;
		magicKills = 0;
		baseDmg = 10;
		constLvlMod = 1;
		constTenLvlMod = 10;
		lvl50Mod = 30;
		lvl99Mod = 50;

		// Set Base Damage
		PDM.setBaseDmg(baseDmg);
	}
	
	// Update is called once per frame
	void Update () {
		magicDmg = PDM.getNewDmg(magicKills + 1, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}
}
