using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public Spawner spawner;
	public TrainManager tManager;
	public BossSpawner bossSpawner;
	public AudioClip[] clips;
	private AudioSource audioSource;
	private float timer;
	private float timerDelay = 0.5f;
	private bool fading = false;
	private int currentTrack = 0;

	// Use this for initialization
	void Start () {
		spawner.FinishedSpawn += FadeMusic;
		tManager.FinishedScroll += StopMusic;
		tManager.FinishedScroll += NextTrack;
		bossSpawner.OnDoneSpawning += StopMusic;
		bossSpawner.OnDoneSpawning += NextTrack;
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}

		if (fading) {
			if (timer <= 0) {
				FadeMusic();
			}
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			FadeMusic ();
		}
	}

	void FadeMusic()
	{
		fading = true;
		audioSource.volume -= 0.05f;
		timer = timerDelay;
		if (audioSource.volume == 0) {
			fading = false;
			StopMusic ();
		}
	}

	void StopMusic()
	{
		audioSource.Stop ();
		audioSource.volume = 1;
	}

	void NextTrack()
	{
		currentTrack++;
		audioSource.clip = clips [currentTrack];
		audioSource.Play ();
	}
}
