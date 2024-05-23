using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanAmmo : MonoBehaviour {
	[SerializeField]
	float distance = 10.0f;

	[SerializeField]
	GameObject hitPrefab = null;

	[SerializeField]
	LayerMask layerMask = Physics.AllLayers;

	[SerializeField]
	bool debug = false;

	void Start() {
		if(Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layerMask)) {
			if(hitPrefab != null) {
				Instantiate(hitPrefab, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
			}
		}
		if(debug) {
			Color color = (raycastHit.collider != null) ? Color.red : Color.green;
			Debug.DrawRay(transform.position, transform.forward * distance, color, 1);
		}

		Destroy(gameObject);
	}
}
