using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health;
	private int maxHealth;

	private Rigidbody2D rgbd;
	public ParticleSystem prs;
	public DisposeSounds dSounds;

	public delegate void OnDeath ();
	public OnDeath Death;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		rgbd = gameObject.GetComponent<Rigidbody2D> ();
		Death += Dies;
	}

	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			if (Death != null) {
				Death ();
			}
		}
	}

	public void Hurt(float trs){
		health--;
		if (transform.position.x < trs) {
			rgbd.AddForce (new Vector2(-50, 0));
		} else if (transform.position.x > trs) {
			rgbd.AddForce (new Vector2(50, 0));
		}
	}

	void Dies()
	{
		if (prs != null) {
			Instantiate (prs, transform.position, Quaternion.identity);
			prs.Play ();

			}
		if (dSounds != null) {
			Instantiate (dSounds, transform.position, Quaternion.identity);

		}
		gameObject.SetActive (false);
		Spawner.yeNewSpawneThinge--;

	}

	public int GetMaxHP ()
	{
		return maxHealth;
	}
}
