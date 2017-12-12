using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour {
	public Collider ledge1;

	public Transform startMarker;
	public Transform endMarker1;

	public GameObject Player;

	private Rigidbody rb;

	public bool grounded = true;

	public float ledgeSpeed = 4.0f;

	private float startTime;
	private float journeyLength1;

	private float lastVel = 0.0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength1 = Vector3.Distance (startMarker.position, endMarker1.position);
		rb = Player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.FindWithTag("Player") == false || Player == null)
		{
			Player = GameObject.FindWithTag("Player");
		}
		if (rb == null && Player != null)
		{
			rb = Player.GetComponent<Rigidbody> ();
		}


		if (startMarker == null)
		{
			startMarker = gameObject.transform;
		}

		if(rb.velocity.y > -0.07 && rb.velocity.y < 0.07 && lastVel <= 0) 
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

		lastVel = rb.velocity.y;

		if (grounded == true && Input.GetButtonDown ("XboxA") == true && ledge1.enabled == true) {
			StartCoroutine (ledgeTime ());
		} else if (grounded == true && Input.GetButtonDown ("XboxB") == true && ledge1.enabled == true) {
			StartCoroutine (ledgeTime ());
		}
	}

	void OnTriggerStay (Collider ledge1) {
		if (grounded == false) {
			float distCovered = (Time.time - startTime) * ledgeSpeed;
			float fracJourney = distCovered / journeyLength1;
			Player.transform.position = Vector3.Lerp (startMarker.position, endMarker1.position, fracJourney);
			rb.constraints = RigidbodyConstraints.FreezePosition;
			grounded = true;
		}
	}

	IEnumerator ledgeTime() {
		ledge1.enabled = false;
		rb.constraints = RigidbodyConstraints.None;
		rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		yield return new WaitForSeconds (0.75f);
		ledge1.enabled = true;
	}
}