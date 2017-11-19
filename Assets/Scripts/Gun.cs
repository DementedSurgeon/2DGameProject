using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour{

	public int ammoPool;

	public virtual void FireGun ()
	{
		//code
	}

	public virtual void Reload ()
	{
		//code
	}

	public virtual bool GetReloadStatus()
	{
		return true;
	}

	public virtual int GetMagSize ()
	{
		return 0;//code
	}

	public virtual int GetClipMax()
	{
		return 0;
	}
	 
	public virtual string GetMaxMagSize ()
	{
		return "a";//code
	}


	public virtual int GetSpread()
	{
		return 0;//code
	}


	public virtual int GetPellets()

	{
		return 0;//code
	}


	public virtual void SetProjPool (ProjPool newPool){
		//code
	}

	public virtual void SetUser (bool newUser)
	{

	}

	public virtual string GetName ()
	{
		return "a";
	}
}
