using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {
	public enum Type {
		Ray,
		Sphere,
		Box
	}

	[SerializeField]
	Type type = Type.Ray;

	[SerializeField]
	float size = 1.0f;

	[SerializeField]
	float distance = 2.0f;

	[SerializeField]
	LayerMask layerMask = Physics.AllLayers;

	RaycastHit[] hits;

	void Update() {
		switch(type) {
			case Type.Ray:
				hits = Physics.RaycastAll(transform.position, transform.forward, distance, layerMask);

				break;
			case Type.Sphere:
				hits = Physics.SphereCastAll(transform.position, size * 0.5f, transform.forward, distance, layerMask);

				break;
			case Type.Box:
				hits = Physics.BoxCastAll(transform.position, Vector3.one * size * 0.5f, transform.forward, transform.rotation, distance, layerMask);

				break;
		}
	}

	void OnDrawGizmos() {
		if(!isActiveAndEnabled) return;

		Gizmos.color = Color.blue;
		switch(type) {
			case Type.Ray:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				break;
			case Type.Sphere:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				Gizmos.DrawWireSphere(transform.position + transform.forward * distance, size * 0.5f);
				break;
			case Type.Box:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				Gizmos.DrawWireCube(transform.position + transform.forward * distance, Vector3.one * size);
				break;
		}

		if(hits != null) {
			Gizmos.color = Color.red;
			foreach(RaycastHit hit in hits) {
				Gizmos.DrawWireCube(hit.collider.transform.position, hit.collider.bounds.size);
			}
		}
	}
}
