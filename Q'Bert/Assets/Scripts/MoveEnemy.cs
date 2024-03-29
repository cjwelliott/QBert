﻿using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public float speed = 1.0f;

	public AudioSource jumpSound;
	public AudioSource splatSound;

	private bool _canMove = true;
	private GameObject sheep;

	void Start() {
		sheep = GameObject.FindGameObjectWithTag("Sheep");
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Top Panel")) {
			int coinFlip = (int)Random.Range (1, 3);
			jumpSound.Play ();
			if (1 == coinFlip) {
				this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				ApplyDownwardForce ();
			} else {
				this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				ApplyDownwardForce ();
			}
		}
	}

	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (new Vector3(0.0f, (float)-(sheep.GetComponent<PlayerMovement>().GetLevel()), 0.0f));
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Boundary")) {
			Destroy (this.gameObject);
		}
	}
}
