using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour{
	private float fillAmount;
	[SerializeField] private float lerpSpeed;

	[SerializeField] Image health;

	[SerializeField] private Text valueText;

	[SerializeField] private Color fullColor;
	[SerializeField] private Color lowColor;

	// Decide value of bar
	public float MaxValue {get; set;}

	void Start(){
		lerpSpeed = 2f;
	}

	// Sets value of bar
	public float Value{
		set{
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp [0] + ": " + value;
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	// Update is called once per frame
	void Update(){
		HandleBar();
	}

	private void HandleBar(){
		if(fillAmount != health.fillAmount){
			health.fillAmount = Mathf.Lerp(health.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
