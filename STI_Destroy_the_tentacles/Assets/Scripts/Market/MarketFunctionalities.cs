using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketFunctionalities : MonoBehaviour {

	public int priceOfTheUpgrade;
	public GameObject[] panels;
	private Text priceText;
	private string accumulatedPointsKey = "accumulatedPoints";
	private int totalAccumulatedScore;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private string upgradeOfShotKey = "upgradeOfShot";


	void Awake(){
		priceText = GetComponentInChildren<Text> ();
	}

	void Start () {
		if (gameObject.tag == "Price") {
			priceText.text = priceOfTheUpgrade.ToString ();
		}
		totalAccumulatedScore = PlayerPrefs.GetInt (accumulatedPointsKey);
	}

	public void buyUpgrade(){
		if (PlayerPrefs.GetInt (accumulatedPointsKey) >= priceOfTheUpgrade) {
			PlayerPrefs.SetInt (accumulatedPointsKey, totalAccumulatedScore - priceOfTheUpgrade);
			if (transform.parent.name == "Upgrade of health") {
				PlayerPrefs.SetInt (upgradeOfHealthKey, 1);
			}
			if (transform.parent.name == "Upgrade of shield health") {
				PlayerPrefs.SetInt (upgradeOfShieldHealthKey, 1);
			}
			if (transform.parent.name == "Upgrade of shot") {
				PlayerPrefs.SetInt (upgradeOfShotKey, 1);
			}
			transform.parent.gameObject.SetActive (false);
		}
	}

	public void resetPlayerprefs(){
		PlayerPrefs.DeleteAll ();
		for (int i = 0; i < panels.Length; i++) {
			panels [i].SetActive (true);
		}
	}
}
