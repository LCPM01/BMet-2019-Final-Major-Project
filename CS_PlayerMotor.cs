using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CS_PlayerMotor : MonoBehaviour {

	private const string DOOR_TAG = "interactiveDoor";


	[SerializeField]
	private Camera cam;
	// public Animator anim;


	private Vector3 velocity = Vector3.zero;
	private Rigidbody rb;
	private CapsuleCollider col;
	private Vector3 rotation = Vector3.zero;
	private float camRotationX = 0f;
	private float currentCamRotX = 0f;
	// private bool isGrounded;


	[SerializeField]
	private float cameraRotLimit = 85f;
	[SerializeField]
	private float jumpForce = 5f;
	[SerializeField]
	private LayerMask groundLayers;

	// public GameObject localViewGun;
	// private Animator anim;

	//public GameObject localViewGun;

	// public float doorFloat = 0f;
	//
	// [SerializeField]
	// private float _doorRange = 5f;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
		// anim = localViewGun.gameObject.GetComponent<Animator>();
	}

	public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
	}
	public void Rotate (Vector3 _rotation)
	{
		rotation = _rotation;
	}
	public void RotateCam (float _camRotationX)
	{
		camRotationX = _camRotationX;
	}

	// void Update ()
	// {
	// 	// IsGrounded();
	// 	// PerformJump();
	// 	if (Input.GetKeyDown(KeyCode.E))
	// 	{
	// 		RaycastHit _hit;
	// 		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, _doorRange))
	// 		{
	// 			Debug.Log("Hit Door");
	// 			Animator anim = _hit.collider.gameObject.GetComponent<Animator>();
	// 			if (_hit.collider.tag == DOOR_TAG)
	// 			{
	// 					if (doorFloat >= 0.002f)
	// 					{
	// 							anim.SetFloat("doorFloat", doorFloat);
	// 					} else if (doorFloat <= -0.002f)
	// 					{
	// 							anim.SetFloat("doorFloat", doorFloat);
	// 					}
	// 			}
	// 		}
	// 	}
	//
	// }

	void FixedUpdate ()
	{
		PerformMovement();
		PerformRotation();
		PerformJump();
	}

	void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
				rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
				// anim.SetBool("isMoving", true);
		}
	}

	void PerformRotation()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
		if (cam != null)
		{
				currentCamRotX += camRotationX;
				currentCamRotX = Mathf.Clamp(currentCamRotX, -cameraRotLimit, cameraRotLimit);

				cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
		}
	}

	void PerformJump()
	{
		if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
			// isGrounded = false;
			// anim.SetBool("isGrounded", isGrounded);
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	public bool IsGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
			col.bounds.min.y, col.bounds.center.z), col.radius * .4f, groundLayers);
			// isGrounded = true;
	}
}
