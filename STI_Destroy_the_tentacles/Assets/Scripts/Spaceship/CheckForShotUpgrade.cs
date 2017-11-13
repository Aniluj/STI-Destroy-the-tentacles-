using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForShotUpgrade : MonoBehaviour {

	private string upgradeOfShotKey = "upgradeOfShot";
	private int upgradeOfShotIsActive;
	private Shoot[] shootScriptsInSpaceship;

	void Start () {
		shootScriptsInSpaceship = GetComponents<Shoot> ();
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey);
		if (upgradeOfShotIsActive == 1) {
			for (int i = 0; i < shootScriptsInSpaceship.Length; i++) {
				shootScriptsInSpaceship [i].enabled = true;
			}
		}
	}
}
