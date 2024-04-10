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

	void Start() {
		action.onEnter += SetActive;

		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if(isActive) {
			rb.AddForce(speed, forceMode);
			isActive = false;
		}
	}

	void SetActive(GameObject go) {
		isActive = true;
	}
}
