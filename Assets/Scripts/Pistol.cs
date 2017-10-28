using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, GunInterface {

	[Header("Ammo Pool")]
	public ProjPool magazine;

	[Space(10)]
	[Header("Stats")]
	public float reloadTime;
	public float shotCooldown;
	public int ammoPool;
	public int clip;
	private int clipSize;

	private float cooldownTimer = 0;
	private float reloadTimer = 0;
	private int mode = 1;

	// Use this for initialization
	void Start () {
		clipSize = clip;
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

		if (Input.GetMouseButtonDown (0) && cooldownTimer <= 0 && reloadTimer <= 0) {
			FireGun ();
			cooldownTimer = shotCooldown;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Reload ();
		}
	}

	public void FireGun()
	{
		if (clip > 0)
		{
			magazine.Find (mode);
			clip--;
		}
	}

	public void Reload()
	{
		if (reloadTimer <= 0) {
			reloadTimer = reloadTime;
			ammoPool = ammoPool - (clipSize - clip);
			clip = clipSize;
			if (ammoPool < 0) {
				clip += ammoPool;
				ammoPool = 0;
			}
		}
	}

	public int GetMagSize()
	{
		return clip;
	}

	public int GetMaxMagSize()
	{
		return ammoPool;
	}
}
