using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShieldHealth : MonoBehaviour {

	public Slider shieldHealthBar;
	public int damageReceived;
	public int initialLife;
	private int upgradeHealthIsActive;
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private SpriteRenderer spriteRendererOfTheShield;

	void Awake(){
		spriteRendererOfTheShield = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		upgradeHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey);
		Debug.Log (upgradeHealthIsActive);
		if (upgradeHealthIsActive == 1) {
			initialLife = 175;
		} else{
			initialLife = 100;
		}
		shieldHealthBar.maxValue = initialLife;
		shieldHealthBar.value = initialLife;
	}
	
	void Update(){
		if (shieldHealthBar.value <= 0) {
			SceneManager.LoadScene ("Market");
		}
		if (shieldHealthBar.value >= 0 && shieldHealthBar.value <= initialLife/2) {
			spriteRendererOfTheShield.color = Color.red;
		}
		if(shieldHealthBar.value <= initialLife && shieldHealthBar.value > initialLife/2){
			spriteRendererOfTheShield.color = Color.white;
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Tentacle") {
			shieldHealthBar.value -= damageReceived;
		}
	}
}
