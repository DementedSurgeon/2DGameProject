using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

	private EnemyHealth health;
	private SpriteRenderer sR;
	private Rigidbody2D rb2D;
	private Collider2D col2D;
	private int ammoType = 0;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		health = gameObject.GetComponentInParent<EnemyHealth> ();
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
		Debug.Log (sprites.Length, gameObject);
		sR.enabled = true;
		sR.sprite = sprites [ammoType];
		rb2D.simulated = true;
		col2D.enabled = true;
		transform.parent = null;
		gameObject.SetActive (true);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Health health = coll.gameObject.GetComponent<Health> ();
			Arsenal arsenal = coll.gameObject.GetComponentInChildren<Arsenal> ();
			if (ammoType == 0) {
				health.health += 5;
				if (health.health > health.GetMaxHP ()) {
					health.health = health.GetMaxHP ();
				}


			} else if (ammoType == 1) {
				for (int i = 0; i < arsenal.weaponry.Length; i++) {
					if (arsenal.weaponry [i].GetName () == "Shotgun") {
						arsenal.weaponry [i].ammoPool += arsenal.weaponry[i].GetClipMax() * 2;
					}
				}
			} else if (ammoType == 2) {
				for (int i = 0; i < arsenal.weaponry.Length; i++) {
					if (arsenal.weaponry [i].GetName () == "MG") {
						arsenal.weaponry [i].ammoPool += arsenal.weaponry[i].GetClipMax() * 2;
					}
				}
			}
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

	public void SetAmmoType(int newAmmo)
	{
		ammoType = newAmmo;
	}

}
