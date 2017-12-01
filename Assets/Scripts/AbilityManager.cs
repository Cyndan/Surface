using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour 
{
	public GameObject player;
	private bool canGrapple = false;
	private bool canShift = false;


	void Update () 
	{
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (canGrapple == false)
		{
			player.GetComponent<PlayerGrapple>().enabled = false;
		}
		else if (canGrapple == true)
		{
			player.GetComponent<PlayerGrapple>().enabled = true;
		}

		if (canShift == false)
		{
			player.GetComponent<WorldShift>().enabled = false;
		}
		else if (canShift == true)
		{
			player.GetComponent<WorldShift>().enabled = true;
		}
	}
}
