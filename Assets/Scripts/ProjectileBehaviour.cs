﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	static int counter = 0;

	public float speed;

	private int spread;
	private Transform startPos;
	private Vector3 firingPos;
	private bool isFired = false;
	private Vector3 resetPoint;
	private Vector3 borders;
	private Gun gun;

	// Use this for initialization
	void Start () {
		resetPoint = transform.position;
		//gun = GameObject.FindWithTag ("Player").transform.GetChild (1).GetComponent<Gun> ();
		if (spread == 0) {
			spread = 5;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isFired) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		borders = Camera.main.WorldToViewportPoint (transform.position);
		if (borders.x <= 0 || borders.x >= 1 || borders.y <= 0 || borders.y >= 1) {
			transform.position = resetPoint;
			isFired = false;
		}
		//Debug.Log (fireVec.position.x);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
			transform.position = resetPoint;
			isFired = false;
		}
	}

	public void SetStartPos (Transform tsfm)
	{
		startPos = tsfm;
	}

	public void SetGun (Gun newGun)
	{
		gun = newGun;
	}

	public void FireBullet()
	{
		isFired = true;
		firingPos = new Vector3 (startPos.position.x, startPos.position.y,0);
		transform.position = firingPos;
		transform.rotation = startPos.rotation;
	}

	public void FireShotty()
	{
		spread = gun.GetSpread ();
		int limit = gun.GetPellets ();
		isFired = true;
		firingPos = new Vector3 (startPos.position.x, startPos.position.y,0);
		Quaternion spreadRot = startPos.rotation * Quaternion.Euler (0, 0, spread * 2);
		spreadRot = spreadRot * Quaternion.Euler (0, 0, (-1 * spread * counter)); 
		/*if (counter == 0) {
			transform.rotation = startPos.rotation;
			Debug.Log ("1");
		}
		else if (counter == 1) {
			transform.rotation = startPos.rotation * Quaternion.Euler(0,0,5);
			Debug.Log ("2");
		} else if (counter == 2) {
			transform.rotation = startPos.rotation * Quaternion.Euler(0,0,10);
			Debug.Log ("3");
		}
		else if (counter == 3) {
			transform.rotation = startPos.rotation * Quaternion.Euler(0,0,-5);
			Debug.Log ("4");
		}
		else if (counter == 4) {
			transform.rotation = startPos.rotation * Quaternion.Euler(0,0,-10);
			Debug.Log ("5");
		}*/
		transform.rotation = spreadRot;
		transform.position = firingPos;
		counter++;
		if (counter > limit - 1) {
			counter = 0;
		}
		Debug.Log (counter);
	}


	public bool GetIsFired()
	{
		return isFired;
	}
}
