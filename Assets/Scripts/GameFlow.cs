using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {

	private float timer;
	public float timerDelay;
	private float winTimer;
	public float winTimerDelay;

	public Health health;
	public BossSpawner boss;
	public delegate void MyDelegate();
	public MyDelegate StartSpawn;

	// Use this for initialization
	void Start () {
		health.Death += GameLost;
		boss.OnBossDead += StartWinTimer;
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
		if (winTimer > 0) {
			winTimer -= Time.deltaTime;
			if (winTimer <= 0) {
				GameWon ();
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

	void StartWinTimer()
	{
		winTimer = winTimerDelay;
	}
}
