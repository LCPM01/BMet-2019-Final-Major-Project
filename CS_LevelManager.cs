using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_LevelManager : MonoBehaviour {

	public void RestartLevel()
	{
		SceneManager.LoadScene("test", LoadSceneMode.Single);
	}

	public void ReturnMenu()
	{
		//Save game data

		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
