using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour {
	[SerializeField]
	Vector3 force;

	[SerializeField]
	ForceMode forceMode;

	[SerializeField]
	Vector3 torque;

	[SerializeField]
	ForceMode torqueMode;

	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.Space)) {
			rb.AddForce(force, forceMode);
			rb.AddTorque(torque, torqueMode);
		}
	}
}
