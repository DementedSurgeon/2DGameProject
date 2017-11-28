using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health;
	private int maxHealth;

	private Rigidbody2D rgbd;
	private PlayerSounds pSounds;
	public ParticleSystem prs;
	public DisposeSounds dSounds;

	public delegate void OnDeath ();
	public OnDeath Death;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		rgbd = gameObject.GetComponent<Rigidbody2D> ();
		pSounds = gameObject.GetComponent<PlayerSounds> ();
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
			rgbd.AddForce (new Vector2(-100, 0));
		} else if (transform.position.x > trs) {
			rgbd.AddForce (new Vector2(100, 0));
		}
	}

	void Dies()
	{
		if (prs != null) {
			Instantiate (prs, transform.position, Quaternion.identity);
			prs.Play ();
			Debug.Log ("works");
		}
		if (dSounds != null) {
			Instantiate (dSounds, transform.position, Quaternion.identity);
			dSounds.gameObject.GetComponent<EnemySounds>().Play(0);
		}
		gameObject.SetActive (false);
		pSounds.Play (1);
	}

	public int GetMaxHP ()
	{
		return maxHealth;
	}
}
