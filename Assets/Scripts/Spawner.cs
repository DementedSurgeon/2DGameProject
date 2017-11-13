using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;
	public int[] spawnCounts;
	public Transform target;
	public ProjPool enemyProjPool;

	private float timer = 0;
	public float timerDelay = 0.5f;
	public float globalTimerDelay;
	private bool spawning = false;
	private EnemyMovementBis[] badDudes; 
	private int totalSpawns;
	private int waveCount;
	private int newSpawnThing;
	private float globalTimer;



	// Use this for initialization
	void Start ()
	{

		waveCount = spawnCounts.Length-1;
		newSpawnThing = spawnCounts [waveCount];
		
		for (int c = 0; c < spawnCounts.Length; c++) {
			totalSpawns += spawnCounts [c];
		}

		badDudes = new EnemyMovementBis[totalSpawns];
		int temp = 0;
		//PatronData data = ptr.GetRandomData ();
		for (int s = 0; s < spawnCounts.Length; s++) {
			for (int i = 0 + temp; i < spawnCounts[s] + temp; i++) {
				badDudes [i] = Instantiate (prefab [s], transform.position, Quaternion.identity, transform).GetComponent<EnemyMovementBis> ();
				badDudes [i].GetComponentInChildren<EnemyLook> ().SetTarget (target);
				badDudes [i].GetComponentInChildren<Arsenal> ().SetAmmoPool (enemyProjPool);
				if (i == 0 + temp) {
					if (badDudes [i].transform.GetChild (2) != null) {
						badDudes [i].transform.GetChild (2).gameObject.SetActive (true);
					}

				}

			

			}
			temp += spawnCounts [s];
		}
	}


	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (totalSpawns);
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
					
					newSpawnThing--;
					totalSpawns--;
					badDudes [totalSpawns].gameObject.SetActive (true);
					timer = timerDelay;
					if (totalSpawns == 0) {
						spawning = false;
					}
					if (newSpawnThing == 0) {
						globalTimer = globalTimerDelay;
						if (waveCount > 0) {
							waveCount--;
							newSpawnThing = spawnCounts [waveCount];
						}
					}

				}
					
				

			}
		}
	}
}

