using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModifyTMPTextForHealthBars : MonoBehaviour {

	public Slider healthBar;
	public ShieldHealth shieldHealth;
	public Health health;
	private TextMeshProUGUI actualLife;

	void Awake(){
		actualLife = GetComponent<TextMeshProUGUI> ();
	}

	void Update () {
		if (shieldHealth != null) {
			actualLife.text = healthBar.value + "/" + shieldHealth.initialLife;
		} else if (health != null) {
			actualLife.text = healthBar.value + "/" + health.initialHealth;
		}
	}
}
