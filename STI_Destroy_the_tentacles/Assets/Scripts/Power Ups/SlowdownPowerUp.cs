using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownPowerUp : MonoBehaviour {

	private GameObject[] tentaclesOnScreen;
	private TentacleProperties propertiesOfTheTentacle;

	void OnMouseDown(){
		tentaclesOnScreen = GameObject.FindGameObjectsWithTag ("Tentacle's father");
		for (int i = 0; i < tentaclesOnScreen.Length; i++) {
			propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			propertiesOfTheTentacle.movementAnimation.SetFloat ("runMultiplier", 0.1f);
		}
		gameObject.SetActive (false);
	}
}
