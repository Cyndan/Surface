using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour 
{
	public GameObject player;
	public bool canGrapple = false;
	public bool canShift = false;


	void Update () 
	{
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (!canGrapple)
		{
			player.GetComponent<PlayerGrapple>().enabled = false;
		}
		else if (canGrapple)
		{
			player.GetComponent<PlayerGrapple>().enabled = true;
		}

		if (!canShift)
		{
			player.GetComponent<WorldShift>().enabled = false;
		}
		else if (canShift)
		{
			player.GetComponent<WorldShift>().enabled = true;
		}

	}
}
