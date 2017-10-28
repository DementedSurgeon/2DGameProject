using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class GunInterface : MonoBehaviour {

	[Header("Ammo Pool")]
	public ProjPool magazine;

	[Space(10)]
	[Header("Stats Stats")]
	public float reload;
	public float cooldown;
	public int ammoPool;
	public int clip;
	protected int clipSize;

	protected float cooldownTimer = 0;
	protected float reloadTimer = 0;

	// Use this for initialization
	void Start () {
		clipSize = clip;
	}

	// Update is called once per frame
	void Update () {
		if (cooldownTimer > 0) {
			cooldownTimer -= Time.deltaTime;
		}
		if (reloadTimer > 0) {
			reloadTimer -= Time.deltaTime;
		}
		if (Input.GetMouseButton (0) && cooldownTimer <= 0 && reloadTimer <= 0) {
			//fireInput code goes here
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Reload ();
		}

	}

	void FireGun()
	{
		//content
	}

	void Reload ()
	{
		if (reloadTimer <= 0) {
			if (ammoPool > 0) {
				reloadTimer = reload;
				ammoPool = ammoPool - (clipSize - clip);
				clip = clipSize;
				if (ammoPool < 0) {
					clip += ammoPool;
					ammoPool = 0;
				}
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
