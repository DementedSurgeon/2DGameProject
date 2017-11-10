using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronData 
{
	public Vector2 startPos;
	public Vector2 midPos;
	public Vector2 endPos;

	public bool parabola = false;
	public bool reverseX = false;
	public bool reverseY = false;
	public float time;
	public float globalTimerDelay;

	public PatronData(Vector2 startPos, Vector2 midPos, Vector2 endPos, bool parabola, bool reverseX, bool reverseY, float time, float globalTimerDelay)
	{
		this.startPos = startPos;
		this.midPos = midPos;
		this.endPos = endPos;
		this.parabola = parabola;
		this.reverseX = reverseX;
		this.reverseY = reverseY;
		this.time = time;
		this.globalTimerDelay = globalTimerDelay;
	}
}
