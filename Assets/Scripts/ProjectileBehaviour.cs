using System.Collections;
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
	//private Gun gun;

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
	
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			if (col.gameObject.GetComponent<EnemyHealth> ().enabled == true) {
				col.gameObject.GetComponent<EnemyHealth> ().Hurt (transform.position.x);
				col.attachedRigidbody.AddForceAtPosition (new Vector2 (50, 50), transform.position);
				transform.position = resetPoint;
				isFired = false;
			}
		} else if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Health> ().Hurt (transform.position.x);
			col.attachedRigidbody.AddForceAtPosition (new Vector2 (50, 50), transform.position);
			transform.position = resetPoint;
			isFired = false;
		}
	}

	public void SetStartPos (Transform tsfm)
	{
		startPos = tsfm;
	}

	/*public void SetGun (Gun newGun)
	{
		gun = newGun;
	}*/

	public void FireBullet()
	{
		isFired = true;
		firingPos = new Vector3 (startPos.position.x, startPos.position.y,0);
		//Debug.Log (firingPos);
		transform.position = firingPos;
		transform.rotation = startPos.rotation;

	}

	public void FireShotty(int newSpread, int newReset)
	{
		spread = newSpread;
		int limit = newReset;
		isFired = true;
		firingPos = new Vector3 (startPos.position.x, startPos.position.y,0);
		Quaternion spreadRot = startPos.rotation * Quaternion.Euler (0, 0, spread * 2);
		spreadRot = spreadRot * Quaternion.Euler (0, 0, (-1 * spread * counter)); 
		transform.rotation = spreadRot;
		transform.position = firingPos;
		counter++;
		if (counter > limit - 1) {
			counter = 0;
		}

	}


	public bool GetIsFired()
	{
		return isFired;
	}
}
