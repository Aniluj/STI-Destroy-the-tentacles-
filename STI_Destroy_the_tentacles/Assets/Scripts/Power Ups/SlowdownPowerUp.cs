using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownPowerUp : MonoBehaviour {

	private GameObject[] tentaclesOnScreen;
	private TentacleProperties propertiesOfTheTentacle;
	public bool isActive = false;

	void Update(){
		if (isActive) {
			tentaclesOnScreen = GameObject.FindGameObjectsWithTag ("Tentacle's father");
			for (int i = 0; i < tentaclesOnScreen.Length; i++) {
				propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
				propertiesOfTheTentacle.movementAnimation.SetFloat ("runMultiplier", 0.1f);
				propertiesOfTheTentacle.spriteRenderOfTheTentacle.color = Color.blue;
			}
			isActive = false;
			gameObject.SetActive (false);
		}
	}
}
