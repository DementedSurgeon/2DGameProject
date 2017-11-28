﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG : Gun {
	[Header("Ammo Pool")]
	private ProjPool magazine;

	private bool isEnemy = false;

	[Space(10)]
	[Header("Stats")]
	public float reloadTime;
	public float shotCooldown;
	public int clip;
	[Range(3,5)]
	public int spreadReset = 3;
	[Range(3,5)]
	public int spread = 3;
	private int clipSize;

	private string gunName = "MG";

	private float cooldownTimer = 0;
	private float reloadTimer = 0;
	private int mode = 3;
	private Transform startPos;
	private GunSounds gSounds;

	// Use this for initialization
	void Start () {
		clipSize = clip;
		startPos = transform.GetChild(0).GetComponent<Transform> ();
		if (gameObject.GetComponent<GunSounds> () != null) {
			gSounds = gameObject.GetComponent<GunSounds> ();
		}
		//magazine.SetGun (this);
	}

	// Update is called once per frame
	void Update () {
		if (cooldownTimer > 0) {
			cooldownTimer -= Time.deltaTime;
		}
		if (reloadTimer > 0)
		{
			reloadTimer -= Time.deltaTime;
			if (reloadTimer <= 0) {
				ammoPool = ammoPool - (clipSize - clip);
				clip = clipSize;
				if (ammoPool < 0) {
					clip += ammoPool;
					ammoPool = 0;
				}
			}
		}

	}

	override public void FireGun()
	{
		if (!isEnemy) {
			if (Input.GetMouseButton (0) && cooldownTimer <= 0 && reloadTimer <= 0) {
				if (clip > 0) {
					magazine.Find (mode, startPos, spread, spreadReset);
					clip--;
					gSounds.Play (0);
				} else if (clip == 0) {
					Reload ();
				}
				cooldownTimer = shotCooldown;

			}
		} else if (isEnemy) {
			if (clip > 0) {
				magazine.Find (mode, startPos, spread, spreadReset);

			}
			cooldownTimer = shotCooldown;
		}
	}

	override public void Reload()
	{
		if (reloadTimer <= 0 && ammoPool > 0) {
			reloadTimer = reloadTime;

		}
	}

	override public bool GetReloadStatus()
	{
		bool temp = false;
		if (reloadTimer > 0) {
			temp = true;
		}

		return temp;
	}

	override public int GetMagSize()
	{
		return clip;
	}

	override public int GetClipMax()
	{
		return clipSize;
	}

	override public string GetMaxMagSize()
	{
		return ammoPool.ToString();
	}

	override public void SetProjPool(ProjPool newPool)
	{
		magazine = newPool;
	}

	override public int GetSpread()
	{
		return spread;
	}

	override public int GetPellets()
	{
		return spreadReset;
	}

	override public void SetUser(bool newUser)
	{
		isEnemy = newUser;
	}

	override public string GetName()
	{
		return gunName;
	}
}
