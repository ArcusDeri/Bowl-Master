using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float LaunchSpeed;

	private Rigidbody MyRigidBody;
	private AudioSource RollingSound;

	// Use this for initialization
	void Start () {
		MyRigidBody = gameObject.GetComponent<Rigidbody> ();
		RollingSound = gameObject.GetComponent<AudioSource> ();

		Launch ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Launch ()
	{
		MyRigidBody.velocity = new Vector3 (0, 0, LaunchSpeed);
		RollingSound.Play ();
	}
}
