using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	float speed;
	float sinArc;
	float sinSpeed;

	bool horizontal;

	private int reverser = 1;
	private BossPatternData activePattern;
	private BossPatternData futurePattern;

	// Use this for initialization
	void Start () {
		UpdatePattern ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!horizontal) {
			float stuff = (Mathf.Sin (transform.position.y / sinArc)) * reverser;
			Vector3 newStuff = new Vector3 (stuff * sinSpeed, transform.position.y, 0);
			transform.position = newStuff;
			transform.position += Vector3.up * speed * Time.deltaTime;
			if ((Camera.main.WorldToViewportPoint (transform.position).y) <= 0) {
				reverser = reverser * -1;
				transform.position = new Vector3 (transform.position.x, Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y, 0);
				UpdatePattern ();

			} else if ((Camera.main.WorldToViewportPoint (transform.position).y) >= 1) {
				transform.position = new Vector3 (transform.position.x, Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y, 0);
				reverser = reverser * -1;
				UpdatePattern ();
			}
		} else if (horizontal) {
			float stuff = (Mathf.Sin (transform.position.x / sinArc)) * reverser;
			Vector3 newStuff = new Vector3 (transform.position.x, stuff * sinSpeed, 0);
			transform.position = newStuff;
			transform.position += Vector3.left * speed * Time.deltaTime;
			if ((Camera.main.WorldToViewportPoint (transform.position).x) <= 0) {
				reverser = reverser * -1;
				transform.position = new Vector3 (Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x, transform.position.y, 0);
				UpdatePattern ();

			} else if ((Camera.main.WorldToViewportPoint (transform.position).x) >= 1) {
				transform.position = new Vector3 (Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x, transform.position.y, 0);
				reverser = reverser * -1;
				UpdatePattern ();
			}
		}
	}

	void UpdatePattern()
	{
		activePattern = futurePattern;
		speed = activePattern.speed;
		sinArc = activePattern.sinArc;
		sinSpeed = activePattern.sinSpeed;
		horizontal = activePattern.horizontal;
	}


	public void NextPattern(BossPatternData pattern)
	{
		futurePattern = pattern;
	}

	public BossPatternData GetActivePattern()
	{
		return activePattern;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Health> ().Hurt(transform.position.x);
		}
	}
}
