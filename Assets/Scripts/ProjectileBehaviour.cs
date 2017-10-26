using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	public float speed;
	public Transform startPos;
	public Transform firingVec;

	private Vector2 firingPos;
	private Vector3 fireVec;
	private bool isFired = false;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			isFired = true;
			firingPos = new Vector2 (startPos.position.x, startPos.position.y);
			fireVec = new Vector3 (firingVec.position.x, firingVec.position.y,0);
			transform.position = startPos.position;
			transform.rotation = startPos.rotation;
		}
		if (isFired) {
			transform.Translate (fireVec * speed * Time.deltaTime);
		}
		//Debug.Log (fireVec.position.x);
	}

	void Fire()
	{
		
	}
}
