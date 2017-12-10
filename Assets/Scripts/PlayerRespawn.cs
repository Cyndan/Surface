using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{

	public GameObject player;
	public Transform respawnPoint;

	public GameObject worldA;
	public GameObject worldB;

	[HideInInspector] public int deathCount = 0;
	private int prevDeathCount;

	public float respTime = 3.0f;
	private float toResp = 0.0f;
	private bool respawning = false;

	public GameObject playerPrefab;
	public AudioClip meow;

	void Awake ()
	{
		//worldA = GameObject.FindWithTag("WorldA");
		//worldB = GameObject.FindWithTag("WorldB");
	}

	void Update () 
	{
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (player != null)
		{
			player.GetComponent<WorldShift>().WorldA = worldA;
			player.GetComponent<WorldShift>().WorldB = worldB;
		}

		if (deathCount > prevDeathCount && !respawning)
		{
			toResp = Time.time + respTime;
			gameObject.GetComponent<AudioSource>().clip = meow;
			gameObject.GetComponent<AudioSource>().Play();
			Respawn();
			respawning = true;
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
			Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation, gameObject.transform);
			respawning = false;
		}
	}
}
