using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;
	public int[] spawnCounts;
	public Transform target;
	public ProjPool enemyProjPool;
	public GameFlow gameFlow;

	private float timer = 0;
	public float timerDelay = 0.5f;
	public float globalTimerDelay;
	private bool spawning = false;
	private EnemyMovementBis[] badDudes; 
	private int totalSpawns;
	private int totalWaves;
	public int waveCount;
	private int currentSpawn;
	private int currentWave;
	private float globalTimer;
	public static int yeNewSpawneThinge;
	private int nextWave;
	private bool validatingWave = false;
	public delegate void OnFinishSpawn();
	public OnFinishSpawn FinishedSpawn;
	private int ammoType = 0;


	// Use this for initialization
	void Start ()
	{
		gameFlow.StartSpawn += StartSpawning;

		if (spawnCounts.Length % waveCount != 0) {
			validatingWave = true;
		}
		while (validatingWave) {
			waveCount--;
			if (spawnCounts.Length % waveCount == 0)
			{
				validatingWave = false;
			}
		}
		for (int c = 0; c < spawnCounts.Length; c++) {
			totalSpawns += spawnCounts [c];
		}
		totalWaves = spawnCounts.Length - 1;
		currentSpawn = spawnCounts [totalWaves];
		currentWave = waveCount;
		for (int c = totalWaves; c > totalWaves - currentWave; c--) {
			yeNewSpawneThinge += spawnCounts [c]; 
		}
		for (int c = currentWave; c > 0; c--) {
			nextWave += spawnCounts [c]; 
		}





		


		badDudes = new EnemyMovementBis[totalSpawns];
		int temp = 0;
		//PatronData data = ptr.GetRandomData ();
		for (int s = 0; s < spawnCounts.Length; s++) {
			for (int i = 0 + temp; i < spawnCounts[s] + temp; i++) {
				badDudes [i] = Instantiate (prefab [s], transform.position, Quaternion.identity, transform).GetComponent<EnemyMovementBis> ();
				badDudes [i].GetComponentInChildren<EnemyLook> ().SetTarget (target);
				badDudes [i].GetComponentInChildren<EnemyArsenal> ().SetAmmoPool (enemyProjPool);
				if (i == 0 + temp) {
					if (badDudes [i].transform.GetChild (2) != null) {
						badDudes [i].transform.GetChild (2).gameObject.SetActive (true);
						badDudes [i].transform.GetChild (2).GetComponent<AmmoBox> ().SetAmmoType (ammoType);
						ammoType++;
						if (ammoType > 2) {
							ammoType = 0;
						}
					}

				}

			

			}
			temp += spawnCounts [s];
		}
	}


	
	// Update is called once per frame
	void Update ()
	{
		if (yeNewSpawneThinge == 0 && totalSpawns == 0) {
			if (FinishedSpawn != null) {
				FinishedSpawn ();
				Debug.Log ("Works!");
				gameObject.SetActive (false);
			}
		}
		
		if (globalTimer > 0) {
			globalTimer -= Time.deltaTime;
		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log (totalSpawns + "tS");
			Debug.Log (totalWaves + "tW");
			Debug.Log (currentSpawn + "cS");
			Debug.Log (currentWave + "cW");
			Debug.Log (yeNewSpawneThinge + "yO");
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			spawning = true;


		}
		if (yeNewSpawneThinge == 0 && totalSpawns != 0) {
				spawning = true;
			for (int c = totalWaves; c > totalWaves - currentWave; c--) {
				yeNewSpawneThinge += spawnCounts [c]; 
			}
				currentWave = waveCount;
				globalTimer = globalTimerDelay;
		}
		if (spawning) {
			
			if (globalTimer <= 0) {
				if (timer <= 0) {
					
					currentSpawn--;
					totalSpawns--;
					badDudes [totalSpawns].gameObject.SetActive (true);
					timer = timerDelay;
					if (currentSpawn == 0) {
						totalWaves--;
						currentWave--;
						globalTimer = globalTimerDelay;
						if (totalWaves >= 0) {
							currentSpawn = spawnCounts [totalWaves];
						}

						if (currentWave == 0) {
							spawning = false;

						}
					}



				}
					


			}
		}
	}

	void StartSpawning()
	{
		spawning = true;
	}
}

