using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public ProjPool magazine;
	public int magazineSize;
	public float pistolCooldown;
	public float mgCooldown;
	public float shotgunCooldown;

	private int maxMagazineSize;
	private int mode = 1;
	private float cooldownTimer = 0;

	// Use this for initialization
	void Start () {
		maxMagazineSize = magazineSize;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (cooldownTimer);
		if (cooldownTimer > 0) {
			cooldownTimer -= Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mode = 1;
		}
		else  if (Input.GetKeyDown (KeyCode.Alpha2)) {
			mode = 2;
		}
		else  if (Input.GetKeyDown (KeyCode.Alpha3)) {
			mode = 3;
		}

		if (Input.GetMouseButton (0) && cooldownTimer <= 0) {
			if (mode == 1) {
				if (Input.GetMouseButtonDown (0)) {
					FireGun ();
					cooldownTimer = pistolCooldown;
				}
			} else if (mode == 2) {
				FireGun ();
				cooldownTimer = mgCooldown;
			} else if (mode == 3) {
				FireShotgun ();
				cooldownTimer = shotgunCooldown;
			}
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

	void FireShotgun()
	{
		if (magazineSize >= 5) {
			for (int i = 0; i < 5; i++) {
				magazine.Find ();
				magazineSize--;
			}
		}
	}

	void Reload ()
	{
		magazineSize = maxMagazineSize;
	}
}
