using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;
	public int spawnCount;
	public Transform target;
	public ProjPool enemyProjPool;

	private float timer = 0;
	public float timerDelay = 0.5f;
	private float globalTimer = 0;
	public float globalTimerDelay;
	private bool spawning = false;
	private int totalSpawn;
	private int counter;
	public EnemyLook[] badDudes; 


	// Use this for initialization
	void Start () {
		if (spawnCount <= 0) {
			spawnCount = 1;
		}
		badDudes = new EnemyLook[spawnCount * prefab.Length];
		for (int s = 0; s < prefab.Length; s++) {
			for (int i = s*spawnCount; i < (spawnCount + s*spawnCount); i++) {
				badDudes [i] = Instantiate (prefab[s], transform.position, Quaternion.identity, transform).GetComponentInChildren<EnemyLook> ();
				badDudes [i].SetTarget (target);
				badDudes [i].gameObject.GetComponent<Arsenal> ().SetAmmoPool (enemyProjPool);
			}
		}

		totalSpawn = spawnCount * prefab.Length;

	}
	
	// Update is called once per frame
	void Update () {
		if (globalTimer > 0) {
			globalTimer -= Time.deltaTime;
		}
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			spawning = true;
			}
		if (spawning) {
			if (globalTimer <= 0) {
				if (timer <= 0) {
					totalSpawn--;
					counter++;
					badDudes [totalSpawn].transform.parent.gameObject.SetActive (true);
					timer = timerDelay;
					if (counter == spawnCount) {
						globalTimer = globalTimerDelay;
						counter = 0;
					}
					Debug.Log (globalTimer);
				}
				if (totalSpawn == 0) {
					spawning = false;
				}
			}
		}
	}
}
