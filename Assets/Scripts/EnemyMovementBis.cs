using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBis : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 endPos;
	private float horizontalSpeed;
	private float verticalSpeed;
	public float topY;
	public float time;
	private float toppY;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(startPos.x, startPos.y,  0);
		Vector2 temp = startPos - endPos;
		Vector2 temp2 = endPos - startPos;
		topY = topY - transform.position.y;
		horizontalSpeed = temp.x / time;
		verticalSpeed = (topY / time) * 4;
		toppY = (verticalSpeed / (time / 2));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;
		transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
		verticalSpeed -= toppY * Time.deltaTime;
		Debug.Log(Time.timeSinceLevelLoad);
	}
}
