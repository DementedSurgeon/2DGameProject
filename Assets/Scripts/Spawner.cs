using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] prefab;
	public int[] spawnCounts;
	public int spawnCount;
	public Transform target;
	public ProjPool enemyProjPool;

	private float timer = 0;
	public float timerDelay = 0.5f;
	public float globalTimerDelay;
	private bool spawning = false;
	private EnemyMovementBis[] badDudes; 



	// Use this for initialization
	void Start ()
	{
		
		if (spawnCount <= 0) {
			spawnCount = 1;
		}
		badDudes = new EnemyMovementBis[spawnCount];

		//PatronData data = ptr.GetRandomData ();

		for (int i = 0; i < badDudes.Length; i++) {
			badDudes [i] = Instantiate (prefab[0], transform.position, Quaternion.identity, transform).GetComponent<EnemyMovementBis> ();
			badDudes [i].GetComponentInChildren<EnemyLook>().SetTarget(target);
			badDudes [i].GetComponentInChildren<Arsenal>().SetAmmoPool (enemyProjPool);
			if (i == 0) {
				
					badDudes [i].transform.GetChild (2).gameObject.SetActive (true);

			}

			/*if ((i + 1) % 4 == 0)
				data = ptr.GetRandomData ();	*/	

		}
	}


	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			spawning = true;
			}
		if (spawning) {
			
				if (timer <= 0) {
					spawnCount--;
					badDudes [spawnCount].gameObject.SetActive (true);
					timer = timerDelay;
					}
					
				
			if (spawnCount == 0) {
					spawning = false;
				}
			}
		}
	}

