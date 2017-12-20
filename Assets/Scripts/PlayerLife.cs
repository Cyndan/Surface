using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour 
{
	public PlayerRespawn respawnScript;
	public GameObject deathPuff;
	public GameObject tracer;
	private bool hit;

	void Start ()
	{
		respawnScript = GameObject.FindWithTag("GameController").GetComponent<PlayerRespawn>();
		tracer = GameObject.FindGameObjectWithTag("Tracer");
	}

	void Update ()
	{
		tracer.transform.position = gameObject.transform.position;

		if (gameObject.transform.position.y < -20.0f && !hit)
		{
			hit = true;
			respawnScript.deathCount++;
			Destroy(gameObject);
			Instantiate(deathPuff, tracer.transform);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Hazard" && !hit)
		{
			hit = true;
			respawnScript.deathCount++;
			Destroy(gameObject);
			Instantiate(deathPuff, tracer.transform.position, new Quaternion(0, 0, 0, 0));
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
			Instantiate(deathPuff, tracer.transform.position, new Quaternion(0, 0, 0, 0));
			Destroy(gameObject);
		}
	}
}
