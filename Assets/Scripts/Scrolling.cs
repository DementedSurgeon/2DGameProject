using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public float scrollRate;

	private Camera cam;
	private SpriteRenderer sR;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		sR = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * scrollRate * Time.deltaTime);
		Vector3 pos = cam.WorldToViewportPoint (transform.position);
		//Debug.Log (sR.bounds.size.x);
		if (pos.x <= 0) {
			transform.position += new Vector3 (sR.bounds.size.x*2, 0, 0);
		}
	}
}
