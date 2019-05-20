using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CS_DataManager : MonoBehaviour {

	public bool saved;
	public float saveTime = 1;
	public float pHighScore;
	public float bFired;
	public float bHit;
	public int totalKills;

	public float bPerc;

	private Scene scene;
	public string sName;

	public CS_GameManager gManager;

	public bool panelActive;

	public Text ipShots;
	public Text ipShotP;
	public Text ipKills;
	public Text ipHScore;

	void Start()
	{

	}

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("dManager");
		if(objs.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
		StartCoroutine(saveGameData());
		//loadGameData();
	}

	void Update()
	{
		if(panelActive)
		{
			ipShots = GameObject.FindWithTag("sbBC").GetComponent<Text>();
			ipShotP = GameObject.FindWithTag("sbBP").GetComponent<Text>();
			ipKills = GameObject.FindWithTag("sbKC").GetComponent<Text>();
			ipHScore = GameObject.FindWithTag("sbSC").GetComponent<Text>();
			InfoPanel();
		}

		loadGameData();
		scene = SceneManager.GetActiveScene();
		sName = scene.name;
		if(sName != "MainMenu")
		{
			gManager = GameObject.FindWithTag("gManager").GetComponent<CS_GameManager>();
			pHighScore = gManager.pHighScore;
			bFired = gManager.bFiredTotal;
			bHit = gManager.bHitTotal;
			totalKills = gManager.totalKills;

		}
	}

	void InfoPanel()
	{
		ipShots.text = ("" + bFired);

		bPerc = (bHit / bFired) * 100f;
		bPerc = Mathf.Round(bPerc * 10f) / 10f;
		ipShotP.text = (bPerc + "%");

		ipKills.text = ("" + totalKills);
		ipHScore.text = ("" + pHighScore);
	}

	public void loadGameData()
	{
		CS_GameData data = sSystem.LoadGame();

		pHighScore = data.highScore;
		bFired = data.totalBulletsFired;
		bHit = data.totalBulletsHit;
		totalKills = data.globalKills;
	}

	public IEnumerator saveGameData()
	{
		yield return new WaitForSeconds(saveTime);
		sSystem.SaveGame(this);
		Debug.Log("SAVED GAME");
	}
}
