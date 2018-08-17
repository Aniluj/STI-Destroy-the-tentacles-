using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PowerUpsController : MonoBehaviour {

	public GameObject[] powerUps;
	public Transform[] spawnPointsForPowerUps;
	public Transform[] positionOfTheKeyToPress;
	public float timeToSpawnAPowerUp;
	public float velocity;
	public float maxTimeInMovement;
	public TextMeshProUGUI keyToPress;
	public string[] keycodes;
	private Color32 slowdownPowerUpColor = new Color(0.08f, 0.36f, 0.74f);
	private Color32 explosionPowerUpColor = Color.red;
	private Color32 recoverySpaceshipHealthPowerUpColor = new Color(0.96f, 0.94f, 0.30f);
	private Color32 recoveryContentionShieldHealthPowerUpColor = new Color(0f, 0.92f, 0.88f);
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
	private bool _powerUpWasTouched = false;

	void Start(){
		movementActive = false;
		//for (int i = 0; i < powerUps.Length; i++) {
		//	positionOfTheKeyToPress[i] = powerUps [i].transform.GetChild (0).GetComponent<Transform> ();
		//}
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeToSpawnAPowerUp) {
			numberOfPositionOfTheKeyCode = Random.Range (0, keycodes.Length);
			realKeyCode = (KeyCode) Enum.Parse (typeof(KeyCode), keycodes [numberOfPositionOfTheKeyCode]);
			string text = keycodes [numberOfPositionOfTheKeyCode];
			#if UNITY_ANDROID
			text = "";
			#endif
			keyToPress.text = text;
			timer = 0;
			timeInMovement = 0;
			numberOfPowerUp = Random.Range (0, 4);
			numberOfSpawn = Random.Range (0, 4);
			typeOfMovement = Random.Range (1, 3);
			movementActive = true;
			powerUps [numberOfPowerUp].transform.position = spawnPointsForPowerUps [numberOfSpawn].transform.position;
			keyToPress.transform.position = positionOfTheKeyToPress [numberOfPowerUp].transform.position;
			powerUps [numberOfPowerUp].SetActive (true);
			keyToPress.gameObject.SetActive (true);
		}
		if (movementActive) {
			timeInMovement += Time.deltaTime;
			keyToPress.transform.position = positionOfTheKeyToPress [numberOfPowerUp].transform.position;
			if (powerUps [numberOfPowerUp].name == "Recover spaceship health power up") {
				keyToPress.color = recoverySpaceshipHealthPowerUpColor;
			}
			if (powerUps [numberOfPowerUp].name == "Recover shield health power up") {
				keyToPress.color = recoveryContentionShieldHealthPowerUpColor;
			}
			if (powerUps [numberOfPowerUp].name == "Slowdown power up") {
				keyToPress.color = slowdownPowerUpColor;
			}
			if (powerUps [numberOfPowerUp].name == "Explosion power up") {
				keyToPress.color = explosionPowerUpColor;
			}
			if (Input.GetKeyDown (realKeyCode) || _powerUpWasTouched) {
				_powerUpWasTouched = false;
				
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
				powerUps [numberOfPowerUp].transform.Translate (spawnPointsForPowerUps [numberOfSpawn].up * velocity * Time.deltaTime);
			}
			if (typeOfMovement == right) {
				powerUps [numberOfPowerUp].transform.Translate (spawnPointsForPowerUps [numberOfSpawn].right * velocity * Time.deltaTime);
			}
		}
	  }

	public void NotifyPowerUpTouch()
	{
		_powerUpWasTouched = true;
	}
	
   }