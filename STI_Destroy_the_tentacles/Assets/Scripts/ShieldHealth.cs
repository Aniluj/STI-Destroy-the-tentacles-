﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShieldHealth : MonoBehaviour {

	public Slider shieldHealthBar;
	public int damageReceived;
	private int initialLife;
	private int upgradeHealthIsActive;
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";

	void Start () {
		upgradeHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey);
		Debug.Log (upgradeHealthIsActive);
		if (upgradeHealthIsActive == 0) {
			initialLife = 175;
		} else if (upgradeHealthIsActive == 1) {
			initialLife = 100;
		}
		shieldHealthBar.maxValue = initialLife;
		shieldHealthBar.value = initialLife;
	}
	
	void Update(){
		if (shieldHealthBar.value <= 0) {
			SceneManager.LoadScene ("Menu");
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Tentacle") {
			shieldHealthBar.value -= damageReceived;
		}
	}
}
