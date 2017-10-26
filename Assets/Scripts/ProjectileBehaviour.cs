using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	public float speed;

	private Transform startPos;
	private Vector3 firingPos;
	private bool isFired = false;
	private Vector3 resetPoint;
	private Vector3 borders;

	// Use this for initialization
	void Start () {
		resetPoint = transform.position;
	
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

	void Fire()
	{
		
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

	public void FireBullet()
	{
		isFired = true;
		firingPos = new Vector3 (startPos.position.x, startPos.position.y,0);
		transform.position = firingPos;
		transform.rotation = startPos.rotation;
	}

	public bool GetIsFired()
	{
		return isFired;
	}
}
