using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	private bool firstShot;
	private float timer;
	private string upgradeOfShotKey = "upgradeOfShot";
	private int upgradeOfShotIsActive;
	public bool isOverHeated;
	public float cooldown;
	public GameObject[] bullet;
	public Transform shootingPoint;
	public Transform shootingPoint2;
	public Transform shootingPointOfTheUpgrade;
	public Transform shootingPointOfTheUpgrade2;
	public Transform shootingPointOfTheUpgrade3;
	public bool shooting;
	public JoystickButton joystickButton;



	void Start () {
		firstShot = true;
		shooting = false;
		isOverHeated = false;
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey);
		//if (upgradeOfShotIsActive == 1) {
		//	shootingPoint = shootingPointOfTheUpgrade;
		//}
	}

	void Update () {
		timer += Time.deltaTime;
		bool isButtonPressed = (Input.GetButton("Fire") || joystickButton.IsPressed) ? true : false;

		if (isButtonPressed && (firstShot || timer > cooldown) && isOverHeated == false && Time.timeScale == 1) {
			timer = 0;
			firstShot = false;
			for (int j = 0; j < 3; j++) {
				for (int i = 0; i < 30; i++) {
					if (upgradeOfShotIsActive == 0) {
						if (bullet [i].activeInHierarchy == false) {
							if (j == 0) {
								bullet [i].transform.SetPositionAndRotation (shootingPoint.position, shootingPoint.rotation);
								bullet [i].SetActive (true);
								break;
							}
							if (j == 1) {
								bullet [i].transform.SetPositionAndRotation (shootingPoint2.position, shootingPoint2.rotation);
								bullet [i].SetActive (true);
								break;
							}
						}
					} else if (upgradeOfShotIsActive == 1) {
						if (bullet [i].activeInHierarchy == false) {
							if (j == 0) {
								bullet [i].transform.SetPositionAndRotation (shootingPointOfTheUpgrade.position, shootingPointOfTheUpgrade.rotation);
								bullet [i].SetActive (true);
								break;
							}
							if (j == 1) {
								bullet [i].transform.SetPositionAndRotation (shootingPointOfTheUpgrade2.position, shootingPointOfTheUpgrade2.rotation);
								bullet [i].SetActive (true);
								break;
							}
							if (j == 2) {
								bullet [i].transform.SetPositionAndRotation (shootingPointOfTheUpgrade3.position, shootingPointOfTheUpgrade3.rotation);
								bullet [i].SetActive (true);
								break;
							}
						}
					}
				}
				if (upgradeOfShotIsActive != 1 && j == 1) {
					break;
				}
			}
			shooting = true;
		} else {
			shooting = false;
		}
	}
}
