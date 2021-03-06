﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;
	public int jumpCount;
	public float dashCooldown;
	public int dashDistance;
	public ParticleSystem prs;

	private float dashTimer = 0;
	private int maxJumpCount;
	private Rigidbody2D rb2d;
	private SpriteRenderer sprt;
	private ParticleSystem prtcl;
	private Vector2 boundsMin;
	private Vector2 boundsMax;
	private float dashFlashTimer;
	private PlayerSounds pSounds;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		sprt = gameObject.GetComponent<SpriteRenderer> ();
		prtcl = gameObject.GetComponent<ParticleSystem> ();
		pSounds = gameObject.GetComponent<PlayerSounds> ();
		maxJumpCount = jumpCount;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (dashFlashTimer > 0) {
			dashFlashTimer -= Time.deltaTime;
			if (dashFlashTimer <= 0) {
				transform.GetChild (0).GetComponent<SpriteRenderer> ().color = Color.white;
				transform.GetChild (1).GetComponent<SpriteRenderer> ().color = Color.white;
				sprt.color = Color.white;
			}
		}

		if (dashTimer > 0) {
			dashTimer -= Time.deltaTime;
			if (dashTimer <= 0) {
				sprt.color = Color.blue;
				transform.GetChild (0).GetComponent<SpriteRenderer> ().color = Color.blue;
				transform.GetChild (1).GetComponent<SpriteRenderer> ().color = Color.blue;
				dashFlashTimer = Time.deltaTime*5;
			}
		}



		boundsMin = sprt.bounds.min;
		boundsMax = sprt.bounds.max;
		boundsMin = Camera.main.WorldToViewportPoint (boundsMin);
		boundsMax = Camera.main.WorldToViewportPoint (boundsMax);
		if (Input.GetKey (KeyCode.A) && boundsMin.x > 0.01f) {
			rb2d.velocity = new Vector2 (-1 * walkSpeed, rb2d.velocity.y);
		} else if (Input.GetKeyUp (KeyCode.A) || boundsMax.x >= 1) {
			//Debug.Log (boundsMax.x);
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}

		if (Input.GetKey (KeyCode.D) && boundsMax.x < 0.99f) {
			rb2d.velocity = new Vector2 (1 * walkSpeed, rb2d.velocity.y);
		} else if (Input.GetKeyUp (KeyCode.D) || boundsMin.x < 0) {

			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.Space) && jumpCount > 0) {
			rb2d.velocity = Vector2.up * jumpHeight;
			jumpCount--;
		}

		if (Input.GetKey (KeyCode.A) && Input.GetKeyDown (KeyCode.LeftShift)) {
			if (dashTimer <= 0) {
				Instantiate (prs, transform.position, Quaternion.identity);
				prs.Play();
				transform.position += Vector3.left * dashDistance;
				boundsMin = sprt.bounds.min;
				boundsMin = Camera.main.WorldToViewportPoint (boundsMin);
				if (boundsMin.x < 0) {
						transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.01f,0,0)).x, transform.position.y, transform.position.z);
				}
				dashTimer = dashCooldown;
				prtcl.Play ();
				pSounds.Play (0);
			}
		}
		if (Input.GetKey (KeyCode.D) && Input.GetKeyDown (KeyCode.LeftShift)) {
			if (dashTimer <= 0) {
				Instantiate (prs, transform.position, Quaternion.identity);
				prs.Play();
				transform.position += Vector3.right * dashDistance;
				boundsMax = sprt.bounds.max;
				boundsMax = Camera.main.WorldToViewportPoint (boundsMax);
				if (boundsMax.x > 1) {
					transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.99f,0,0)).x, transform.position.y, transform.position.z);
				}
				dashTimer = dashCooldown;
				prtcl.Play ();
				pSounds.Play (0);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Terrain") {
			jumpCount = maxJumpCount;
		}
	}

	public int GetJumpCount()
	{
		return jumpCount;
	}
}
