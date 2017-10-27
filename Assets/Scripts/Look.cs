using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

	private SpriteRenderer SR;
	private SpriteRenderer prtSR;
	private SpriteRenderer chldSR;

	private Vector2 dir;
	private Vector2 dirr;

	// Use this for initialization
	void Start () {
		SR = transform.GetComponent<SpriteRenderer> ();
		prtSR = transform.parent.GetComponent<SpriteRenderer> ();
		//chldSR = transform.GetChild (0).GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,0);
		dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		dirr = transform.position;
		transform.right = dir - dirr;
//		Debug.Log (dir);
		if (dir.x < 0) {
			SR.flipY = true;
			prtSR.flipX = true;
			//chldSR.flipY = true;
		}
		else if (dir.x > 0) {
			SR.flipY = false;
			prtSR.flipX = false;
			//chldSR.flipX = false;
		}
		//Debug.Log (Input.mousePosition.x + "and" + Input.mousePosition.y + "and" + transform.right);
	}

	public float GetDirX()
	{
		return dir.x;
	}
}
