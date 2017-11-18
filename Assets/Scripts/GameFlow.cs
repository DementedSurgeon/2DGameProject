using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

	private float timer;
	public float timerDelay;

	public Health health;
	public BossSpawner boss;
	public delegate void MyDelegate();
	public MyDelegate StartSpawn;

	// Use this for initialization
	void Start () {
		health.Death += GameLost;
		boss.OnBossDead += GameWon;
		timer = timerDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				if (StartSpawn != null) {
					StartSpawn ();
				}

			}
		}
	}

	void GameWon()
	{
		SceneManager.LoadScene ("YouWin");
	}

	void GameLost()
	{
		SceneManager.LoadScene ("YouLose");
	}
}
