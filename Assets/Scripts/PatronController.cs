using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronController : MonoBehaviour {

	public List<PatronData> patrons;

	private int counter = 0;


	void Awake()
	{
		patrons = new List<PatronData>();

		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,false,false,5,2));
		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,true,false,5,2));
		patrons.Add(new PatronData(new Vector2(-10,4.5f),new Vector2(0,0),new Vector2(10,4.5f),false,false,true,3,2));
		patrons.Add(new PatronData(new Vector2(-10,3.5f),new Vector2(0,0),new Vector2(10,3.5f),false,true,true,5,2));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,false,false,5,2));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,true,false,5,2));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,false,true,5,2));
		patrons.Add(new PatronData(new Vector2(7,-5),new Vector2(0,0),new Vector2(7,5),false,true,true,5,2));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,false,false,5,2));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,true,false,5,2));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,false,true,2,2));
		patrons.Add(new PatronData(new Vector2(-10,5),new Vector2(6,-4),new Vector2(10,5),true,true,true,3,2));
	}
	// Use this for initialization
	void Start () {
		
	}

	public PatronData GetRandomData()
	{
		PatronData temp = patrons[0];
		if (counter == 0) {
			temp = patrons [2];
			counter++;
		} else if (counter == 1) {
			temp = patrons [11];
			counter--;
		}
		return temp;
	}
}
