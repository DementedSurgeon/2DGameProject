using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {

	public Health health;
	public BossSpawner boss;

	// Use this for initialization
	void Start () {
		health.Death += GameLost;
		boss.OnBossDead += GameWon;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameWon()
	{
		Debug.Log ("Game won!");
	}

	void GameLost()
	{
		Debug.Log ("Game lost!");
	}
}
