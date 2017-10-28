using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public int spawnCount;
	public Transform target;

	private float timer = 0;
	public float timerDelay = 0.5f;
	private bool spawning = false;

	public EnemyLook[] badDudes; 


	// Use this for initialization
	void Start () {
		if (spawnCount <= 0) {
			spawnCount = 1;
		}
		badDudes = new EnemyLook[spawnCount];
		for (int i = 0; i < badDudes.Length; i++) {
			badDudes [i] = Instantiate (prefab, transform.position, Quaternion.identity, transform).GetComponentInChildren<EnemyLook> ();
			badDudes [i].SetTarget (target);
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
				badDudes [spawnCount].transform.parent.gameObject.SetActive (true);
				timer = timerDelay;
				Debug.Log (spawnCount);
			}
			if (spawnCount == 0) {
				spawning = false;
			}
		}
	}
}
