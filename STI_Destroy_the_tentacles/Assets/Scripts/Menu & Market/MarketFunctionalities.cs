﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketFunctionalities : MonoBehaviour {

	public int priceOfTheUpgrade;
	public CanvasGroup[] panels;
	private TextMeshProUGUI priceText;
	private string accumulatedPointsKey = "accumulatedPoints";
	private int totalAccumulatedScore;
	private string enablingDisablingSFXKeY = "enablingDisablingSFX";
	private string enablingDisablingMusicKey = "enablingDisablingMusic";
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private string upgradeOfShotKey = "upgradeOfShot";
	private GeneralFunctionalitiesForScenes generalFunctionalitiesScript;


	void Awake(){
		priceText = GetComponentInChildren<TextMeshProUGUI> ();
		generalFunctionalitiesScript = GetComponent<GeneralFunctionalitiesForScenes> ();
	}

	void Start () {
		if (gameObject.tag == "Price") {
			priceText.text = priceOfTheUpgrade.ToString ();
		}
		totalAccumulatedScore = PlayerPrefs.GetInt (accumulatedPointsKey);
	}

	void Update(){
		if (gameObject.tag == "Price") {
			if (PlayerPrefs.GetInt (accumulatedPointsKey) >= priceOfTheUpgrade) {
				generalFunctionalitiesScript.enableToChange = true;
			} else {
				generalFunctionalitiesScript.enableToChange = false;
			}
		}
	}

	public void buyUpgrade(){
		if (PlayerPrefs.GetInt (accumulatedPointsKey) >= priceOfTheUpgrade) {
			PlayerPrefs.SetInt (accumulatedPointsKey, totalAccumulatedScore - priceOfTheUpgrade);
			if (transform.parent.name == "Upgrade of health") {
				PlayerPrefs.SetInt (upgradeOfHealthKey, 1);
			}else if (transform.parent.name == "Upgrade of shield health") {
				PlayerPrefs.SetInt (upgradeOfShieldHealthKey, 1);
			}else if (transform.parent.name == "Upgrade of shot") {
				PlayerPrefs.SetInt (upgradeOfShotKey, 1);
			}
			//transform.parent.gameObject.SetActive (false);
		}
	}

	public void resetPlayerprefs(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt (enablingDisablingSFXKeY, 1);
		PlayerPrefs.SetInt (enablingDisablingMusicKey, 1);
		for (int i = 0; i < panels.Length; i++) {
			panels [i].interactable = true;
			panels [i].blocksRaycasts = true;
			panels [i].alpha = 1;
		}
	}
}
