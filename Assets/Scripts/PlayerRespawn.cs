using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{

	public GameObject player;
	public Transform respawnPoint;

	[HideInInspector] public int deathCount = 0;
	private int prevDeathCount;

	public float respTime = 3.0f;
	private float toResp = 0.0f;
	private bool respawning = false;

	public GameObject playerObject;

	void Start ()
	{
	}

	void Update () 
	{
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (deathCount > prevDeathCount && !respawning)
		{
			respawning = true;
			toResp = Time.time + respTime;
			gameObject.GetComponent<AudioSource>().Play();
			Respawn();
		}

		if (respawning)
		{
			Respawn();
		}

		prevDeathCount = deathCount;
	}

	void Respawn()
	{
		if (Time.time >= toResp)
		{
			Debug.Log("Death count: " + deathCount);
			Instantiate(playerObject, respawnPoint.position, respawnPoint.rotation, gameObject.transform);
			respawning = false;
		}
	}
}
