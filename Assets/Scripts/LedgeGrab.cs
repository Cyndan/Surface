using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour {
	public Collider ledge;

	public Transform startMarker;
	public Transform endMarker;

	private Rigidbody rb;

	private bool grounded = true;

	public float ledgeSpeed = 4.0f;

	private float startTime;
	private float journeyLength;

	private float lastVel = 0.0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		startMarker = transform;

		if(rb.velocity.y > -0.07 && rb.velocity.y < 0.07 && lastVel <= 0) 
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

		lastVel = rb.velocity.y;
	}

	void OnTriggerEnter (Collider ledge) {
		if (grounded == false) {
			float distCovered = (Time.time - startTime) * ledgeSpeed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Slerp (startMarker.position, endMarker.position, fracJourney);
			Debug.Log ("Hope this worked");
		} else {
			return;
		}
	}
}
