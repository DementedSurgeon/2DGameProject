using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronController : MonoBehaviour {

	public List<PatronData> patrons;

	// Use this for initialization
	void Start () {
		patrons = new List<PatronData>();

		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,false,false,5));
		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,true,false,5));
		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,false,true,5));
		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,true,true,5));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,false,false,5));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,true,false,5));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,false,true,5));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,true,true,5));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,false,false,5));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,true,false,5));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,false,true,5));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,true,true,5));
	}

	public PatronData GetRandomData()
	{
		PatronData temp = patrons[Random.Range(0, patrons.Count)];
		return temp;
	}
}
