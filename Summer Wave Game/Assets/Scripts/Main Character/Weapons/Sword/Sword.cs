using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	private int swordLevel;

	// The constant level modifier (occurs every level)
	[SerializeField] private int constLvlMod;

	// The constant level modifier (occurs every 10 levels)
	[SerializeField] private int constTenLvlMod;

	// Occurs once at level 50
	[SerializeField] private int lvl50Mod;

	// Occurs once at level 99
	[SerializeField] private int lvl99Mod;

	// Text to display level
	private Text displaySwordLevel;

	// Use this for initialization
	void Start () {
		// Initialize outside classes
		PDM = GetComponent<PlayerDamageMath>();

		// Initialize required variables
		swordKills = 0;
		baseDmg = 5;
		swordDmg = baseDmg;
		constLvlMod = 2;
		swordLevel = 1;
		constTenLvlMod = 5;
		lvl50Mod = 15;
		lvl99Mod = 30;

		displaySwordLevel = GameObject.Find ("SwordLevel").GetComponent<Text> ();
		displaySwordLevel.text = "Sword Level: " + swordLevel;
	}

	public void levelUp(){
		swordKills++;
		swordLevel++;
		swordDmg = PDM.getNewDmg(swordLevel, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
		displaySwordLevel.text = "Sword Level: " + swordLevel;
	}

	public int getSwordLevel(){
		return swordLevel;
	}

	public int getDamage(){
		return swordDmg;
	}

	public void levelUp(int lU){
		swordKills += lU;
		swordLevel += lU;
		swordDmg = PDM.getNewDmg(swordLevel, baseDmg, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
		displaySwordLevel.text = "Sword Level: " + swordLevel;
	}
}
