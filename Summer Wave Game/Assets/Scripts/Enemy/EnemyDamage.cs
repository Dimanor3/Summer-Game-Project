using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	// Damage
	[SerializeField] int dmg;

	public GameObject sword;

	public GameObject magicR;

	//private Sword sr;

	//private MagicUse mr;

	private int sl;

	private int ml;

	private int average;

	// Damage timer
	[SerializeField] int timer;
	[SerializeField] int resetTimer;

	// Use this for initialization
	void Start () {
		sword = GameObject.FindGameObjectWithTag ("Sword");
		magicR = GameObject.FindGameObjectWithTag ("MagicPool");
		//sr = sword.GetComponent<Sword> ().swordLevel;
		//mr = magicR.GetComponent<MagicUse> ().magicLevel;

		sl = sword.GetComponent<Sword> ().getSwordLevel();
		ml = magicR.GetComponent<MagicUse> ().getMagicLevel();
		//sl = sr.swordLevel;
		//ml = mr.magicLevel;

		average = (sl + ml) / 2;

		dmg = 15 + (average / 5);
		timer = 30;
		resetTimer = 30;
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
	}

	void OnCollisionEnter (Collision col){
		if(col.gameObject.tag == "Player" && timer <= 0){
			col.gameObject.GetComponent<PlayerController>().hurt(dmg);
			print("I work, yay!");
			timer = resetTimer;
		}
	}
}
