using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawnController : MonoBehaviour {

	public GameObject[] easyTentacleSpawnPoints;
	public GameObject[] mediumTentacleSpawnPoints;
	public GameObject[] hardTentacleSpawnPoints;
	public GameObject[] tentacles;
	public bool[] areEasySpawnPointsActive;
	public bool[] areMediumSpawnPointsActive;
	public bool[] areHardSpawnPointsActive;
	public float cooldownOfEasyTentacleSpawn;
	public float cooldownOfMediumTentacleSpawn;
	public float cooldownOfHardTentacleSpawn;
	public float cooldownToActivateTimerForMediumSpawns;
	public float cooldownToActivateTimerForHardSpawns;
	public string idForEasySpawns = "easy";
	public string idForMediumSpawns = "medium";
	public string idForHardSpawns = "hard";
	private TentacleProperties[] individualTentacleProperties;
	private int numberOfEasySpawnToSpawnATentacle;
	private int numberOfMediumSpawnToSpawnATentacle;
	private int numberOfHardSpawnToSpawnATentacle;
	private float generalTimer;
	private float timerForEasySpawns;
	private float timerForMediumSpawns;
	private float timerForHardSpawns;
	private bool activateEasySpawn = false;
	private bool activateMediumSpawn = false;
	private bool activateHardSpawn = false;
	private SpriteMask tentacleSpriteMask;
	private SpriteRenderer tentacleRenderer;
	private SpriteRenderer frontMiniVortexRenderer;


	void Start () {
		areEasySpawnPointsActive = new bool[easyTentacleSpawnPoints.Length];
		areMediumSpawnPointsActive = new bool[mediumTentacleSpawnPoints.Length];
		areHardSpawnPointsActive = new bool[hardTentacleSpawnPoints.Length];
		individualTentacleProperties = new TentacleProperties[tentacles.Length];

		for (int i = 0; i < tentacles.Length; i++) {
			tentacleSpriteMask = tentacles [i].transform.GetChild (1).GetComponent<SpriteMask> ();
			tentacleRenderer = tentacles [i].transform.GetChild (0).GetComponent<SpriteRenderer> ();
			frontMiniVortexRenderer = tentacles [i].GetComponent<SpriteRenderer> ();
			individualTentacleProperties [i] = tentacles [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			if (areEasySpawnPointsActive.Length>i) {
				areEasySpawnPointsActive [i] = true;
			}
			if (areMediumSpawnPointsActive.Length > i) {
				areMediumSpawnPointsActive [i] = true;
			}
			if (areHardSpawnPointsActive.Length > i) {
				areHardSpawnPointsActive [i] = true;
			}
			tentacleSpriteMask.isCustomRangeActive = true;
			tentacleSpriteMask.frontSortingOrder = i + 1;
			tentacleSpriteMask.backSortingOrder = i;
			tentacleRenderer.sortingOrder = i + 1;
			frontMiniVortexRenderer.sortingOrder = tentacleRenderer.sortingOrder + 1;
		}
	}

	void Update () {
		generalTimer += Time.deltaTime;
		timerForEasySpawns += Time.deltaTime;

	
		if (timerForEasySpawns > cooldownOfEasyTentacleSpawn) {
			activateEasySpawn = true;
		}


		if(generalTimer >= cooldownToActivateTimerForMediumSpawns){
			timerForMediumSpawns += Time.deltaTime;
		}
		if(timerForMediumSpawns > cooldownOfMediumTentacleSpawn){
			activateMediumSpawn = true;
		}


		if(generalTimer >= cooldownToActivateTimerForHardSpawns){
			timerForHardSpawns += Time.deltaTime;
		}
		if(timerForHardSpawns > cooldownOfHardTentacleSpawn){
			activateHardSpawn = true;
		}

			
		if (activateEasySpawn) {
			timerForEasySpawns = 0;
			spawnTentacles (tentacles, easyTentacleSpawnPoints, areEasySpawnPointsActive, individualTentacleProperties, numberOfEasySpawnToSpawnATentacle, idForEasySpawns);
			activateEasySpawn = false;
		}
		if(activateMediumSpawn){
			timerForMediumSpawns = 0;
			spawnTentacles(tentacles, mediumTentacleSpawnPoints, areMediumSpawnPointsActive, individualTentacleProperties, numberOfMediumSpawnToSpawnATentacle, idForMediumSpawns);
			activateMediumSpawn = false;
		}
		if(activateHardSpawn){
			timerForHardSpawns = 0;
			spawnTentacles(tentacles, hardTentacleSpawnPoints, areHardSpawnPointsActive, individualTentacleProperties, numberOfHardSpawnToSpawnATentacle, idForHardSpawns);
			activateHardSpawn = false;
		}
	}

	private void spawnTentacles(GameObject[] tentacles, GameObject[] tentacleSpawnPoints, bool[] areSpawnPointsActive, TentacleProperties[] individualTentaclesProperties, int numberOfSpawnToSpawnATentacle, string idForSpawns){
		numberOfSpawnToSpawnATentacle = Random.Range (0, tentacleSpawnPoints.Length);
		for (int i = numberOfSpawnToSpawnATentacle; i < tentacleSpawnPoints.Length; i++) {
			if (areSpawnPointsActive [i] == true) {
				numberOfSpawnToSpawnATentacle = i;
				break;
			} else {
				i = Random.Range (0, tentacleSpawnPoints.Length);
			}
		}
		if (areSpawnPointsActive [numberOfSpawnToSpawnATentacle]) {
			for (int i = 0; i < tentacles.Length; i++) {
				if (tentacles [i].activeInHierarchy == false) {
					areSpawnPointsActive[numberOfSpawnToSpawnATentacle] = false;
					tentacles [i].transform.position = new Vector3 (tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.position.x, tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.position.y, 0.5f);
					tentacles [i].transform.rotation = tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.rotation;
					tentacles [i].SetActive (true);
					individualTentacleProperties [i].typeOfSpawnWhereIsTheTentacle = idForSpawns;
					individualTentacleProperties[i].numberOfSpawnWhereIsTheTentacle = numberOfSpawnToSpawnATentacle;
					break;
				}
			}
		}
	}
}
