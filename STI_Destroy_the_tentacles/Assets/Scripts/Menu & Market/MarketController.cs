using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketController : MonoBehaviour {

	public GameObject upgradeOfHealth;
	public GameObject upgradeOfShieldHealth;
	public GameObject upgradeOfShot;
	public TextMeshProUGUI totalAccumulatedScore;
	private int upgradeOfHealthIsActive;
	private int upgradeOfShieldHealthIsActive;
	private int upgradeOfShotIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private string upgradeOfShotKey = "upgradeOfShot";
	private string accumulatedPointsKey = "accumulatedPoints";

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey, 0);
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey, 0);
		upgradeOfShieldHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey, 0);
		if (upgradeOfHealthIsActive == 1){
			upgradeOfHealth.SetActive (false);
		} else{
			upgradeOfHealth.SetActive (true);
		}
		if (upgradeOfShotIsActive == 1){
			upgradeOfShot.SetActive (false);
		} else{
			upgradeOfShot.SetActive (true);
		}
		if (upgradeOfShieldHealthIsActive == 1){
			upgradeOfShieldHealth.SetActive (false);
		} else{
			upgradeOfShieldHealth.SetActive (true);
		}
	}
	

	void Update () {
		totalAccumulatedScore.text = PlayerPrefs.GetInt (accumulatedPointsKey).ToString ();
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey);
		upgradeOfShieldHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey);


		//if (upgradeOfHealthIsActive == 1){
		//	upgradeOfHealth.SetActive (false);
		//} else{
		//	upgradeOfHealth.SetActive (true);
		//}
		//if (upgradeOfShotIsActive == 1){
		//	upgradeOfShot.SetActive (false);
		//} else{
		//	upgradeOfShot.SetActive (true);
		//}
		//if (upgradeOfShieldHealthIsActive == 1){
		//	upgradeOfShieldHealth.SetActive (false);
		//} else{
		//	upgradeOfShieldHealth.SetActive (true);
		//}
	}
}
