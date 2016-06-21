using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<PlayerController>().getHealth() <= 0){
			SceneManager.LoadScene(0);
		}
	}
}
