using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour 
{
	public bool redorb;
	public bool yellorb;
	public AbilityManager manager;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	void OnCollisionEnter (Collision other)
	{
		if (redorb)
		{
			manager.canShift = true;
		}

		if (yellorb)
		{
			manager.canGrapple = true;
		}

		Destroy(gameObject);
	}
}
