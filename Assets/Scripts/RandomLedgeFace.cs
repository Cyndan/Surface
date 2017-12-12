using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLedgeFace : MonoBehaviour 
{

	//Generates a random number. 50% chance to face the opposite direction for variety.
	void Start () 
	{
		int number = Random.Range(1, 10);
		if (number >= 6)
		{
			gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
		}
	}
	

}
