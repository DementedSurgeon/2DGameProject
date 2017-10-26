using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public ProjPool magazine;
	public int magazineSize;

	private int maxMagazineSize;

	// Use this for initialization
	void Start () {
		maxMagazineSize = magazineSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			FireGun ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Reload ();
		}
	}

	void FireGun(){
		if (magazineSize > 0) {
			magazine.Find ();
			magazineSize--;
		}
	}

	void Reload ()
	{
		magazineSize = maxMagazineSize;
	}
}
