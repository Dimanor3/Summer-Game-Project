using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class Magic : MonoBehaviour {
	// Number of magic kills
	[SerializeField] private int magicKills;

	// Gives access to required outside classes
	private PlayerDamageMath PDM;
	private PlayerController PC;
	private MagicPooling MP;

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

	// Number of active fireballs
	[SerializeField] private int availableFireballs;

	// Fireball speed
	private float speed;

	// Use this for initialization
	void Start () {
		// Initialize outside classes
		PDM = GetComponent<PlayerDamageMath>();
		PC = GetComponent<PlayerController>();
		MP = GetComponent<MagicPooling>();

		// Initialize required variables
		magicDmg = 0;
		magicKills = 0;
		baseDmg = 10;
		constLvlMod = 1;
		constTenLvlMod = 10;
		lvl50Mod = 30;
		lvl99Mod = 50;
		availableFireballs = 0;
		speed = 5f;

		// Set Base Damage
		PDM.setBaseDmg(baseDmg);
	}

	void Update(){
		// Move the fireball
		transform.position += new Vector3(0f, 0f, speed);

		// Set the number of active fireballs
		availableFireballs = MP.getNumberOfAvailableFireballs();

		// Attack
		float attack = Input.GetAxisRaw("Fire1");

		// Use magic if possible
		if(!PC.getSword() && attack != 0 && availableFireballs != 0){
			MP.spawn(Vector3.zero, new Quaternion(0f, 0f, 0f, 0f));
		}

		/*
		if(availableFireballs == 0){
			MP.despawn(gameObject);
		}
		*/
	}

	/*
	void OnCollisionEnter(Collision col){
		if(col){
			MP.despawn(gameObject);
		}
	}
	*/

	public void levelUp(){
		magicKills++;
		magicDmg = PDM.getNewDmg(magicKills + 1, constLvlMod, constTenLvlMod, lvl50Mod, lvl99Mod);
	}

	public int getDamage(){
		return magicDmg;
	}
}
