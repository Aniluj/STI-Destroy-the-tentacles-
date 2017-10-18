using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPowerUp : MonoBehaviour {

	private GameObject[] tentaclesOnScreen;
	private TentacleProperties propertiesOfTheTentacle;

	void OnMouseDown(){
		tentaclesOnScreen = GameObject.FindGameObjectsWithTag("Tentacle's father");
		for (int i = 0; i < tentaclesOnScreen.Length; i++) {
			tentaclesOnScreen [i].SetActive (false);
			propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			propertiesOfTheTentacle.tentacleSpawnController.areEasySpawnPointsActive [propertiesOfTheTentacle.numberOfSpawnWhereIsTheTentacle] = true;
		}
		gameObject.SetActive (false);
	}
}
