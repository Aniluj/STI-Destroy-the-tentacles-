using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PowerUpsController : MonoBehaviour {

	public GameObject[] powerUps;
	public Transform[] spawnPointsForPowerUps;
	public float timeToSpawnAPowerUp;
	public float velocity;
	public float maxTimeInMovement;
	public TextMeshProUGUI keyToPress;
	public string[] keycodes;
	private ExplosionPowerUp explosionPowerUp;
	private RecoveryHealthPowerUp recoverHealtPowerUp;
	private SlowdownPowerUp slowdownPowerUp;
	private int numberOfPositionOfTheKeyCode;
	private KeyCode realKeyCode;
	private bool movementActive;
	private float timer;
	private int numberOfSpawn;
	private int numberOfPowerUp;
	private int typeOfMovement;
	private int up = 1;
	private int right = 2;
	private float timeInMovement;

	void Start(){
		movementActive = false;
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeToSpawnAPowerUp) {
			numberOfPositionOfTheKeyCode = Random.Range (0, keycodes.Length);
			realKeyCode = (KeyCode) Enum.Parse (typeof(KeyCode), keycodes [numberOfPositionOfTheKeyCode]);
			keyToPress.text = keycodes [numberOfPositionOfTheKeyCode];
			timer = 0;
			timeInMovement = 0;
			numberOfPowerUp = Random.Range (0, 4);
			numberOfSpawn = Random.Range (0, 4);
			typeOfMovement = Random.Range (1, 3);
			movementActive = true;
			powerUps [numberOfPowerUp].transform.position = spawnPointsForPowerUps [numberOfSpawn].transform.position;
			powerUps [numberOfPowerUp].transform.rotation = spawnPointsForPowerUps [numberOfSpawn].transform.rotation;
			keyToPress.transform.position = powerUps [numberOfPowerUp].transform.position;
			powerUps [numberOfPowerUp].SetActive (true);
			keyToPress.gameObject.SetActive (true);
		}
		if (movementActive) {
			timeInMovement += Time.deltaTime;
			keyToPress.transform.position = powerUps [numberOfPowerUp].transform.position;
			if (Input.GetKeyDown (realKeyCode)) {
				
				recoverHealtPowerUp = powerUps [numberOfPowerUp].GetComponent<RecoveryHealthPowerUp> ();
				if (recoverHealtPowerUp != null) {
					recoverHealtPowerUp.isActive = true;
				}

				slowdownPowerUp = powerUps [numberOfPowerUp].GetComponent<SlowdownPowerUp> ();
				if (slowdownPowerUp != null) {
					slowdownPowerUp.isActive = true;
				}

				explosionPowerUp = powerUps [numberOfPowerUp].GetComponent<ExplosionPowerUp> ();
				if (explosionPowerUp != null) {
					explosionPowerUp.isActive = true;
				}

				keyToPress.gameObject.SetActive (false);
			}
			if (timeInMovement >= maxTimeInMovement) {
				movementActive = false;
				powerUps [numberOfPowerUp].SetActive (false);
			}
			if (typeOfMovement == up) {
				powerUps [numberOfPowerUp].transform.Translate (Vector3.up * velocity * Time.deltaTime);
			}
			if (typeOfMovement == right) {
				powerUps [numberOfPowerUp].transform.Translate (Vector3.right * velocity * Time.deltaTime);
			}
		}
	  }
   }