using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	public GameObject player;
	private bool xboxStart;
	public bool paused = false;
	private bool titleScreen = true;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		//Set up our input. Also check if the player is currently alive, first. If not, we try and locate the player.
		xboxStart = Input.GetButtonDown("Pause");
		if (GameObject.FindWithTag("Player") == false)
			{
				player = GameObject.FindWithTag("Player");
			}

		//If we aren't paused, pause. If we are, unpause.
		if (xboxStart && paused == false && titleScreen == false)
		{
			player.GetComponent<PlayerMove>().paused = true;
			paused = true;
			Time.timeScale = 0;
		}
		else if (xboxStart && paused == true && titleScreen == false)
		{
			player.GetComponent<PlayerMove>().paused = false;
			paused = false;
			Time.timeScale = 1;
		}
	}
}
