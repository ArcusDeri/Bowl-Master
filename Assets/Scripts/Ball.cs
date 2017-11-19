using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 LaunchVector;
	public Vector3 StartPosition = new Vector3(0,20,30);
	public bool IsLaunched = false;

	private Rigidbody MyRigidBody;
	private AudioSource RollingSound;

	// Use this for initialization
	void Start () {
		MyRigidBody = gameObject.GetComponent<Rigidbody> ();
		RollingSound = gameObject.GetComponent<AudioSource> ();
		MyRigidBody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Launch (Vector3 velocity)
	{
		MyRigidBody.useGravity = true;
		MyRigidBody.velocity = velocity;
		IsLaunched = true;
		PlayRollingSound();
	}

	public void Reset(){
		MyRigidBody.useGravity = false;
		gameObject.transform.position = StartPosition;
		MyRigidBody.velocity = Vector3.zero;
		MyRigidBody.angularVelocity = Vector3.zero;
		gameObject.transform.rotation = Quaternion.identity;
		RollingSound.Stop();
		IsLaunched = false;
	}

	private void PlayRollingSound(){
		RollingSound.Play ();
	}
}
