using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawnController : MonoBehaviour {

	public GameObject[] easyTentacleSpawnPoints;
	//public GameObject[] mediumTentacleSpawnPoints;
	//public GameObject[] hardTentacleSpawnPoints;
	public GameObject[] tentacles;
	public bool[] areEasySpawnPointsActive;
	//public bool[] areMediumSpawnPointsActive;
	//public bool[] areHardSpawnPointsActive;
	public float cooldownOfEasyTentacleSpawn;
	private TentacleProperties[] individualTentacleProperties;
	private int numberOfEasySpawnToSpawnATentacle;
	private int numberOfMediumSpawnToSpawnATentacle;
	private int numberOfHardSpawnToSpawnATentacle;
	private float timerForEasySpawns;
	private float timerForMediumSpawns;
	private float timerForHardSpawns;
	private bool activateEasySpawn = false;
	private bool activateMediumSpawn = false;
	private bool activateHardSpawn = false;
	private SpriteMask tentacleSpriteMask;
	private SpriteRenderer tentacleRenderer;


	void Start () {
		areEasySpawnPointsActive = new bool[easyTentacleSpawnPoints.Length];
		//areMediumSpawnPointsActive = new bool[mediumTentacleSpawnPoints.Length];
		//areHardSpawnPointsActive = new bool[hardTentacleSpawnPoints.Length];
		individualTentacleProperties = new TentacleProperties[tentacles.Length];
		for (int i = 0; i < tentacles.Length; i++) {
			tentacleSpriteMask = tentacles [i].transform.GetChild (1).GetComponent<SpriteMask> ();
			tentacleRenderer = tentacles [i].transform.GetChild (0).GetComponent<SpriteRenderer> ();
			individualTentacleProperties [i] = tentacles [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			if (areEasySpawnPointsActive.Length>i) {
				areEasySpawnPointsActive [i] = true;
			}
//			areMediumSpawnPointsActive [i] = true;
//			areHardSpawnPointsActive [i] = true;
			tentacleSpriteMask.isCustomRangeActive = true;
			tentacleSpriteMask.frontSortingOrder = i + 1;
			tentacleSpriteMask.backSortingOrder = i;
			tentacleRenderer.sortingOrder = i + 1;
		}
	}

	void Update () {
		timerForEasySpawns += Time.deltaTime;

		if (timerForEasySpawns > cooldownOfEasyTentacleSpawn) {
			activateEasySpawn = true;
		}

		if (activateEasySpawn) {
			timerForEasySpawns = 0;
			spawnTentacles (tentacles, easyTentacleSpawnPoints, areEasySpawnPointsActive, individualTentacleProperties, numberOfEasySpawnToSpawnATentacle);
			activateEasySpawn = false;
			Debug.Log ("spawnCall");
		}
	}

	private void spawnTentacles(GameObject[] tentacles, GameObject[] tentacleSpawnPoints, bool[] areSpawnPointsActive, TentacleProperties[] individualTentaclesProperties, int numberOfSpawnToSpawnATentacle){
		numberOfSpawnToSpawnATentacle = Random.Range (0, tentacleSpawnPoints.Length);
		if (areSpawnPointsActive [numberOfSpawnToSpawnATentacle]) {
			for (int i = 0; i < tentacles.Length; i++) {
				if (tentacles [i].activeInHierarchy == false) {
					areSpawnPointsActive[numberOfSpawnToSpawnATentacle] = false;
					tentacles [i].transform.position = new Vector3 (tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.position.x, tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.position.y, 0.5f);
					tentacles [i].transform.rotation = tentacleSpawnPoints [numberOfSpawnToSpawnATentacle].transform.localRotation;
					tentacles [i].SetActive (true);
					individualTentacleProperties[i].numberOfSpawnWhereIsTheTentacle = numberOfSpawnToSpawnATentacle;
					Debug.Log ("spawning");
					break;
				}
			}
		}
	}
}
