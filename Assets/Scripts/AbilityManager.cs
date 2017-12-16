using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour 
{
	public GameObject player;
	public bool canGrapple = false;
	public bool canShift = false;

	public Image shiftUI;
	public Image grappleUI;
	[HideInInspector] public float shiftBar;
	[HideInInspector] public float grappleBar;

	public Sprite shift0;
	public Sprite shift1;
	public Sprite shift2;
	public Sprite shift3;
	public Sprite shift4;
	public Sprite shift5;
	public Sprite shift6;
	public Sprite shift7;
	public Sprite shiftFull;

	public Sprite grab0;
	public Sprite grab1;
	public Sprite grab2;
	public Sprite grab3;
	public Sprite grab4;
	public Sprite grab5;
	public Sprite grab6;
	public Sprite grab7;
	public Sprite grabFull;

	public Image flash;
	private float fadeDur = 0.75f;
	private float darkFadeDur = 2.5f;
	private float startTime;
	private float dStartTime;
	private bool flashDown;
	private bool flashing;
	private bool dFlashDown;
	private bool dFlashing;
	//public AudioClip flashSound;

	void Update () 
	{ 
		if (GameObject.FindWithTag("Player") == false || player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		if (player != null)
		{
			if (!canGrapple)
			{
				player.GetComponent<PlayerGrapple>().enabled = false;
				grappleUI.enabled = false;
			}
			else if (canGrapple)
			{
				player.GetComponent<PlayerGrapple>().enabled = true;
				grappleUI.enabled = true;
			}

			if (!canShift)
			{
				player.GetComponent<WorldShift>().enabled = false;
				shiftUI.enabled = false;
			}
			else if (canShift)
			{
				player.GetComponent<WorldShift>().enabled = true;
				shiftUI.enabled = true;
			}
		}
		if (flashing)
		{
			Flash();
		}
		if (dFlashing)
		{
			DarkFlash();
		}
		UIBar();
	}

	public void Flash()
	{
		if (!flashing)
		{
			startTime = Time.time;
		}

		if (!flashDown)
		{
			float t = (Time.time - startTime) / (fadeDur * 0.05f);
			flashing = true;
			flash.color = new Color(1f,1f,1f,Mathf.SmoothStep(0F, 1F, t));
			if (Time.time > startTime + (fadeDur * 0.05f))
			{
				startTime = Time.time;
				flashDown = true;
			}
		}
		else
		{
			float t = (Time.time - startTime) / fadeDur;
			flash.color = new Color(1f,1f,1f,Mathf.SmoothStep(1F, 0F, t));
			if (Time.time > startTime + fadeDur)
			{
				flashDown = false;
				flashing = false;
			}
		}
	}

	public void DarkFlash()
	{
		if (!dFlashing)
		{
			dStartTime = Time.time;
		}
		if (!dFlashDown)
		{
			float t = (Time.time - startTime) / (darkFadeDur);
			dFlashing = true;
			flash.color = new Color(-1f,-1f,-1f,Mathf.SmoothStep(0F, 1F, t));
			if (Time.time > startTime + (darkFadeDur + 0.5f))
			{
				startTime = Time.time;
				dFlashDown = true;
			}
		}
		else
		{
			float t = (Time.time - startTime) / (darkFadeDur * 0.33f);
			flash.color = new Color(-1f,-1f,-1f,Mathf.SmoothStep(1F, 0F, t));
			if (Time.time > startTime + (darkFadeDur * 0.33f))
			{
				dFlashDown = false;
				dFlashing = false;
			}
		}
	}

	void UIBar()
	{
		if (Time.time > shiftBar)
		{
			shiftUI.sprite = shiftFull;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.125f)
		{
			shiftUI.sprite = shift0;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.25f)
		{
			shiftUI.sprite = shift1;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.375f)
		{
			shiftUI.sprite = shift2;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.5f)
		{
			shiftUI.sprite = shift3;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.625f)
		{
			shiftUI.sprite = shift4;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.75f)
		{
			shiftUI.sprite = shift5;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 0.875f)
		{
			shiftUI.sprite = shift6;
		}
		else if (((shiftBar- Time.time) / 1.0f ) <= 1.0f)
		{
			shiftUI.sprite = shift7;
		}


		if (Time.time > grappleBar)
		{
			grappleUI.sprite = grabFull;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.125f)
		{
			grappleUI.sprite = grab0;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.25f)
		{
			grappleUI.sprite = grab1;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.375f)
		{
			grappleUI.sprite = grab2;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.5f)
		{
			grappleUI.sprite = grab3;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.625f)
		{
			grappleUI.sprite = grab4;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.75f)
		{
			grappleUI.sprite = grab5;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 0.875f)
		{
			grappleUI.sprite = grab6;
		}
		else if (((grappleBar - Time.time) / 1.0f ) <= 1.0f)
		{
			grappleUI.sprite = grab7;
		}

	}

}
