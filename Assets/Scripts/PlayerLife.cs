using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour 
{
	public PlayerRespawn respawnScript;
	private bool hit;

	void Start ()
	{
		respawnScript = GameObject.FindWithTag("GameController").GetComponent<PlayerRespawn>();
	}

	void Update ()
	{
		if (gameObject.transform.position.y < -20.0f && !hit)
		{
			hit = true;
			respawnScript.deathCount++;
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Hazard" && !hit)
		{
			hit = true;
			respawnScript.deathCount++;
			Destroy(gameObject);
		}

		if (other.tag == "Respawn")
		{
			respawnScript.respawnPoint = other.transform;
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Hazard" && !hit)
		{
			hit = true;
			respawnScript.deathCount++;
			Destroy(gameObject);
		}
	}
}
