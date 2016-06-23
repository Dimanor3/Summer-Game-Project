using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveNumber : MonoBehaviour {

	private Spawner wave;
	[SerializeField] private Text valueText;

	// Use this for initialization
	void Start () {
		wave = GameObject.Find("Goblin").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
		valueText.text = "Wave: " + wave.getNumWaves();

		if(wave.getNumWaves() > 5){
			SceneManager.LoadScene(0);
		}
	}
}
