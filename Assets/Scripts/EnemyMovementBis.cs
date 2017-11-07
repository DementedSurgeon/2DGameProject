using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovementBis : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 midPos;
	public Vector2 endPos;

	public bool parabola = false;
	public bool reverseX = false;
	public bool reverseY = false;
	public float time;
	private float horizontalSpeed;
	private float verticalSpeed;
	private float topY;
	private float toppYa;
	private float toppYB;
	private float time1;
	private float time2;

	private float switchTimer;

	private int counter = 0;

	private PatronData[] ptrndt = new PatronData[2];

	private SpriteRenderer sprt;

	// Use this for initialization

	public void Initialize(PatronData data)
	{
		startPos = data.startPos;
		midPos = data.midPos;
		endPos = data.endPos;
		parabola = data.parabola;
		reverseX = data.reverseX;
		reverseY = data.reverseY;
		time = data.time;
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
		if (reverseX) {
			ReverseX ();
		}

		if (reverseY) {
			ReverseY ();
		}


		if (parabola)
			gameObject.GetComponentInChildren<Arsenal> ().timerDelay = time1;
		else if (!parabola)
			gameObject.GetComponentInChildren<Arsenal> ().timerDelay = time/2;
	}

	void Start () {
		Initialize (ptrndt [0]);
		counter++;


		sprt = gameObject.GetComponent<SpriteRenderer> ();

	}

	
	// Update is called once per frame
	void Update () {
		
		transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;
		transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
		if (parabola) {
			verticalSpeed -= toppYa * Time.deltaTime;
			if (Vector2.Distance (transform.position, midPos) <= (2/time)) {
				toppYa = -toppYB;
			}
		}

		switchTimer += Time.deltaTime;
		if (switchTimer >= time) {
			if (counter == 0) {
				Initialize (ptrndt [counter]);
				counter++;
			} else if (counter == 1) {
				Initialize (ptrndt [counter]);
				counter--;
			}
			switchTimer = 0;
		}
	}

	public void ReverseX()
	{
		startPos = new Vector2 (startPos.x * -1, startPos.y);
		endPos = new Vector2 (endPos.x * -1, endPos.y);
		midPos = new Vector2 (midPos.x * -1, midPos.y);
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

	public void ReverseY()
	{
		startPos = new Vector2 (startPos.x, startPos.y * -1);
		endPos = new Vector2 (endPos.x, endPos.y* -1);
		midPos = new Vector2 (midPos.x, midPos.y* -1);
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

	public void Reset()
	{
		transform.position = new Vector3 (startPos.x, startPos.y, 0);
		gameObject.SetActive (false);
	}

	public void SetPatternOne (PatronData pat)
	{
		ptrndt [0] = pat;
	}

	public void SetPatternTwo (PatronData pat)
	{
		ptrndt [1] = pat;
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.tag == "Terrain") {
			sprt.sortingOrder = (col.gameObject.GetComponent<SpriteRenderer> ().sortingOrder) + 4;
		}
	}
}
