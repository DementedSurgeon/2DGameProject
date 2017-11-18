using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Pantalla ayuda. Y instrucciones para jugar (recargar etc)
Inbgrar artes para ultimos botones
musica y sonido


 * */


public class OldGun : Gun  {

	[Header("Ammo Pool")]
	public ProjPool magazine;

	[Space(10)]
	[Header("Pistol Stats")]
	public float pistolReload;
	public float pistolCooldown;
	public int pistolAmmoPool;
	public int pistolClip;
	private int pistolClipSize;
	[Space(10)]
	[Header("MG Stats")]
	public float mgReload;
	public float mgCooldown;
	public int mgAmmoPool;
	public int mgClip;
	private int mgClipSize;
	[Space(10)]
	[Header("Shotgun Stats")]
	public float shotgunReload;
	public float shotgunCooldown;
	public int shotgunAmmoPool;
	public int shotgunClip;
	private int shotgunClipSize;
	public int shotgunSpread;
	[Range(3,10)]
	public int shotgunPellets;


	private int mode = 1;
	private float cooldownTimer = 0;
	private float reloadTimer = 0;
	private Transform startPos;

	// Use this for initialization
	void Start () {
		pistolClipSize = pistolClip;
		mgClipSize = mgClip;
		shotgunClipSize = shotgunClip;
		startPos = transform.GetChild(0).GetComponent<Transform> ();
		//magazine.SetGun (gameObject.GetComponent<Gun> ());
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

	override public void FireGun()
	{
		if (mode == 1) {
			if (pistolClip > 0) {
				magazine.Find (mode, startPos, shotgunSpread, shotgunPellets);
				pistolClip--;
			}
		} else if (mode == 2) {
			if (mgClip > 0) {
				magazine.Find (mode, startPos, shotgunSpread, shotgunPellets);
				mgClip--;
			}
		}
	}


	void FireShotgun()
	{
		if (shotgunClip > 0) {
			for (int i = 0; i < shotgunPellets; i++) {
				magazine.Find (mode, startPos, shotgunSpread, shotgunPellets);
			}
			shotgunClip--;
		}
	}

	override public void Reload ()
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

	override public int GetSpread()
	{
		return shotgunSpread;
	}
	override public int GetPellets()
	{
		return shotgunPellets;
	}

	override public int GetMagSize()
	{
		int magazineSize = 0;
		if (mode == 1) {
			magazineSize = pistolClip;
		} else if (mode == 2) {
			magazineSize = mgClip;
		} else if (mode == 3) {
			magazineSize = shotgunClip;
		}

		return magazineSize;
	}

	override public int GetMaxMagSize()
	{
		int maxMagazineSize = 0;
		if (mode == 1) {
			maxMagazineSize = pistolAmmoPool;
		} else if (mode == 2) {
			maxMagazineSize = mgAmmoPool;
		} else if (mode == 3) {
			maxMagazineSize = shotgunAmmoPool;
		}
		return maxMagazineSize;
	}

	override public void SetProjPool(ProjPool newPool)
	{
		magazine = newPool;
	}
}
