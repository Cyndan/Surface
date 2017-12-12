using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {

	public GameObject Room1;
	public GameObject Room2;
	public GameObject firstRoom;

	public GameObject trigger;

	public bool usedBefore = true;

	// Use this for initialization
	void Start () {
		firstRoom.SetActive (true);
		Room2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider trigger) {
		if (usedBefore == true) {
			Debug.Log ("If you see this and the camera fails shit's broke");
			Room1.SetActive (false);
			Room2.SetActive (true);
			usedBefore = false;
		} else {
			Room1.SetActive (true);
			Room2.SetActive (false);
			usedBefore = true;
		}
	}
}
