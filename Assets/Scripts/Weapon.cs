using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField]
	GameObject ammoPrefab = null;

	[SerializeField]
	Transform firePoint = null;

	[SerializeField]
	AudioSource audioSource = null;

	[SerializeField]
	float fireInterval = 1.0f;

	bool canFire = true;

	void Update() {
		Debug.DrawRay(firePoint.position, firePoint.forward * 10, Color.red);

		if(canFire) {
			if(Input.GetMouseButtonDown(0)) {
				if(ammoPrefab != null) {
					if(audioSource != null) {
						audioSource.Play();
					}
					Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
					if(fireInterval > 0.0f) {
						canFire = false;
						StartCoroutine(ResetFire());
					}
				}
			}
		}
	}

	IEnumerator ResetFire() {
		yield return new WaitForSeconds(fireInterval);

		canFire = true;

		yield return null;
	}
}
