using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispose : MonoBehaviour {

	private ParticleSystem prs;
	// Use this for initialization
	void Start () {
		prs = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!prs.isPlaying) {
			Destroy (gameObject);
		}
	}
}
