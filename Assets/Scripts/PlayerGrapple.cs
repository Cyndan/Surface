using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour 
{
	//Set states for whether we are mid-grapple or mid-aim. Also the force to apply for our swing and max grapple distance.
	private bool isGrappling = false;
	private bool isAiming = false;
	public float swingForce = 12.0f;
	public float grappleLength = 10.0f;

	//Prep our input names.
	private float rsVert;
	private float rsHoriz;
	private float xboxRT;
	private bool xboxB;

	//We deal with a whole bunch of angle stuff here.
	private float aimAngle = 0;
	private Vector3 aimVector;
	private float aimTimeTarget = 1.0f;
	private float toAim = 0.0f;
	private bool canGrapple;

	//      MUSH DETECTED
	private bool mushDetected = false;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		//Set up all of our inputs that we need, so we don't need to keep using this command. Also Raycast bullshit.
		rsVert = Input.GetAxisRaw ("XboxRSHorizontal");
		rsHoriz = Input.GetAxisRaw ("XboxRSVertical");
		xboxRT = Input.GetAxisRaw ("XboxTriggers");
		xboxB = Input.GetButtonDown ("XboxB");
		RaycastHit hit;

		//After amount of time defined in "aimTimeTarget," we can grapple again.
		if (Time.time > toAim)
		{
			canGrapple = true;
		}

		//If our right stick is moved at all and we are not grappling, we grab our angle.
		if (rsVert != 0 || rsHoriz != 0 && !isGrappling)
		{
			isAiming = true;
			aimAngle = Mathf.Atan2(rsHoriz, rsVert) * Mathf.Rad2Deg;
			aimVector = new Vector3(0, 0, aimAngle);

			//Since we're aiming, let's also perform our Raycast. IS MUSH DETECTED?!
			if (Physics.Raycast(transform.position, aimVector, out hit, grappleLength))
			{
				if (hit.transform.tag == "Tether")
				{
					mushDetected = true;
				}
				else
				{
					mushDetected = false;
				}
			}


			if (xboxRT > 0 && canGrapple == true)
			{
				canGrapple = false;
				toAim = aimTimeTarget + Time.time;
				Grapple();
			}
		}
		else
		{
			isAiming = false;
			mushDetected = false;
		}
			

	}

	void Grapple()
	{
		isGrappling = true;
	}

	void GrappleAim()
	{

	}
}
