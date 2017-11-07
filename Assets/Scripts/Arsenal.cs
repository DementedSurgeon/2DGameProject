using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Arsenal : MonoBehaviour {
	
	public Gun[] weaponry;
	public AmmoDisplay display;
	public ProjPool ammoPool;
	public bool isEnemy = false;
	public bool usesVector = false;
	public Vector2 triggerVector;
	public float timerDelay = 0;
	private float timer = 15;
	private int activeWeapon = 0;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < weaponry.Length; i++) {
			weaponry [i].SetProjPool (ammoPool);
			weaponry [i].SetUser (isEnemy);
		}
		if (display != null) {
			display.GetGun (weaponry [activeWeapon]);
		}
		timer = timerDelay;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (isEnemy) {
			if (!usesVector) {
				if (timer > 0) {
					timer -= Time.deltaTime;
					if (timer <= 0) {
						weaponry [activeWeapon].FireGun ();
						weaponry [activeWeapon].Reload ();
						timer = timerDelay;
						Debug.Log ("Arsenal Works");
					}
				}
			} else if (usesVector) {
				if (Vector2.Distance (transform.position, triggerVector) <= 0.1f) {
					weaponry [activeWeapon].FireGun ();
					weaponry [activeWeapon].Reload ();
				}
			}
		}


		else if (!isEnemy) {
			if (Input.GetMouseButton (0)) {
				weaponry [activeWeapon].FireGun ();
			}

			if (Input.GetKeyDown (KeyCode.R)) {
				weaponry [activeWeapon].Reload ();
			}

			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				activeWeapon = 0;
				if (display != null) {
					display.GetGun (weaponry [activeWeapon]);
				}
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				if (weaponry [1] != null) {
					activeWeapon = 1;
					if (display != null) {
						display.GetGun (weaponry [activeWeapon]);
					}
				} 
					}
			else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				if (weaponry [2] != null) {
					activeWeapon = 2;
					if (display != null) {
						display.GetGun (weaponry [activeWeapon]);
					}
				}
			}

			if (Input.GetKeyDown (KeyCode.Q)) {
				activeWeapon--;
				if (activeWeapon < 0) {
					activeWeapon = weaponry.Length - 1;
				}
				display.GetGun (weaponry [activeWeapon]);
			} else if (Input.GetKeyDown (KeyCode.E)) {
				activeWeapon++;
				if (activeWeapon == weaponry.Length) {
					activeWeapon = 0;
				}
				display.GetGun (weaponry [activeWeapon]);
			}
				
		}
	}

	public void SetAmmoPool (ProjPool newAmmo)
	{
		ammoPool = newAmmo;
	}
}
