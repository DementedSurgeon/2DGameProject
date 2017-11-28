using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeSounds : MonoBehaviour {

	private AudioSource aSource;
	// Use this for initialization
	void Start () {
		aSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!aSource.isPlaying) {
			Destroy (gameObject);
		}
	}
}
