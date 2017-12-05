using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour {
	public Collider ledge;

	public Transform startMarker;
	public Transform endMarker;
	public Transform hangPosition;

	public GameObject Player;

	private Rigidbody rb;

	public bool grounded = true;

	public float ledgeSpeed = 4.0f;

	private float startTime;
	private float journeyLength;

	private float lastVel = 0.0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
		rb = Player.GetComponent<Rigidbody>();
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

		if (grounded == true && Input.GetButtonDown ("XboxA") == true && ledge.enabled == true) {
			StartCoroutine (hangTime ());
			Debug.Log ("Hope this worked");
		}
	}

	void OnTriggerStay (Collider ledge) {
		if (grounded == false) {
			float distCovered = (Time.time - startTime) * ledgeSpeed;
			float fracJourney = distCovered / journeyLength;
			Player.transform.position = Vector3.Lerp (startMarker.position, hangPosition.position, fracJourney);
			rb.constraints = RigidbodyConstraints.FreezePosition;
			grounded = true;
		} else {
			return;
		}
	}

	IEnumerator hangTime() {
		ledge.enabled = false;
		rb.constraints = RigidbodyConstraints.None;
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		yield return new WaitForSeconds (0.75f);
		ledge.enabled = true;
	}
}
