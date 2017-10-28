using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeAnim : MonoBehaviour {

	private Animator anim;
	private Movement move;
	private bool grounded = false;
	private Look look;
	private bool mFor = false;
	private bool mBack = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		move = gameObject.GetComponent<Movement> ();
		look = transform.GetChild (1).GetComponent<Look> ();
	}
		// Update is called once per frame
	void Update () {
		
		bool crouch = Input.GetKey (KeyCode.S);
		bool jumping = Input.GetKeyDown (KeyCode.Space);

		if (Input.GetKeyDown (KeyCode.Space)) {
			grounded = false;
		}

		if (Input.GetKey (KeyCode.A)) {
			if (look.GetDirX () > 0) {
				mBack = true;
				mFor = false;
			} else if (look.GetDirX () < 0) {
				mFor = true;
				mBack = false;
			}
		}


		if (Input.GetKey (KeyCode.D)) {
			if (look.GetDirX () < 0) {
				mBack = true;
				mFor = false;
			} else if (look.GetDirX () > 0) {
				mFor = true;
				mBack = false;
			}
		}

	

		if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.D)))
		{
			mFor = false;
			mBack = false;
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
