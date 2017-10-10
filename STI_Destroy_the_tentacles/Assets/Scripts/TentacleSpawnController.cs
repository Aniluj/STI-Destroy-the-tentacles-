using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawnController : MonoBehaviour {

	public GameObject[] easyTentacleSpawnPoints;
	public GameObject[] tentacles;
	public bool[] areEasySpawnPointsActive;
	public float cooldownOfEasyTentacleSpawn;
	private TentacleProperties[] individualTentacleProperties;
	private int numberOfEasySpawnToSpawnATentacle;
	private float timer;
	private bool activateEasySpawn = false;
	private SpriteMask tentacleSpriteMask;
	private SpriteRenderer tentacleRenderer;


	void Start () {
		areEasySpawnPointsActive = new bool[easyTentacleSpawnPoints.Length];
		individualTentacleProperties = new TentacleProperties[tentacles.Length];
		for (int i = 0; i < tentacles.Length; i++) {
			tentacleSpriteMask = tentacles [i].transform.GetChild (1).GetComponent<SpriteMask> ();
			tentacleRenderer = tentacles [i].transform.GetChild (0).GetComponent<SpriteRenderer> ();
			individualTentacleProperties [i] = tentacles [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
			areEasySpawnPointsActive [i] = true;
			tentacleSpriteMask.isCustomRangeActive = true;
			tentacleSpriteMask.frontSortingOrder = i + 1;
			tentacleSpriteMask.backSortingOrder = i;
			tentacleRenderer.sortingOrder = i + 1;
		}
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer > cooldownOfEasyTentacleSpawn) {
			activateEasySpawn = true;
		}

		if (activateEasySpawn) {
			numberOfEasySpawnToSpawnATentacle = Random.Range (0, easyTentacleSpawnPoints.Length);
			if (areEasySpawnPointsActive [numberOfEasySpawnToSpawnATentacle]) {
				for (int i = 0; i < tentacles.Length; i++) {
					if (tentacles [i].activeInHierarchy == false) {
						areEasySpawnPointsActive[numberOfEasySpawnToSpawnATentacle] = false;
						activateEasySpawn = false;
						timer = 0;
						tentacles [i].transform.position = new Vector3 (easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position.x, easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position.y, 0.5f);
						tentacles [i].transform.rotation = easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.localRotation;
						tentacles [i].SetActive (true);
						individualTentacleProperties[i].numberOfSpawnWhereIsTheTentacle = numberOfEasySpawnToSpawnATentacle;
						break;
					}
				}
			}
		}
	}
}
