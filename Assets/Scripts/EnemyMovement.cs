using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public float sinArc;
	public float sinSpeed;

	private int reverser = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float stuff = (Mathf.Sin (transform.position.y / sinArc)) * reverser;
		Vector3 newStuff = new Vector3(stuff*sinSpeed,transform.position.y,0);
		transform.position = newStuff;
		transform.position += Vector3.up * speed * Time.deltaTime;
		if ((Camera.main.WorldToViewportPoint (transform.position).y) <= 0) {
			reverser = reverser * -1;
			transform.position = new Vector3 (transform.position.x, Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y, 0);

		}
		else if ((Camera.main.WorldToViewportPoint (transform.position).y) >= 1) {
			transform.position = new Vector3 (transform.position.x, Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y, 0);
			reverser = reverser * -1;
		}
	}
}
