using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WeaponLevel))]
public class Magic : MonoBehaviour {
	// Number of magic kills
	[SerializeField] private int magicKills;

	// Gives access to WeaponLevel
	private WeaponLevel ML;

	// Use this for initialization
	void Start () {
		// Initialize ML
		ML = GetComponent<WeaponLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
