using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

	private Health health;

	// Use this for initialization
	void Start () {
		health.Death += Spawn ;
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{

	}
}
