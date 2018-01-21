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
	public float initialHealth;
	public Sprite fullHealth;
	public Sprite halfHealth;
	public Sprite lowHealth;
	private int upgradeOfHealthIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private SpriteRenderer spriteRendererOfTheSpaceship;

	void Awake(){
		spriteRendererOfTheSpaceship = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		if (upgradeOfHealthIsActive == 1) {
			initialHealth = 175f;
		} else {
			initialHealth = 100f;
		}
		damageWhenSpecialMovementIsActive = 0;
		healthBar.maxValue = initialHealth;
		healthBar.value = initialHealth;
		spriteRendererOfTheSpaceship.sprite = fullHealth;
	}
	
	void Update(){
		if (healthBar.value <= 0) {
			SceneManager.LoadScene ("Market");
		}
		if (healthBar.value > 0 && initialHealth <= initialHealth / 4) {
			spriteRendererOfTheSpaceship.sprite = lowHealth;
		}
		if (healthBar.value > initialHealth/4 && healthBar.value <= initialHealth/2) {
			spriteRendererOfTheSpaceship.sprite = halfHealth;
		}
		if(healthBar.value <= initialHealth && healthBar.value > initialHealth/2){
			spriteRendererOfTheSpaceship.sprite = fullHealth;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.tag == "Tentacle") {
			healthBar.value -= damage;
		}
	}
}
