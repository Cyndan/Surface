﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	//Initialize movement variables. These can be edited in the inspector.
	public float runSpeed = 3.0f;
	public float jumpForce = 8.0f;
	public float airMoveForce = 4.0f;

	//For setting up movement. Bool checks if player is touching ground or launched by grapple. Our rigidbody is referenced in Start().
	//Launched must be public, as it is accessed by PlayerGrapple.cs
	private Vector3 movement = Vector3.zero;
	private Rigidbody rb;
	[SerializeField] private bool grounded = true;
	public bool launched = false;

	//These get changed in other scripts. 
	[HideInInspector] public bool grappling = false;
	[HideInInspector] public bool paused = false;

	//Used in jumping.
	private float lastVel = 0.0f;

	//Used in grappling momentum.
	private float lastVelX = 0.0f;

	//What direction is the player facing? -1 is left, 1 is right.
	private int facing = 1;

	void Start ()
	{
		//To save typing, we grab the rigidbody component once here.
		rb = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		//If the player is touching the ground, enable jumping. In all cases, they can move.
		Movement();
		if (grounded == true)
		{
			Jump();
		}
			
		//If the player isn't moving vertically, they are grounded and no longer launched. Else, they are not grounded. 
		//This also checks if the last velocity was negative or 0, to prevent jumping again at the peak of a jump.
		if(rb.velocity.y > -0.07 && rb.velocity.y < 0.07 && lastVel <= 0) 
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

		//If the player's lateral velocity dips within runspeed (and aren't grappling), they are no longer launched.
		if (rb.velocity.x < airMoveForce && rb.velocity.x > -airMoveForce && grappling == false)
		{
			launched = false;
		}

		if (rb.velocity.x > 0)
		{
			facing = 1;
		}
		else if (rb.velocity.x < 0)
		{
			facing = -1;
		}

		//This must be the last line in Update(). This keeps track of the last frame of velocity.
		lastVel = rb.velocity.y;
		lastVelX = rb.velocity.x;
	}

	void Jump()
	{
		//Basic jump, here
		if (Input.GetButtonDown("XboxA") == true || Input.GetKeyDown(KeyCode.Space) == true)
		{
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
	}

	void Movement()
	{
		//Grab left stick horizontal input. We won't use vertical. We only multiply X axis by runspeed, and don't overwrite y axis.
		//Can't move mid-air.
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
			
		movement = new Vector3 (moveHorizontal * runSpeed, rb.velocity.y, 0.0f);

		if (grounded && !grappling)
		{
			rb.velocity = movement;
		}
		else
		{
			//Change momentum in the air. Velocity is capped at running speed unless the player has
			//been launched with the grapple. They cannot make themselves go faster, however.
			if((rb.velocity.x > airMoveForce || rb.velocity.x < -airMoveForce) && launched == false)
			{
				rb.velocity = new Vector3(4.0f * facing, rb.velocity.y, rb.velocity.z);
			}
			else if (launched == true && rb.velocity.x >= (lastVelX * facing) && grappling == false)
			{
				rb.velocity = new Vector3(lastVelX, rb.velocity.y, rb.velocity.z);
			}
			else
			{
				rb.AddForce(rb.transform.right * moveHorizontal * 8);
			}
		}
	}
}
