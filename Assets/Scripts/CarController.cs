using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour {
	[System.Serializable]
	public struct Wheel {
		public WheelCollider collider;
		public Transform transform;
	}

	[System.Serializable]
	public struct Axle {
		public Wheel leftWheel;
		public Wheel rightWheel;
		public bool isMotor;
		public bool isSteering;
		public bool isSteeringInverted;
	}

	[SerializeField] Axle[] axles;
	[SerializeField] float maxMotorTorque;
	[SerializeField] float maxSteeringAngle;

	Rigidbody rb;

	public void Start() {
		rb = GetComponent<Rigidbody>();
	}

	public void Update() {
		if(Input.GetKeyDown(KeyCode.LeftControl)) {
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
			rb.angularVelocity = Vector3.zero;
		}
		if(Input.GetKey(KeyCode.LeftShift)) {
			rb.velocity = Vector3.zero;
		}
	}

	public void FixedUpdate() {
		float motor = Input.GetAxis("Vertical") * maxMotorTorque; //<input vertical axis * max motor torque>
		float steering = Input.GetAxis("Horizontal") * maxSteeringAngle; //<input horizontal axis * max steering angle>

		foreach(Axle axle in axles) {
			if(axle.isSteering) {
				axle.leftWheel.collider.steerAngle = (axle.isSteeringInverted) ? -steering : steering;
				axle.rightWheel.collider.steerAngle = (axle.isSteeringInverted) ? -steering : steering; //<set axle right wheel collider steer angle>
			}
			if(axle.isMotor) {
				axle.leftWheel.collider.motorTorque = motor;
				axle.rightWheel.collider.motorTorque = motor; //<set axle right wheel collider motor torque>
			}
			UpdateWheelTransform(axle.leftWheel);
			UpdateWheelTransform(axle.rightWheel);
		}
	}

	public void UpdateWheelTransform(Wheel wheel) {
		wheel.collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

		wheel.transform.position = position;
		wheel.transform.rotation = rotation;
	}
}