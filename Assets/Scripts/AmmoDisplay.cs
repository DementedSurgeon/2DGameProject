using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {

	public Gun gun;

	private Text field;

	// Use this for initialization
	void Start () {
		field = gameObject.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		DisplayData ();
	}

	public void GetGun(Gun newGun)
	{
		gun = newGun;
	}

	public void DisplayData ()
	{
		field.text = gun.GetMagSize ().ToString () + "/" + gun.GetMaxMagSize ().ToString() + " " + gun.GetName();
	}
}
