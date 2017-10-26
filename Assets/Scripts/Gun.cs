using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public ProjPool magazine;
	public int magazineSize;

	public float pistolCooldown;
	public float mgCooldown;
	public float shotgunCooldown;

	public float pistolReload;
	public float mgReload;
	public float shotgunReload;

	private int maxMagazineSize;
	private int mode = 1;
	private float cooldownTimer = 0;
	private float reloadTimer = 0;

	// Use this for initialization
	void Start () {
		maxMagazineSize = magazineSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownTimer > 0) {
			cooldownTimer -= Time.deltaTime;
		}
		if (reloadTimer > 0)
		{
			reloadTimer -= Time.deltaTime;
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

		if (Input.GetMouseButton (0) && cooldownTimer <= 0 && reloadTimer <= 0) {
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
			magazine.Find (mode);
			magazineSize--;
		}
	}

	void FireShotgun()
	{
		if (magazineSize >= 5) {
			for (int i = 0; i < 5; i++) {
				magazine.Find (mode);
				magazineSize--;
			}
		}
	}

	void Reload ()
	{
		if (reloadTimer <= 0) {
			magazineSize = maxMagazineSize;
			if (mode == 1) {
				reloadTimer = pistolReload;
			} else if (mode == 2) {
				reloadTimer = mgReload;
			} else if (mode == 3) {
				reloadTimer = shotgunReload;
			}
		}
	}
}
