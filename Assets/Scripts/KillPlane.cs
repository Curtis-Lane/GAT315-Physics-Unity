using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour {
	[SerializeField]
	string otherTag = null;

	private void OnCollisionEnter(Collision collision) {
		if(otherTag != null && otherTag != string.Empty) {
			if(collision.gameObject.CompareTag(otherTag)) {
				Destroy(collision.gameObject);
			}
		} else {
			Destroy(collision.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(otherTag != null && otherTag != string.Empty) {
			if(other.CompareTag(otherTag)) {
				Destroy(other.gameObject);
			}
		} else {
			Destroy(other.gameObject);
		}
	}
}
