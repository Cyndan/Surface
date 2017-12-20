using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour 
{
	public bool redorb;
	public bool yellorb;
	public AbilityManager manager;

	void OnCollisionEnter (Collision other)
	{
		if (redorb)
		{
			WorldShift shift = other.gameObject.GetComponent<WorldShift>();
			manager.canShift = true;
			shift.PhaseShift();
		}

		if (yellorb)
		{
			manager.canGrapple = true;
		}

		Destroy(gameObject);
	}
}
