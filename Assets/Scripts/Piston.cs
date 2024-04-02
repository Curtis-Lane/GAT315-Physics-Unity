using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piston : MonoBehaviour {
	[SerializeField]
	Action action;

	[SerializeField]
	Vector3 speed = new Vector3(0.0f, 0.0f, 10.0f);

	[SerializeField]
	ForceMode forceMode = ForceMode.Force;

	Rigidbody rb;

	bool isActive = false;

	// Start is called before the first frame update
	void Start() {
		action.onEnter += SetActive;

		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if(isActive) {
			rb.AddForce(speed, forceMode);
		}
	}

	void SetActive(GameObject go) {
		isActive = true;
	}
}
