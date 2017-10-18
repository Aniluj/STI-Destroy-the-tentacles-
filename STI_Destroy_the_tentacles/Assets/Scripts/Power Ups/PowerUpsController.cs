using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {

	public GameObject[] powerUps;
	public Transform[] spawnPointsForPowerUps;
	public float timeToSpawnAPowerUp;
	public float velocity;
	private bool movementActive;
	private float timer;
	private int numberOfSpawn;
	private int numberOfPowerUp;

	void Start(){
		movementActive = false;
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeToSpawnAPowerUp) {
			timer = 0;
			numberOfPowerUp = Random.Range (0, 3);
			numberOfSpawn = Random.Range (0, 3);
			movementActive = true;
			powerUps [numberOfPowerUp].transform.position = spawnPointsForPowerUps [numberOfSpawn].transform.position;
			powerUps [numberOfPowerUp].SetActive (true);
		}
		if (movementActive) {
			powerUps [numberOfPowerUp].transform.Translate (Vector3.up * velocity * Time.deltaTime);
		}
	  }
   }