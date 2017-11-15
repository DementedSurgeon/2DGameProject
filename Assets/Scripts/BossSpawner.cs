using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	public GameObject prefab;
	public int bossLength;
	public float timerDelay;
	private float timer = 0;
	private BossMovement[] boss;
	private BossPatternData[] bossData;
	private bool[] checks;
	private int activePattern = 0;
	private bool spawning = false;
	private int counter = 0;
	public int speed;
	private bool doneSpawning = false;

	// Use this for initialization
	void Start () {
		bossData = new BossPatternData[4];
		bossData [0] = new BossPatternData (1 * speed, 1, 1, false);
		bossData [1] = new BossPatternData (-1 * speed, -2, -2, true);
		bossData [2] = new BossPatternData (1 * speed, 3, 3, false);
		bossData [3] = new BossPatternData (-1 * speed, -4, -4, true);
		boss = new BossMovement[bossLength];
		for (int i = 0; i < boss.Length; i++) {
			boss [i] = Instantiate (prefab, transform.position, Quaternion.identity, transform).GetComponent<BossMovement> ();
			boss [i].NextPattern (bossData[activePattern]);
		}
		checks = new bool[bossLength];
		for (int i = 0; i < boss.Length; i++) {
			checks [i] = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			spawning = true;
		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}

		if (spawning) {
			if (timer <= 0) {
				boss [counter].gameObject.SetActive (true);
				timer = timerDelay;
				counter++;
				if (counter == boss.Length) {
					spawning = false;
					doneSpawning = true;
				}
			}
		}
		if (doneSpawning) {
			for (int i = 0; i < boss.Length; i++) {
				if (!boss [i].gameObject.activeSelf && checks[i] == false) {
					checks [i] = true;
					NextPattern ();
					for (int c = i + 1; c < boss.Length; c++) {
						boss[c].NextPattern(bossData[activePattern]);
					}
				} 
			}
		}
	}

	// 0 0 1 1 1
	void NextPattern()
	{
		activePattern++;
		if (activePattern == 4) {
			activePattern = 0;
		}
	}
}
