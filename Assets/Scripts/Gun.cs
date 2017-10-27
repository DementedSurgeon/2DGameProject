using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public ProjPool magazine;
	public int magazineSize;

	public float pistolCooldown;
	public float mgCooldown;
	public float shotgunCooldown;

	public int pistolAmmoPool;
	public int pistolClip;
	private int pistolClipSize;

	public int mgAmmoPool;
	public int mgClip;
	private int mgClipSize;

	public int shotgunAmmoPool;
	public int shotgunClip;
	private int shotgunClipSize;

	public float pistolReload;
	public float mgReload;
	public float shotgunReload;

	public int shotgunPellets;

	private int maxMagazineSize;
	private int mode = 1;
	private float cooldownTimer = 0;
	private float reloadTimer = 0;

	// Use this for initialization
	void Start () {
		maxMagazineSize = magazineSize;
		pistolClipSize = pistolClip;
		mgClipSize = mgClip;
		shotgunClipSize = shotgunClip;
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

	void FireGun()
	{
		if (mode == 1) {
			if (pistolClip > 0) {
				magazine.Find (mode);
				pistolClip--;
			}
		} else if (mode == 2) {
			if (mgClip > 0) {
				magazine.Find (mode);
				mgClip--;
			}
		}
	}


	void FireShotgun()
	{
		if (shotgunClip >= shotgunPellets) {
			for (int i = 0; i < shotgunPellets; i++) {
				magazine.Find (mode);
				shotgunClip--;
			}
		}
	}

	void Reload ()
	{
		if (reloadTimer <= 0) {
			if (mode == 1 && pistolAmmoPool > 0) {
				reloadTimer = pistolReload;
				pistolAmmoPool = pistolAmmoPool - (pistolClipSize - pistolClip);
				pistolClip = pistolClipSize;
				if (pistolAmmoPool < 0) {
					pistolClip += pistolAmmoPool;
					pistolAmmoPool = 0;
				}
			} else if (mode == 2 && mgAmmoPool > 0) {
				reloadTimer = mgReload;
				mgAmmoPool = mgAmmoPool - (mgClipSize - mgClip);
				mgClip = mgClipSize;
				if (mgAmmoPool < 0) {
					mgClip += mgAmmoPool;
					mgAmmoPool = 0;
				}
			} else if (mode == 3 && shotgunAmmoPool > 0) {
				reloadTimer = shotgunReload;
				shotgunAmmoPool = shotgunAmmoPool - (shotgunClipSize - shotgunClip);
				shotgunClip = shotgunClipSize;
				if (shotgunAmmoPool < 0) {
					shotgunClip += shotgunAmmoPool;
					shotgunAmmoPool = 0;
				}
			}
		}
	}

	public int GetSpread()
	{
		return shotgunPellets;
	}

	public int GetMagSize()
	{
		return magazineSize;
	}

	public int GetMaxMagSize()
	{
		return maxMagazineSize;
	}
}
