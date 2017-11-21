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
	public TrainManager tMan;
	public delegate void MyDelegate();
	public MyDelegate OnDoneSpawning;
	public MyDelegate OnBossDead;

	// Use this for initialization
	void Start () {
		bossData = new BossPatternData[4];
		bossData [0] = new BossPatternData (1 * speed, 3, 3, false, new Vector2(-10,-6));
		bossData [1] = new BossPatternData (1 * speed, 4, 4, true, new Vector2(10,6));
		bossData [2] = new BossPatternData (-1 * speed, 4, 4, false, new Vector2(10,6));
		bossData [3] = new BossPatternData (-1 * speed, 5, 5, true, new Vector2(-10,-6));
		boss = new BossMovement[bossLength];
		for (int i = 0; i < boss.Length; i++) {
			boss [i] = Instantiate (prefab, transform.position, Quaternion.identity, transform).GetComponent<BossMovement> ();
			boss [i].NextPattern (bossData[activePattern]);
			if (i == 0) {
				boss [i].gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			}
		}
		checks = new bool[bossLength];
		for (int i = 0; i < boss.Length; i++) {
			checks [i] = false;
		}
		tMan.FinishedScroll += BeginSpawn;
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
					for (int i = 0; i < boss.Length; i++) {
						boss [i].gameObject.GetComponent<EnemyHealth> ().enabled = true;
					}
					if (OnDoneSpawning != null) {
						OnDoneSpawning ();

					}
				}
			}
		}
		if (doneSpawning) {
			for (int i = 0; i < boss.Length; i++) {
				if (!boss [i].gameObject.activeSelf && checks[i] == false) {
					checks [i] = true;
					NextPattern ();
					for (int c = i + 1; c < boss.Length; c++) {
						if (c == i + 1) {
							boss [c].gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
						}
						if (checks [c] == true) {
							c = boss.Length;
						} else {
							boss [c].NextPattern (bossData [activePattern]);
						}
					}
					for (int v = 0; v < checks.Length; v++)
					{
						if (checks [v] == false) {
							v = checks.Length;
						} else if (v == checks.Length - 1 && checks [v] == true) {
							if (OnBossDead != null) {
								OnBossDead ();
							}
						}
					}
				} 
			}
		}
	}

	// 0 0 1 1 1
	void NextPattern()
	{
		activePattern++;
		if (activePattern == bossData.Length) {
			activePattern = 0;
		}
	}

	void BeginSpawn()
	{
		spawning = true;
	}
}
