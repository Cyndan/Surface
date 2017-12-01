using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingRubbleOne : MonoBehaviour 
{
	public Transform mushPos;
	public bool tethered;
	public bool willSpring;

	void Start()
	{

	}


	void Update () 
	{
		if (tethered)
		{
			gameObject.GetComponent<LineRenderer>().enabled = true;
			gameObject.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
			gameObject.GetComponent<LineRenderer>().SetPosition(1, mushPos.position);
		}
		else
		{
			gameObject.GetComponent<LineRenderer>().enabled = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Water")
		{
			if (!tethered && willSpring)
			{
				tethered = true;
				willSpring = false;
				gameObject.GetComponent<SpringJoint>().spring = 8.0f;
				gameObject.GetComponent<SpringJoint>().damper = 0.2f;
			}
			else if (tethered)
			{
				tethered = false;
				gameObject.GetComponent<SpringJoint>().spring = 0.0f;
				gameObject.GetComponent<SpringJoint>().damper = 0.0f;
			}
		}
	}
}
