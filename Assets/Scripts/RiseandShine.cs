using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseandShine : MonoBehaviour 
{
	public Pause pauseScript;
	private bool inProgress = false;
	private float startTime;
	private float moveTime = 6.5f;

	void Update ()
	{
		if (inProgress)
		{
			Rise();
		}
	}

	public void Rise()
	{
		if (!inProgress)
		{
			startTime = Time.time;
		}
		inProgress = true;
		if (Time.time > startTime + moveTime)
		{
			pauseScript.animFinished = true;
			Debug.Log("Anim Finished.");
			inProgress = false;
		}
	}
}
