using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {

	public GameObject[] powerUps;
	public Transform[] spawnPointsForPowerUps;
	public float timeToSpawnAPowerUp;
	public float velocity;
	public float maxTimeInMovement;
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
			timer = 0;
			timeInMovement = 0;
			numberOfPowerUp = Random.Range (0, 4);
			numberOfSpawn = Random.Range (0, 4);
			typeOfMovement = Random.Range (1, 3);
			movementActive = true;
			powerUps [numberOfPowerUp].transform.position = spawnPointsForPowerUps [numberOfSpawn].transform.position;
			powerUps [numberOfPowerUp].transform.rotation = spawnPointsForPowerUps [numberOfSpawn].transform.rotation;
			powerUps [numberOfPowerUp].SetActive (true);
		}
		if (movementActive) {
			timeInMovement += Time.deltaTime;

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