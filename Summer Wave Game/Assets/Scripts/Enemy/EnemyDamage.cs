using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	// Base damage attack does
	[SerializeField] private int baseDmg;

	// New damage attack does after level up
	[SerializeField] private int newDmg;

	// The constant level modifier (occurs every level)
	[SerializeField] private int constLvlMod;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
