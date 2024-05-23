using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour {
	private CharacterController controller;
	private Vector3 velocity;
	private bool onGround;
	private bool equipped = false;

	[SerializeField]
	private float playerSpeed = 2.0f;
	[SerializeField]
	private float jumpHeight = 1.0f;
	[SerializeField]
	private float pushPower = 2.0f;
	[SerializeField]
	private float rotationSpeed = 3.0f;
	[SerializeField]
	private Transform view;
	[SerializeField]
	Animator animator = null;
	[SerializeField]
	Rig rig;

	private void Start() {
		controller = GetComponent<CharacterController>();

		if(equipped) {
			rig.weight = 1;
		} else {
			rig.weight = 0;
		}
	}

	void Update() {
		onGround = controller.isGrounded;
		if(onGround && velocity.y < 0) {
			velocity.y = -0.25f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		move = Vector3.ClampMagnitude(move, 1.0f);
		move = Quaternion.Euler(0.0f, view.rotation.eulerAngles.y, 0.0f) * move;

		controller.Move(move * Time.deltaTime * playerSpeed);

		if(move != Vector3.zero) {
			//gameObject.transform.forward = move;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationSpeed);
		}

		// Changes the height position of the player..
		if(Input.GetButton("Jump") && onGround) {
			velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.E)) {
			if(animator != null) {
				equipped = !equipped;
				animator.SetBool("Equipped", equipped);
			}

			if(equipped) {
				rig.weight = 1;
			} else {
				rig.weight = 0;
			}
		}

		if(animator != null) {
			animator.SetFloat("Speed", move.magnitude * playerSpeed);
			animator.SetFloat("YVelocity", velocity.y);
			animator.SetBool("OnGround", onGround);
		}
	}

	// this script pushes all rigidbodies that the character touches
	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;

		// no rigidbody
		if(body == null || body.isKinematic) {
			return;
		}

		// We dont want to push objects below us
		if(hit.moveDirection.y < -0.3) {
			return;
		}

		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.

		// Apply the push
		body.velocity = pushDir * pushPower;
	}
}