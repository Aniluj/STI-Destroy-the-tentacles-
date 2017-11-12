using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	private bool firstShoot;
	private float timer;
	private string upgradeOfShotKey = "upgradeOfShot";
	private int upgradeOfShotIsActive;
	public bool isOverHeated;
	public float cooldown;
	public GameObject[] bullet;
	public Transform shootingPoint;
	public Transform shootingPointOfTheUpgrade;
	public bool shooting;



	void Start () {
		firstShoot = true;
		shooting = false;
		isOverHeated = false;
		upgradeOfShotIsActive = PlayerPrefs.GetInt (upgradeOfShotKey);
		if (upgradeOfShotIsActive == 0) {
			shootingPoint = shootingPointOfTheUpgrade;
		}
	}

	void Update () {
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire") && (firstShoot || timer > cooldown) && isOverHeated == false) {
			timer = 0;
			firstShoot = false;
			for (int i = 0; i < 20; i++) {
				if (bullet [i].activeInHierarchy == false) {
					bullet [i].transform.SetPositionAndRotation (shootingPoint.position, shootingPoint.rotation);
					bullet [i].SetActive (true);
					break;
				}
			}
			shooting = true;
		} else {
			shooting = false;
		}
	}
}
