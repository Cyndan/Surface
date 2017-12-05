using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	public GameObject player;
	public GameObject model;
	public Transform neededRot;
	private bool xboxStart;
	public bool paused = false;
	public GameObject pauseHud;


	private bool titleScreen = true;
	public GameObject titleHud;
	public Animator anim;
	//public Animation animController;
	[HideInInspector] public bool animFinished = false;

	public AudioSource bgmObject;
	public AudioClip normalbgm;
	public AudioClip titlebgm;

	private float fadeValue = 0.05f;
	private float fadeSpeed = 0.1f;
	private float fadeTarget = 0.65f;

	private bool fadingIn = false;
	private bool fadingOut = false;

	void Start () 
	{
		//When the game launches, we're set to paused sans the pause screen.
		player.GetComponent<PlayerMove>().paused = true;
		pauseHud.SetActive(false);
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
			pauseHud.SetActive(true);
			Time.timeScale = 0;
		}
		else if (xboxStart && paused == true && titleScreen == false)
		{
			player.GetComponent<PlayerMove>().paused = false;
			paused = false;
			pauseHud.SetActive(false);
			Time.timeScale = 1;
		}

		if (titleScreen == true && xboxStart)
		{
			player.GetComponent<PlayerMove>().paused = false;
			titleScreen = false;
			titleHud.SetActive(false);
			fadingOut = true;
			anim.SetTrigger("GetUp");
		}

		//Play this once we finish our get up animation to start the game.
		if (animFinished)
		{
			player.GetComponent<PlayerMove>().paused = false;
			model.GetComponent<Animator>().SetTrigger("Risen");
			//model.transform.rotation = neededRot.rotation;
			animFinished = false;
		}


		//AudioClip stuff.
		if (bgmObject.volume > fadeValue && fadingOut)
		{

			// Fade out current clip.
			bgmObject.volume -= fadeSpeed * Time.deltaTime;
		}
		else if (fadingOut && bgmObject.volume <= fadeValue)
		{
			// Start fading in next clip.
			bgmObject.clip = normalbgm;
			fadingIn = true;
			bgmObject.Play();
			fadingOut = false;
		}



		if (bgmObject.volume < fadeTarget && fadingIn)
		{
			// Fade in next clip.
			bgmObject.volume += fadeSpeed * Time.deltaTime;
		}
		else if (fadingIn && bgmObject.volume >= fadeTarget)
		{
			// Stop fading in.
			bgmObject.volume = fadeTarget;
			fadingIn = false;
		}
	}
}
