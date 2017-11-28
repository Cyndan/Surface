﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShift : MonoBehaviour {

	public GameObject WorldA;

	public GameObject WorldB;

	private float xboxLT;

	private bool triggerPulled = false;

	//NOTE: When WorldActive is true, World A is up. When WorldActive is false, World B is up.
	//There should never be no world up.
	public bool WorldActive = true;

	// Use this for initialization
	void Start () {
		//NOTE: This should probably be done in the GameManager.
		WorldA.SetActive (true);
		WorldB.SetActive (false);


	}

	// Update is called once per frame
	void Update () {
		xboxLT = Input.GetAxisRaw ("XboxLT");

		//NOTE: Come back here and put Xbox Trigger support in when it doesn't give an error.
		if ((Input.GetKeyDown(KeyCode.Q) == true || xboxLT > 0) && triggerPulled == false) {
			triggerPulled = true;
			if (WorldActive == true) {
				//Debug.Log ("Yeah the first command works");
				WorldA.SetActive (false);
				WorldB.SetActive (true);
				WorldActive = false;
			}

			else {
				//Debug.Log ("If you're seeing this, without hitting Q, you fucked up");
				WorldA.SetActive (true);
				WorldB.SetActive (false);
				WorldActive = true;
			}
		}

		if (xboxLT == 0)
		{
			triggerPulled = false;
		}
	}

	/*void PhaseShift () {
		//NOTE: COME BACK HERE AND EDIT LEFT TRIGGER IN
		if (Input.GetAxisRaw("XboxLT") > 0 || Input.GetKeyDown(KeyCode.Q) == true) {
			if (WorldActive == true) {
				Debug.Log ("Yeah the first comand works");
				WorldA.SetActive (false);
				WorldB.SetActive (true);
				WorldActive = false;
			}

			if (WorldActive == false) {
				Debug.Log ("If you're seeing this, without hitting Q, you fucked up");
				WorldA.SetActive (true);
				WorldB.SetActive (false);
				WorldActive = true;
			}
		}

	}*/
}
