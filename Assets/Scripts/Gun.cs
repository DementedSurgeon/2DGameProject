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


	public virtual int GetMagSize ()
	{
		return 0;//code
	}
	 
	public virtual int GetMaxMagSize ()
	{
		return 0;//code
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
