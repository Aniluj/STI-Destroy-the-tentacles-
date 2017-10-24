﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMovement : MonoBehaviour {

	private SpaceshipMovement normalMovement;
	private bool shiftEnabled;
	private bool firstTimeUse;
	private bool specialMovementActivated;
	private float timer;
	private Rigidbody2D spaceship;
	private float horizontalAxis;
	private float timeInMovement;
	private Health healthSystem;
	public Transform objectToRotateAround;
	public float cooldown;
	public float specialVelocity;
	public float limitOfTimeInMovement;


	void Awake (){
		spaceship = GetComponent<Rigidbody2D> ();
		normalMovement = GetComponent<SpaceshipMovement> ();
		healthSystem = GetComponent<Health> ();
	}

	void Start () {
		firstTimeUse = true;
	}

	void Update () {
		timer += Time.deltaTime;
		horizontalAxis = Input.GetAxisRaw ("Horizontal") * -1f;

		if (timer > cooldown || firstTimeUse) {
			shiftEnabled = true;
			firstTimeUse = false;
		}

		if (specialMovementActivated && timeInMovement < limitOfTimeInMovement) {
			normalMovement.enabled = false;
			timeInMovement += Time.deltaTime;
			healthSystem.damage = healthSystem.damageWhenSpecialMovementIsActive;
			SpaceshipMovement.RotateAround (objectToRotateAround.position, specialVelocity * horizontalAxis * Time.deltaTime, spaceship);
		} else {
			normalMovement.enabled = true;
			healthSystem.damage = healthSystem.damageReceived;
		}

		if (shiftEnabled && Input.GetKeyDown (KeyCode.LeftShift)) {
			shiftEnabled = false;
			specialMovementActivated = true;
			timer = 0;
			timeInMovement = 0;
		}
	}
}