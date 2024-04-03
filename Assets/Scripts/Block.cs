using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour {
	[SerializeField]
	GameManager gameManager;

	[SerializeField]
	int points = 100;

	[SerializeField]
	AudioSource audioSource = null;

	Rigidbody rb;

	bool isDestroyed = false;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision collision) {
		if(rb.velocity.magnitude > 2.0f || rb.angularVelocity.magnitude > 2.0f) {
			audioSource.Play();
		}
	}

	void OnTriggerStay(Collider other) {
		if(!isDestroyed && other.CompareTag("Kill") && rb.velocity.magnitude == 0.0f && rb.angularVelocity.magnitude == 0.0f) {
			Debug.Log(points);
			gameManager.Score += points;
			isDestroyed = true;
			Destroy(gameObject, 2.0f);
		}
	}
}
