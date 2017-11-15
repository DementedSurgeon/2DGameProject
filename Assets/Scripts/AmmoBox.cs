using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

	private Health health;
	private SpriteRenderer sR;
	private Rigidbody2D rb2D;
	private Collider2D col2D;

	// Use this for initialization
	void Start () {
		health = gameObject.GetComponentInParent<Health> ();
		sR = gameObject.GetComponent<SpriteRenderer> ();
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		col2D = gameObject.GetComponent<Collider2D> ();
		health.Death += Spawn ;
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
		sR.enabled = true;
		rb2D.simulated = true;
		col2D.enabled = true;
		transform.parent = null;
		gameObject.SetActive (true);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			gameObject.SetActive (false);
		} 
	}

	void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Terrain") {
			transform.position = new Vector3 (transform.position.x, coll.collider.bounds.max.y);
			rb2D.isKinematic = true;
			rb2D.velocity = Vector2.zero;
		}
	}

}
