using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageTarget : MonoBehaviour {
	[SerializeField]
	Image image;

	[SerializeField]
	Camera view = null;

	[SerializeField]
	float distance = 5.0f;

	void Start() {
		if(view == null) {
			view = Camera.main;
		}
	}

	void LateUpdate() {
		Vector3 screen = image.transform.position;
		screen.z = distance;

		Vector3 world = view.ScreenToWorldPoint(screen);
		transform.position = world;
	}
}
