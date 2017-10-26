using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeAnim : MonoBehaviour {

	private Animator anim;
	private Movement move;
	private bool grounded = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		move = gameObject.GetComponent<Movement> ();
	}
		// Update is called once per frame
	void Update () {
		
		bool crouch = Input.GetKey (KeyCode.S);
		bool mFor = Input.GetKey (KeyCode.D);
		bool mBack = Input.GetKey (KeyCode.A);
		bool jumping = Input.GetKeyDown (KeyCode.Space);

		if (Input.GetKeyDown (KeyCode.Space)) {
			grounded = false;
		}

		anim.SetBool ("Crouching", crouch);
		anim.SetBool ("Jumping", jumping);
		anim.SetBool ("MovingForward", mFor);
		anim.SetBool ("MovingBack", mBack);
		anim.SetBool ("Grounded", grounded);

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Terrain") {
			grounded = true;
		}
	}
}
