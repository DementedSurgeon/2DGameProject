using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjPool : MonoBehaviour {

	public GameObject prefab;
	public int ammoPool;

	//public Gun gun;
	private ProjectileBehaviour[] pool;


	// Use this for initialization
	void Start () {
		pool = new ProjectileBehaviour[ammoPool];
		for (int i = 0; i < pool.Length; i++) {
			pool [i] = Instantiate (prefab, transform.position, Quaternion.identity, transform).GetComponent<ProjectileBehaviour> ();

		}

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Find(int mode, Transform startPos, int spread, int reset){
		if (mode == 1 || mode == 2) {
			for (int i = 0; i < pool.Length; i++) {
				if (pool [i].GetIsFired () == false) {
					pool [i].SetStartPos (startPos);
					//pool [i].SetGun (gun);
					pool [i].FireBullet ();
					i = pool.Length;
			
				}
			}
		} else if (mode == 3) {
			for (int i = 0; i < pool.Length; i++) {
				if (pool [i].GetIsFired () == false) {
					pool [i].SetStartPos (startPos);
					//pool [i].SetGun (gun);
					pool [i].FireShotty (spread,reset);
					i = pool.Length;

				}
			}
		}
	}

	/*public void SetGun(Gun newGun)
	{
		gun = newGun;
	}*/
}
