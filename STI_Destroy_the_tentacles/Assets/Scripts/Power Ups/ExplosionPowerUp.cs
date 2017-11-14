using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPowerUp : MonoBehaviour {

	private GameObject[] tentaclesOnScreen;
	private TentacleProperties propertiesOfTheTentacle;
	public string[] keycodes;

	void Start(){
		for (int i = 0; i < keycodes.Length; i++) {
			
		}
	}

	void OnMouseDown(){
		tentaclesOnScreen = GameObject.FindGameObjectsWithTag("Tentacle's father");
		for (int i = 0; i < tentaclesOnScreen.Length; i++) {
			tentaclesOnScreen [i].SetActive (false);
			propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			propertiesOfTheTentacle.tentacleSpawnController.areEasySpawnPointsActive [propertiesOfTheTentacle.numberOfSpawnWhereIsTheTentacle] = true;
			if (propertiesOfTheTentacle.typeOfSpawnWhereIsTheTentacle == "medium") {
				propertiesOfTheTentacle.tentacleSpawnController.areMediumSpawnPointsActive [propertiesOfTheTentacle.numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (propertiesOfTheTentacle.typeOfSpawnWhereIsTheTentacle == "hard") {
				propertiesOfTheTentacle.tentacleSpawnController.areHardSpawnPointsActive [propertiesOfTheTentacle.numberOfSpawnWhereIsTheTentacle] = true;
			}
		}
		gameObject.SetActive (false);
	}
}
