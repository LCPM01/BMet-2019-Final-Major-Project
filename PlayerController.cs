using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float speedNew = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

	private PlayerMotor motor;
	// private Animator animator;

	// public GameObject localViewGun;
	// private Animator anim;

	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
		// animator = GetComponent<Animator>();
		// anim = localViewGun.gameObject.GetComponent<Animator>();
	}

	void Update ()
	{

		if (Cursor.lockState != CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		//Movement
		float xMov = Input.GetAxis("Horizontal");  // Between -1 and 1
		float zMov = Input.GetAxis("Vertical");    // Between -1 and 1
		Vector3 movHorizontal = transform.right * xMov;
		Vector3 movVertical = transform.forward * zMov;
		
		if (xMov == 0f && zMov == 0f)
		{
			speed = 0f;
		} else if (xMov != 0f || zMov != 0f)
		{
			speed = speedNew;
		}
		
		Vector3 _velocity = (movHorizontal + movVertical) * speed;
		motor.Move(_velocity);

		// animator.SetFloat("zMov", zMov);
		// animator.SetFloat("xMov", xMov);
		// anim.SetFloat("isMovingZ", zMov);
		// anim.SetFloat("isMovingX", xMov);
		//Mouse Look
		float yRot = Input.GetAxisRaw("Mouse X");
		Vector3 _rotation = new Vector3 (0f, yRot, 0f) * lookSensitivity;
		motor.Rotate(_rotation);

		//Mouse Look
		float xRot = Input.GetAxis("Mouse Y");
		float _camRotationX = xRot * lookSensitivity;
		motor.RotateCam(-_camRotationX);
	}
}
