using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketController : MonoBehaviour {

	public GameObject upgradeOfHealth;
	public GameObject upgradeOfShieldHealth;
	public GameObject upgradeOfShot;
	public Text totalAccumulatedScore;
	private int upgradeOfHealthIsActive;
	private int upgradeOfShieldHealthIsActive;
	private int upgradeOfShotIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private string upgradeOfShotKey = "upgradeOfShot";
	private string accumulatedPointsKey = "accumulatedPoints";

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey, 1);
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey, 1);
		upgradeOfShieldHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey, 1);
	}
	

	void Update () {
		totalAccumulatedScore.text = PlayerPrefs.GetInt (accumulatedPointsKey).ToString ();

		if (upgradeOfHealthIsActive == 0) {
			upgradeOfHealth.SetActive (false);
		}
		if (upgradeOfShotIsActive == 0) {
			upgradeOfShot.SetActive (false);
		}
		if (upgradeOfShieldHealthIsActive == 0) {
			upgradeOfShieldHealth.SetActive (false);
		}
	}
}
