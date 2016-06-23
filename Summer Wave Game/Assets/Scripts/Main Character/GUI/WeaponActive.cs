using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponActive : MonoBehaviour {
	public void switchActive(bool sword){
		if (sword) {
			GameObject.Find ("SwordActive").GetComponent<Image>().enabled = true;
			GameObject.Find ("SwordLevel").GetComponent<Text>().enabled = true;
			GameObject.Find ("MagicActive").GetComponent<Image>().enabled = false;
			GameObject.Find ("MagicLevel").GetComponent<Text>().enabled = false;
		} else {
			GameObject.Find ("SwordActive").GetComponent<Image>().enabled = false;
			GameObject.Find ("SwordLevel").GetComponent<Text> ().enabled = false;
			GameObject.Find ("MagicActive").GetComponent<Image>().enabled = true;
			GameObject.Find ("MagicLevel").GetComponent<Text>().enabled = true;
		}
	}
}
