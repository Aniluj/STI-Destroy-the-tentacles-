using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {

	public IsThePowerUpClicked explosionPowerUp;
	public IsThePowerUpClicked slowdownPowerUp;
	private GameObject[] tentaclesOnScreen;
	private TentacleProperties propertiesOfTheTentacle;

		
	void Update () {
		if (slowdownPowerUp.isClicked) {
			slowdownPowerUp.isClicked = false;
			tentaclesOnScreen = GameObject.FindGameObjectsWithTag("Tentacle's father");
			for (int i = 0; i < tentaclesOnScreen.Length; i++) {
				propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
				propertiesOfTheTentacle.movementAnimation.SetFloat ("runMultiplier", 0.1f);
		}

		if (explosionPowerUp.isClicked) {
			Debug.Log ("entré");
			explosionPowerUp.isClicked = false;
			tentaclesOnScreen = GameObject.FindGameObjectsWithTag("Tentacle's father");
			for (int i = 0; i < tentaclesOnScreen.Length; i++) {
				tentaclesOnScreen [i].SetActive(false);
				propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
				propertiesOfTheTentacle.tentacleSpawnController.areEasySpawnPointsActive [propertiesOfTheTentacle.numberOfSpawnWhereIsTheTentacle] = true;
			}
		 }
	  }
   }
}