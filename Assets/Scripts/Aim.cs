using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
	[SerializeField]
	float sensitivity = 3.0f;

	Vector3 rotation = Vector3.zero;
	Vector2 prevAxis = Vector2.zero;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		prevAxis.x = -Input.GetAxis("Mouse Y");
		prevAxis.y = Input.GetAxis("Mouse X");
	}

	void Update() {
		Vector3 axis = Vector3.zero;
		axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x;
		axis.y = Input.GetAxis("Mouse X") - prevAxis.y;

		rotation.x += axis.x * sensitivity;
		rotation.y += axis.y * sensitivity;

		rotation.x = Mathf.Clamp(rotation.x, -50, 50);
		rotation.y = Mathf.Clamp(rotation.y, -70, 70);

		Quaternion qYaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
		Quaternion qPitch = Quaternion.AngleAxis(rotation.x, Vector3.right);

		transform.rotation = (qYaw * qPitch);
	}
}
