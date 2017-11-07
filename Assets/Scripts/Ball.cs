using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 LaunchVector;

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
		MyRigidBody.velocity = LaunchVector;
		RollingSound.Play ();
	}
}
