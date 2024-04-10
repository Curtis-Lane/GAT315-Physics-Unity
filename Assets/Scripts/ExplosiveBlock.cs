using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveBlock : MonoBehaviour {
	[SerializeField]
	GameManager gameManager;

	[SerializeField]
	int points = 100;

	[SerializeField]
	float blastRadius = 3.0f;

	[SerializeField]
	float blastForce = 10.0f;

	[SerializeField]
	AudioSource audioSource = null;

	[SerializeField]
	GameObject explodePrefab = null;

	Rigidbody rb;

	bool isDestroyed = false;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision collision) {
		if(rb.velocity.magnitude > 2.0f || rb.angularVelocity.magnitude > 2.0f) {
			audioSource.Play();
		}

		if(!collision.gameObject.CompareTag("Block") && !collision.gameObject.CompareTag("Ground")) {
			foreach(Collider collider in Physics.OverlapSphere(transform.position, blastRadius)) {
				if(collider.attachedRigidbody != null) {
					collider.attachedRigidbody.AddExplosionForce(blastForce, transform.position, blastRadius, 0.0f, ForceMode.VelocityChange);
				}
			}

			if(explodePrefab != null) {
				Instantiate(explodePrefab, transform.position, transform.rotation);
			}
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
