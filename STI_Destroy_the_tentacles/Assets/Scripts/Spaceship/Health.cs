using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public Slider healthBar;
	public int damageReceived;
	public int damageWhenSpecialMovementIsActive;
	public int damage;
	private float initialLife;
	private int upgradeOfHealthIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		if (upgradeOfHealthIsActive == 0) {
			initialLife = 175f;
		} else {
			initialLife = 100f;
		}
		damageWhenSpecialMovementIsActive = 0;
		healthBar.maxValue = initialLife;
		healthBar.value = initialLife;
	}
	
	void Update(){
		if (healthBar.value <= 0) {
			SceneManager.LoadScene ("Menu");
		}
	}

	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.tag == "Tentacle") {
			healthBar.value -= damage;
		}
	}
}
