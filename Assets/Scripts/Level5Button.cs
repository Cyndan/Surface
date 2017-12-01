using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Button : MonoBehaviour 
{
	public GameObject affectedBlock;
	public GameObject affectedBlockTwo;
	public GameObject soughtCollider;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(affectedBlock);
			Destroy(gameObject);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == soughtCollider)
		{
			affectedBlockTwo.SetActive(false);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == soughtCollider)
		{
			affectedBlockTwo.SetActive(true);
		}
	}
}
