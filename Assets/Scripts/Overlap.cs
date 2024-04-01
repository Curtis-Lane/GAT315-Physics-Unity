using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap : MonoBehaviour {
	public enum Type {
		BoundingBox,
		Sphere
	}

	[SerializeField]
	Type type = Type.BoundingBox;

	[SerializeField]
	float size = 1.0f;

	[SerializeField]
	LayerMask layerMask = -1; // -1 Indicates every layer (think integer underflow). Could also use Physics.AllLayers

	Collider[] colliders = null;

	void Update() {
		switch(type) {
			case Type.BoundingBox:
				colliders = Physics.OverlapBox(transform.position, Vector3.one * size * 0.5f, transform.rotation, layerMask);

				break;
			case Type.Sphere:
				colliders = Physics.OverlapSphere(transform.position, size * 0.5f, layerMask);

				break;
		}

		if(Input.GetKey(KeyCode.Space)) {
			Physics.gravity = new Vector3(0.0f, 3.0f, 0.0f);
		} else {
			Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
		}
	}

	void OnDrawGizmos() {
		if(!isActiveAndEnabled) return;

		Gizmos.color = Color.green;
		switch(type) {
			case Type.BoundingBox:
				Gizmos.DrawWireCube(transform.position, Vector3.one * size);
				break;
			case Type.Sphere:
				Gizmos.DrawWireSphere(transform.position, size * 0.5f);
				break;
		}

		Gizmos.color = Color.red;
		if(colliders != null) {
			foreach(Collider collider in colliders) {
				Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
			}
		}
	}
}
