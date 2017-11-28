using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

	public AudioClip[] sounds;
	private AudioSource aSource;

	// Use this for initialization
	void Start () {
		aSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(int trackNumber)
	{
		aSource.clip = sounds [trackNumber];
		aSource.Play ();
	}
}
