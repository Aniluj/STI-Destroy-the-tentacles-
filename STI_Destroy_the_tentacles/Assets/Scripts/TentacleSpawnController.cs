using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawnController : MonoBehaviour {

	public GameObject[] easyTentacleSpawnPoints;
	public GameObject[] tentacles;
	public float cooldownOfEasyTentacleSpawn;
	private int numberOfEasySpawnToSpawnATentacle;
	private float timer;
	private bool activateEasySpawn = false;
	private SpriteMask tentacleSpriteMask;
	private SpriteRenderer tentacleRenderer;


	void Start () {
		for (int i = 0; i < tentacles.Length; i++) {
			tentacleSpriteMask = tentacles [i].transform.GetChild (1).GetComponent<SpriteMask> ();
			tentacleRenderer = tentacles [i].transform.GetChild (0).GetComponent<SpriteRenderer> ();
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

			//Collider2D hitForTentacles;
			RaycastHit2D hitForTentacles;
			numberOfEasySpawnToSpawnATentacle = Random.Range (0, easyTentacleSpawnPoints.Length);
			//hitForTentacles = Physics2D.OverlapCircle (easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position, 0.09f);
			hitForTentacles = Physics2D.Raycast (easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position, easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.forward * -1f);

			if (hitForTentacles.collider.gameObject.tag != "Tentacle") {
				for (int i = 0; i < tentacles.Length; i++) {
					if (tentacles [i].activeInHierarchy == false) {
						//Debug.Log ("asd");
						activateEasySpawn = false;
						timer = 0;
						//tentacles [i].transform.position = easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position;
						tentacles [i].transform.position = new Vector3(easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position.x, easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position.y, 0.5f);
						tentacles [i].transform.rotation = easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.localRotation;
						//tentacles [i].transform.SetPositionAndRotation (easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.position, easyTentacleSpawnPoints [numberOfEasySpawnToSpawnATentacle].transform.localRotation);
						tentacles [i].SetActive (true);
						break;
					}
				}
			}
		}
	}
}
