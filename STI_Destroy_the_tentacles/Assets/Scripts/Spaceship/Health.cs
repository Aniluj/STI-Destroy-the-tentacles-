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

	void Start () {
		initialLife = 100f;
		damageWhenSpecialMovementIsActive = 0;
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
