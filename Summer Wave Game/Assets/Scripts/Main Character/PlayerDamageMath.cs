using UnityEngine;
using System.Collections;

public class PlayerDamageMath : MonoBehaviour {
	// Base damage attack does
	[SerializeField] private int baseDmg;

	// New damage attack does after level up
	[SerializeField] private int newDmg;

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
		// Initialize new damage
		newDmg = 0;
	}

	public void setBaseDmg(int dmg){
		baseDmg = dmg;
	}

	public int getNewDmg(int level, int mod, int cL10M, int l50M, int l99M){
		newDmg += baseDmg + level * mod + (level / 10) * cL10M;

		if(level >= 50){
			newDmg += l50M;
		}

		if(level == 99){
			newDmg += l99M;
		}

		return newDmg;
	}
}
