using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_MenuManager : MonoBehaviour {

	public Animator anim;
	public Transform pStart;
	public GameObject pObject;

	void Start()
	{
		anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		pObject = GameObject.FindWithTag("Player");
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			StartCoroutine(Emote());
		}
	}

	IEnumerator Emote()
	{
		anim.SetBool("Emote", true);
		yield return new WaitForSeconds(5);
		anim.SetBool("Emote", false);
		pObject.transform.position = pStart.position;
		pObject.transform.rotation = pStart.rotation;
	}

	public void startGame()
	{
		SceneManager.LoadScene("test", LoadSceneMode.Single);
	}

	public void gameInfo()
	{

	}

	public void gameExit()
	{
		Application.Quit();
	}
}
