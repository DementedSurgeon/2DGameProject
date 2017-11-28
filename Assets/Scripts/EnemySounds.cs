using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {

	public AudioClip[] sounds;
	public AudioSource aSource;

	void Awake()
	{
		aSource = gameObject.GetComponent<AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		
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
