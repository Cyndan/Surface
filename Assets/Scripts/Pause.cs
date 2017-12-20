using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour 
{
	public GameObject player;
	private bool xboxStart;
	public bool paused = false;
	public GameObject pauseHud;

	//For fading the title screen.
	private float titleFadeDur = 5.0f;
	private float startTime;
	private bool fadingScreen;
	public Image titleSprite;
	public AudioSource sound;

	private bool titleScreen = true;
	public GameObject titleHud;
	public Animator anim;
	[HideInInspector] public bool animFinished = false;
	public RiseandShine riseScript;

	public AudioSource bgmObject;
	public AudioClip normalbgm;
	public AudioClip titlebgm;

	//For fading audio.
	private float fadeValue = 0.05f;
	private float fadeSpeed = 0.1f;
	private float fadeTarget = 0.25f;
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
				anim = GameObject.FindWithTag("PlayerAnim").GetComponent<Animator>();
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
			sound.Play();
			//player.GetComponent<PlayerMove>().paused = false;
			riseScript.Rise();
			titleScreen = false;
			fadingOut = true;
			anim.SetTrigger("GetUp");

			startTime = Time.time;
			fadingScreen = true;
		}

		if (fadingScreen)
		{
			ScreenFade();
		}

		//Play this once we finish our get up animation to start the game.
		if (animFinished)
		{
			player.GetComponent<PlayerMove>().paused = false;
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

	void ScreenFade()
	{
		float t = (Time.time - startTime) / titleFadeDur;
		titleSprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(1F, 0F, t));
	}
}
