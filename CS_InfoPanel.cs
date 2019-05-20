using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_InfoPanel : MonoBehaviour {

	public GameObject infoPanel;
	public CS_DataManager dManager;

	void Start()
	{
		dManager = GameObject.FindWithTag("dManager").GetComponent<CS_DataManager>();
		dManager.panelActive = false;
	}

	void OnMouseOver()
	{
		infoPanel.SetActive(true);
		dManager.panelActive = true;
	}

	void OnMouseExit()
	{
		infoPanel.SetActive(false);
		dManager.panelActive = false;
	}
}
