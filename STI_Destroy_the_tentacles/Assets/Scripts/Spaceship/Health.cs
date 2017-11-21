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
	public float initialLife;
	private int upgradeOfHealthIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private SpriteRenderer spriteRendererOfTheSpaceship;

	void Awake(){
		spriteRendererOfTheSpaceship = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		if (upgradeOfHealthIsActive == 1) {
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
			SceneManager.LoadScene ("Market");
		}
		if (healthBar.value >= 0 && healthBar.value <= initialLife/2) {
			spriteRendererOfTheSpaceship.color = Color.red;
		}
		if(healthBar.value <= initialLife && healthBar.value > initialLife/2){
			spriteRendererOfTheSpaceship.color = Color.white;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.tag == "Tentacle") {
			healthBar.value -= damage;
		}
	}
}
