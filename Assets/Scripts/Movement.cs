using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;
	public int jumpCount;
	public float dashCooldown;
	public int dashDistance;

	private float dashTimer = 0;
	private int maxJumpCount;
	private Rigidbody2D rb2d;
	private SpriteRenderer sprt;
	private Vector2 boundsMin;
	private Vector2 boundsMax;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		sprt = gameObject.GetComponent<SpriteRenderer> ();
		maxJumpCount = jumpCount;

	}
	
	// Update is called once per frame
	void Update () {
		if (dashTimer > 0) {
			dashTimer -= Time.deltaTime;
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
				transform.position += Vector3.left * dashDistance;
				dashTimer = dashCooldown;
			}
		}
		if (Input.GetKey (KeyCode.D) && Input.GetKeyDown (KeyCode.LeftShift)) {
			if (dashTimer <= 0) {
				transform.position += Vector3.right * dashDistance;
				dashTimer = dashCooldown;
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
