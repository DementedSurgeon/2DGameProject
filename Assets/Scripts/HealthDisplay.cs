using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	public Health health;

	private Text field;

	// Use this for initialization
	void Start () {
		field = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		DisplayData ();
	}

	public void DisplayData ()
	{
		field.text = "HP:" + health.health.ToString() + "/" + health.GetMaxHP ().ToString();
	}


}
