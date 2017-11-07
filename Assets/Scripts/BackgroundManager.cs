using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	public Transform[] sky;
	public Transform[] buildings;
	public Transform[] houses;

	public int skyScrollRate;
	public int buildingScrollRate;
	public int houseScrollRate;

	private Camera cam;

	private SpriteRenderer[] sR;
	private SpriteRenderer[] bR;
	private SpriteRenderer[] hR;

	// Use this for initialization
	void Start () {
		sR = new SpriteRenderer[sky.Length];
		bR = new SpriteRenderer[buildings.Length];
		hR = new SpriteRenderer[houses.Length];
		cam = Camera.main;
		for (int i = 0; i < sR.Length; i++) {
			sR [i] = sky [i].gameObject.GetComponent<SpriteRenderer> ();
		}

		for (int i = 0; i < bR.Length; i++) {
			bR [i] = buildings [i].gameObject.GetComponent<SpriteRenderer> ();
		}

		for (int i = 0; i < hR.Length; i++) {
			hR [i] = houses [i].gameObject.GetComponent<SpriteRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < sky.Length; i++)
		{
			sky [i].Translate (Vector3.left * skyScrollRate * Time.deltaTime);
			Vector3 pos = cam.WorldToViewportPoint (sky[i].position);
			if (pos.x <= 0) {
				sky[i].position += new Vector3 (sR[i].bounds.size.x*2, 0, 0);
			}
		}

		for (int i = 0; i < sky.Length; i++)
		{
			buildings [i].Translate (Vector3.left * buildingScrollRate * Time.deltaTime);
			Vector3 pos = cam.WorldToViewportPoint (buildings [i].position);
			if (pos.x <= 0) {
				buildings [i].position += new Vector3 (bR[i].bounds.size.x*2, 0, 0);
			}
		}

		for (int i = 0; i < sky.Length; i++)
		{
			houses [i].Translate (Vector3.left * houseScrollRate * Time.deltaTime);
			Vector3 pos = cam.WorldToViewportPoint (houses [i].position);
			if (pos.x <= 0) {
				houses [i].position += new Vector3 (hR[i].bounds.size.x*2, 0, 0);
			}
		}
	}
}
