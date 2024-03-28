using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField]
	GameObject prefab;

	[SerializeField]
	KeyCode keyCode;

	void Update() {
		if(Input.GetKeyDown(keyCode)) {
			Instantiate(prefab, transform.position, transform.rotation);
		}
	}
}
