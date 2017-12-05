using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseandShine : MonoBehaviour 
{
	public Pause pauseScript;

	public void Rise()
	{
		pauseScript.animFinished = true;
		Debug.Log("Anim Finished.");
	}
}
