using UnityEngine;

public class KinematicController : MonoBehaviour {
	[SerializeField]
	float speed = 2.5f;

	void Update() {
		Vector3 direction = Vector3.zero;

		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");

		direction = Vector3.ClampMagnitude(direction, 1.0f);

		transform.position += direction * speed * Time.deltaTime;
	}
}
