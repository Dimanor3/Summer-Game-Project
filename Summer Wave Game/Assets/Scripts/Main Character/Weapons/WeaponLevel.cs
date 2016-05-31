using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDamageMath))]
public class WeaponLevel : MonoBehaviour {
	// Current weapon level
	[SerializeField] private int level;

	// Number of kills
	[SerializeField] private int kills;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
