using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {
	
	public Animator anim;
	//public Collider col;
	public GameObject doorObj;
	public Collider doorOpen;
	public Collider doorClosed;
	
	private bool doorBoolState;
	private bool colStatus = true;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		//col = GetComponent<BoxCollider>();
	}
	
	public void OnTriggerStay (Collider other)
	{
		if (other.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Debug.Log("Door Activated");
				doorBoolState = !doorBoolState;
				colStatus = !colStatus;
				doorColStates();
				anim.SetBool("doorBool", doorBoolState);
				// doorObj.GetComponent<BoxCollider>().enabled = colStatus;
			}
		}
	}
	
	void doorColStates ()
	{
		if (doorBoolState == true)
		{
			//Enable Open Collider and disable closed collider
			doorOpen.enabled = true;
			doorClosed.enabled = false;
		} else if (doorBoolState == false)
		{
			//Opposite
			doorOpen.enabled = false;
			doorClosed.enabled = true;
		}
	}
}
