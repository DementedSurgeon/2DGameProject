using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,0);
		Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		Vector2 dirr = transform.position;
		transform.right = dir - dirr;
		//Debug.Log (dir);
		//Debug.Log (Input.mousePosition.x + "and" + Input.mousePosition.y + "and" + transform.right);
	}


}
