using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WeaponLevel))]
public class Sword : MonoBehaviour {
	// Number of sword kills
	[SerializeField] private int swordKills;

	// Gives access to WeaponLevel
	private WeaponLevel SL;

	// Use this for initialization
	void Start () {
		SL = GetComponent<WeaponLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
