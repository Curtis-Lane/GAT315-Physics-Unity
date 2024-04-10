using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycle : MonoBehaviour {
	[SerializeField]
	Transform[] points;

	[SerializeField]
	Camera cam = null;

	[SerializeField]
	KeyCode key = KeyCode.Tab;

	int camPos = 0;

	void Start() {
		if(cam == null) {
			cam = Camera.main;
		}
	}

	void Update() {
		if(Input.GetKeyDown(key)) {
			camPos += 1;
			camPos %= points.Length;

			cam.transform.position = points[camPos].position;
			cam.transform.rotation = points[camPos].rotation;
		}
	}
}
