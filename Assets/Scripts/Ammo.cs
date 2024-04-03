using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ammo : MonoBehaviour {
	[SerializeField]
	float speed = 1.0f;

	[SerializeField]
	float lifeSpan = 0.0f;

	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();

		if(lifeSpan > 0.0f) Destroy(gameObject, lifeSpan);

		rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}
}
