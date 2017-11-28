using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	public GameObject player;
	public bool xboxStart;
	public bool paused = false;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		xboxStart = Input.GetButtonDown("Pause");
		if (GameObject.FindWithTag("Player") == false)
			{
				player = GameObject.FindWithTag("Player");
			}

		if (xboxStart && paused == false)
		{
			player.GetComponent<PlayerMove>().paused = true;
			paused = true;
			Time.timeScale = 0;
		}
		else if (xboxStart && paused == true)
		{
			player.GetComponent<PlayerMove>().paused = false;
			paused = false;
			Time.timeScale = 1;
		}
	}
}
