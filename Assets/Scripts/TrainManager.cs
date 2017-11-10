using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

	public Transform[] trains;
	public int trainScrollRate;

	private SpriteRenderer[] tR;
	private Camera cam;
	private int counter = 5;
	private bool scrolling = true;
	private bool resetting = true;

	// Use this for initialization
	void Start () {
		tR = new SpriteRenderer[trains.Length];
		cam = Camera.main;
		for (int i = 0; i < tR.Length; i++) {
			tR [i] = trains [i].gameObject.GetComponent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (scrolling) {
			for (int i = 0; i < trains.Length; i++) {
				if (trains [i].gameObject.activeSelf == true) {
					trains [i].Translate (Vector3.left * trainScrollRate * Time.deltaTime);
					Vector3 pos = cam.WorldToViewportPoint (trains [i].position);
					if (i == trains.Length - 1) {
						if (pos.x <= 1) {
							scrolling = false;
						}
					}
					if (resetting) {
						if (pos.x <= 0) {
							trains [i].position += new Vector3 ((tR [i].bounds.size.x * 4) - 2, 0, 0);
							counter--;
						}
					}
				}
			}
			if (counter == 0 && trains[trains.Length -1].gameObject.activeSelf == false) {
				trains [trains.Length - 1].gameObject.SetActive (true);
				//trains [trains.Length - 1].position += new Vector3 ((tR [trains.Length - 1].bounds.size.x * 5) - 2.5f, 0, 0);
				resetting = false;
			}
		}
	}
}
