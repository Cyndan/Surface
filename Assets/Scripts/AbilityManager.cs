using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour 
{
	public GameObject player;
	public bool canGrapple = false;
	public bool canShift = false;

	public Image shiftUI;
	public Image grappleUI;

	public Sprite shift0;
	public Sprite shift1;
	public Sprite shift2;
	public Sprite shift3;
	public Sprite shift4;
	public Sprite shift5;
	public Sprite shift6;
	public Sprite shiftFull;

	public Sprite grab0;
	public Sprite grab1;
	public Sprite grab2;
	public Sprite grab3;
	public Sprite grab4;
	public Sprite grab5;
	public Sprite grab6;
	public Sprite grabFull;


	void Update () 
	{
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (player != null)
		{
			if (!canGrapple)
			{
				player.GetComponent<PlayerGrapple>().enabled = false;
				grappleUI.enabled = false;
			}
			else if (canGrapple)
			{
				player.GetComponent<PlayerGrapple>().enabled = true;
				grappleUI.enabled = true;
			}

			if (!canShift)
			{
				player.GetComponent<WorldShift>().enabled = false;
				shiftUI.enabled = false;
			}
			else if (canShift)
			{
				player.GetComponent<WorldShift>().enabled = true;
				shiftUI.enabled = true;
			}
		}


	}
}
