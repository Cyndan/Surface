using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShift : MonoBehaviour {

	public GameObject WorldA;
	public GameObject WorldB;

	public AbilityManager abiMan;

	private float xboxLT;

	private bool triggerPulled = false;

	public AudioClip flashSound;

	//Timer stuff.
	private float shiftTimer = 1.0f;
	private float toShift = 0.0f;
	private bool canShift = true;

	//NOTE: When WorldActive is true, World A is up. When WorldActive is false, World B is up.
	//There should never be no world up.
	public bool WorldActive = true;

	// Use this for initialization
	void Start () {
		//Added by James! For when the player respawns.
		WorldA = GameObject.FindWithTag("WorldA");
		WorldB = GameObject.FindWithTag("WorldB");

		//NOTE: This should probably be done in the GameManager.
		//WorldA.SetActive (true);
		//WorldB.SetActive (false);

		abiMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<AbilityManager>();

	}

	// Update is called once per frame
	void Update () {
		xboxLT = Input.GetAxisRaw ("XboxLT");

		//NOTE: Come back here and put Xbox Trigger support in when it doesn't give an error.
		if ((Input.GetKeyDown(KeyCode.Q) == true || xboxLT > 0) && triggerPulled == false && canShift) {
			triggerPulled = true;
			canShift = false;
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

			abiMan.startTime = Time.time;
			abiMan.Flash();
			toShift = Time.time + shiftTimer;
			abiMan.shiftBar = Time.time + shiftTimer;

			abiMan.gameObject.GetComponent<AudioSource>().clip = flashSound;
			abiMan.gameObject.GetComponent<AudioSource>().Play();
		}

		if (xboxLT == 0)
		{
			triggerPulled = false;
		}

		if (Time.time > toShift)
		{
			canShift = true;
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
