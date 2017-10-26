using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public float sinSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float stuff = Mathf.Sin (Time.timeSinceLevelLoad);
		transform.position = new Vector3(transform.position.x,stuff*sinSpeed,0);
		transform.position += Vector3.left * speed * Time.deltaTime;
		if ((Camera.main.WorldToViewportPoint (transform.position).x) <= 0) {
			speed = speed * -1;
		}
		else if ((Camera.main.WorldToViewportPoint (transform.position).x) >= 1) {
			speed = speed * -1;
		}
	}
}
