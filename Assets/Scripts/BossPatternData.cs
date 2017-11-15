using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternData {

	public float speed;
	public float sinArc;
	public float sinSpeed;
	public bool horizontal;

	public BossPatternData(float speed, float sinArc, float sinSpeed, bool horizontal)
	{
		this.speed = speed;
		this.sinArc = sinArc;
		this.sinSpeed = sinSpeed;
		this.horizontal = horizontal;
	}
}
