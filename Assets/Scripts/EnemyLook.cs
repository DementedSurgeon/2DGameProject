using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour {

	private Transform target;

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

		dir = new Vector2(target.position.x, target.position.y);
		dirr = transform.position;
		transform.right = dir - dirr;
		//		
		if (dir.x < dirr.x) {
			SR.flipY = true;
			prtSR.flipX = true;
			//chldSR.flipY = true;
		}
		else if (dir.x > dirr.x) {
			SR.flipY = false;
			prtSR.flipX = false;
			//chldSR.flipX = false;
		}

	}

	public float GetDirX()
	{
		return dir.x;
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
