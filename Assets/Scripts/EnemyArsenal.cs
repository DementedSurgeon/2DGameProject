using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArsenal : MonoBehaviour {

	public Gun[] weaponry;
	public AmmoDisplay display;
	public ProjPool ammoPool;
	public bool isEnemy = false;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAmmoPool (ProjPool newAmmo)
	{
		ammoPool = newAmmo;
	}

	public void FireGun()
	{
		weaponry [activeWeapon].FireGun ();
		weaponry [activeWeapon].Reload ();
		weaponry [activeWeapon].ammoPool++;
	}
}
