using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour {

	public float necessaryTimeToObtainPoints;
	public int pointsObtainedByTime;
	//public Text scoreText;
	public Health health;
	public ShieldHealth shieldHealth;
	public TextMeshProUGUI scoretext;
	private string accumulatedPointsKey = "accumulatedPoints";
	private int totalAccumulatedScore;
	private int score = 0;
	private float timer = 0;

	void Start () {
		totalAccumulatedScore = PlayerPrefs.GetInt (accumulatedPointsKey, 0);
	}
	

	void Update () {
		timer += Time.deltaTime;
		scoretext.text = score.ToString();

		if (timer >= necessaryTimeToObtainPoints) {
			timer = 0;
			score += pointsObtainedByTime;
		}
		if (health.health <= 0 || shieldHealth.health <= 0) {
			PlayerPrefs.SetInt (accumulatedPointsKey, totalAccumulatedScore + score);
		}
	}
}
