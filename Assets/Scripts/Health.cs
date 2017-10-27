using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health;

	private Rigidbody2D rgbd;

	// Use this for initialization
	void Start () {
		rgbd = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	public void Hurt(float trs){
		health--;
		if (transform.position.x < trs) {
			rgbd.AddForce (new Vector2(-50, 0));
		} else if (transform.position.x > trs) {
			rgbd.AddForce (new Vector2(50, 0));
		}
	}
}
