using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
	[SerializeField]
	float sensitivity = 3.0f;

	[SerializeField] float minPitch = -50.0f;
	[SerializeField] float maxPitch = 50.0f;
	[SerializeField] float minYaw = -70.0f;
	[SerializeField] float maxYaw = 70.0f;

	Vector3 rotation = Vector3.zero;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		Vector3 axis = Vector3.zero;
		axis.y = Input.GetAxis("Mouse X");
		axis.x = -Input.GetAxis("Mouse Y");

		rotation.x += axis.x * sensitivity;
		rotation.y += axis.y * sensitivity;

		rotation.x = Mathf.Clamp(rotation.x, minPitch, maxPitch);
		rotation.y = Mathf.Clamp(rotation.y, minYaw, maxYaw);

		Quaternion qYaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
		Quaternion qPitch = Quaternion.AngleAxis(rotation.x, Vector3.right);

		transform.localRotation = (qYaw * qPitch);
	}
}
