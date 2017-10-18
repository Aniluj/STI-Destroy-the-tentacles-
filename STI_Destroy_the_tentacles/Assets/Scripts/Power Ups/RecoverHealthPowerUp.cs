using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverHealthPowerUp : MonoBehaviour {

	public Slider healthBar;
	public float healthToIncrement;

	void OnMouseDown(){
		healthBar.value += healthToIncrement;
		gameObject.SetActive (false);
	}
}
