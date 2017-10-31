using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovementBis : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 midPos;
	public Vector2 endPos;

	public bool parabola = false;
	public float time;
	private float horizontalSpeed;
	private float verticalSpeed;
	private float topY;
	private float toppYa;
	private float toppYB;
	private float time1;
	private float time2;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (startPos.x, startPos.y, 0);
		Vector2 temp =  endPos - startPos;
		if (parabola) {
			Vector2 temp3 = midPos - startPos;
			Vector2 temp4 = endPos - midPos;
			time1 = (time * temp3.x) / temp.x;
			time2 = (time * temp4.x) / temp.x;
			verticalSpeed = (temp3.y / time1) * 2;
			toppYa = ((temp3.y / time1) * 2) / time1;
			toppYB = ((temp4.y / time2) * 2) / time2;
		} else if (!parabola) {
			verticalSpeed = temp.y / time;
		}
		
		horizontalSpeed = temp.x / time;

	}

	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;
		transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
		if (parabola) {
			verticalSpeed -= toppYa * Time.deltaTime;
			if (Vector2.Distance (transform.position, midPos) <= 1) {
				toppYa = -toppYB;
			}
		}
		Debug.Log (Time.timeSinceLevelLoad);
	}
}
