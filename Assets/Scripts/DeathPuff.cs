using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPuff : MonoBehaviour 
{
	private float toDie;
	private float deathTimer = 1.0f;

	void Start () 
	{
		toDie = deathTimer + Time.time;
	}
	

	void Update () 
	{
		if (Time.time > toDie)
		{
			Destroy(gameObject);
		}
	}
}
