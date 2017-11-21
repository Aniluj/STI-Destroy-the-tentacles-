using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverHealthPowerUp : MonoBehaviour {

	public Slider healthBar;
	public float healthToIncrement;
	public bool isActive = false;

	void Update(){
		if (isActive) {
			healthBar.value += healthToIncrement;
			isActive = false;
			gameObject.SetActive (false);
		}
	}
}
