using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoveryHealthPowerUp : MonoBehaviour {

	//public Slider healthBar;
	public Health spaceshipHealthScript;
	public ShieldHealth contentionShieldHealthScript;
	public int healthToIncrement;
	public bool isActive = false;
	public bool isRecoveryForSpaceship;
	public bool isRecoveryForContentionShield;

	void Update(){
		if (isActive) {
			if (isRecoveryForSpaceship) {
				spaceshipHealthScript.health += healthToIncrement;
			}
			if (isRecoveryForContentionShield) {
				contentionShieldHealthScript.health += healthToIncrement;
			}
			isActive = false;
			gameObject.SetActive (false);
		}
	}
}
