using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public int spawnCount;
	public Transform target;
	public ProjPool enemyProjPool;

	private float timer = 0;
	public float timerDelay = 0.5f;
	public float globalTimerDelay;
	private bool spawning = false;
	private EnemyMovementBis[] badDudes; 
	private PatronController ptr;


	// Use this for initialization
	void Start ()
	{
		ptr = gameObject.GetComponent<PatronController> ();
		if (spawnCount <= 0) {
			spawnCount = 1;
		}
		badDudes = new EnemyMovementBis[spawnCount];

		//PatronData data = ptr.GetRandomData ();

		for (int i = 0; i < badDudes.Length; i++) {
			badDudes [i] = Instantiate (prefab, transform.position, Quaternion.identity, transform).GetComponent<EnemyMovementBis> ();
			badDudes [i].SetPatternOne (ptr.GetRandomData());
			badDudes [i].SetPatternTwo (ptr.GetRandomData());
			badDudes [i].GetComponentInChildren<EnemyLook>().SetTarget(target);
			badDudes [i].GetComponentInChildren<Arsenal>().SetAmmoPool (enemyProjPool);

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

