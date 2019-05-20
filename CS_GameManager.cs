using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_GameManager : MonoBehaviour {

	public int critChance;
	public float critModifier;
	public float critScore;
	public float killScore;

	public float timer;
	public float timerLimit;
	public float endTime;
	public bool runTimer;

	public int killCount;

	public bool endMission;

	public Text timerText;
	public Text killCounter;
	public Text scoreText;

	public float bFired;
	public float bHit;
	public float bPercentage;

	public int numOfEnemies;
	public float pScore;
	public float pHighScore;

	//Global total variables
	public float bFiredTotal;
	public float bHitTotal;
	public int totalKills;

	//Scoreboard Variables
	public bool sBoard;
	public GameObject sBoardOBJ;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController pControl;
	public CameraToggleController cControl;
	public CS_WeaponSwitch wSwitch;
	public CS_WeaponSwitch wSwitch2;
	public GameObject wCamera;
	public GameObject hudUI;

	public GameObject newHS;
	public CS_DataManager dManager;

	public Text sbKill;
	public Text sbTime;
	public Text sbShots;
	public Text sbScore;
	public Text sbShotPercentage;
	public Text sbHighScore;
	public Text pRank;

	[Header("Ranking Times")]
	public float ssRank;
	public float sRank;
	public float aRank;
	public float bRank;
	public float cRank;
	public float dRank;

	void Start()
	{

		timerText = GameObject.FindWithTag("hudTT").GetComponent<Text>();
		killCounter = GameObject.FindWithTag("hudKC").GetComponent<Text>();
		scoreText = GameObject.FindWithTag("hudSC").GetComponent<Text>();

		sbKill = GameObject.FindWithTag("sbKC").GetComponent<Text>();
		sbShots = GameObject.FindWithTag("sbBC").GetComponent<Text>();
		sbTime = GameObject.FindWithTag("sbTT").GetComponent<Text>();
		sbScore = GameObject.FindWithTag("sbSC").GetComponent<Text>();
		sbShotPercentage = GameObject.FindWithTag("sbBP").GetComponent<Text>();
		sbHighScore = GameObject.FindWithTag("sbHS").GetComponent<Text>();

		pControl = GameObject.FindWithTag("pControl").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		cControl = GameObject.FindWithTag("Player").GetComponent<CameraToggleController>();
		wSwitch = GameObject.FindWithTag("wHolder").GetComponent<CS_WeaponSwitch>();
		wSwitch2 = GameObject.FindWithTag("wHolder2").GetComponent<CS_WeaponSwitch>();
		wCamera = GameObject.FindWithTag("wCamera");
		hudUI = GameObject.FindWithTag("HUD");

		newHS = GameObject.FindWithTag("newHS");
		pRank = GameObject.FindWithTag("sbRank").GetComponent<Text>();

		dManager = GameObject.FindWithTag("dManager").GetComponent<CS_DataManager>();

		StartMission();
		//	timerLimit = timerLimit* Time.deltaTime;
	}

	void Update()
	{
		// bFiredTotal = dManager.bFired;
		// bHitTotal = dManager.bHit;

		if(runTimer)
		{
			timer += Time.deltaTime;
			timer = Mathf.Round(timer * 100f) / 100f;
			//Debug.Log(timer);
			timerText.text = (timer + "");
			scoreText.text = ("" + pScore);
		}
		if(timer >= timerLimit && runTimer)
		{
			runTimer = false;
			endTime = timer;
			endMission = true;
		}
		if(killCount == numOfEnemies && runTimer)
		{
			runTimer = false;
			endTime = timer;
			endMission = true;
		}
		if (endMission)
		{
			//timer = endTime;
			timer = 0f;
			endMission = false;
			EndMissionUI();
			//Enable end mission UI
			//EndMissionUI();
		}

		//Kill Counter Text
		if(killCount == 0)
		{
			killCounter.text = ("0");
		} else if (killCount > 0 && killCount < 10) {
			killCounter.text = ("" + killCount);
		} else if(killCount > 9) {
			killCounter.text = ("" + killCount);
		}
	}

	void StartMission()
	{
		pHighScore = dManager.pHighScore;
		bFiredTotal = dManager.bFired;
		bHitTotal = dManager.bHit;
		totalKills = dManager.totalKills;
		runTimer = true;
		endMission = false;
		sBoard = false;
		sBoardOBJ.SetActive(false);
		if (Cursor.lockState != CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void EndMissionUI()
	{
		//Activating the Scoreboard
		sBoardOBJ.SetActive(true);
		//Allow for mouse movement
		if (Cursor.lockState != CursorLockMode.None)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		//Disabling the other unneeded components
		pControl.enabled = false;
		cControl.enabled = false;
		wSwitch.enabled = false;
		wSwitch2.enabled = false;
		wCamera.SetActive(false);
		hudUI.SetActive(false);

		//Setting Scoreboard Information
		//Kill Counter
		if(killCount == 0)
		{
			sbKill.text = ("0 / " + numOfEnemies);
		} else if (killCount > 0 && killCount < 10) {
			sbKill.text = (killCount + " / " + numOfEnemies);
		} else if(killCount > 9) {
			sbKill.text = (killCount + " / " + numOfEnemies);
		}


		//Time Counter
		sbTime.text = (endTime + "s");
		//Shots Fired/Hit

		bPercentage = (bHit / bFired) * 100f;
		bPercentage = Mathf.Round(bPercentage * 10f) / 10f;

		if(bFired == 0)
		{
			sbShots.text = ("000");
			sbShotPercentage.text = ("0%");
		} else if(bFired > 0 && bFired < 10) {
			sbShots.text = ("00" + bFired);
			sbShotPercentage.text = (bPercentage + "%");
		} else if(bFired >= 10 && bFired < 100) {
			sbShots.text = ("0" + bFired);
			sbShotPercentage.text = (bPercentage + "%");
		} else if(bFired >= 100) {
			sbShots.text = ("" + bFired);
			sbShotPercentage.text = (bPercentage + "%");
		}
		//Score Count
		sbScore.text = ("" + pScore);

		if(pScore > pHighScore)
		{
			newHS.SetActive(true);
			sbHighScore.text = ("" + pScore);
			pHighScore = pScore;
		} else {
			newHS.SetActive(false);
			sbHighScore.text = ("" + pHighScore);
		}

		//Ranking System
		if(!runTimer && killCount != numOfEnemies)
		{
			pRank.text = ("F");
		} else if(bPercentage >= 97f && endTime <= ssRank) {
			pRank.text = ("SS");
		} else if(bPercentage >= 90f && endTime <= sRank) {
			pRank.text = ("S");
		} else if(bPercentage >= 75f && endTime <= aRank) {
			pRank.text = ("A");
		} else if(bPercentage >= 50f && endTime <= bRank) {
			pRank.text = ("B");
		} else if(bPercentage >= 30f && endTime <= cRank) {
			pRank.text = ("C");
		} else if(endTime <= dRank) {
			pRank.text = ("D");
		}

		//Setting variables to a new variable; which is
		//saved as a global total value.
		bFiredTotal = bFiredTotal + bFired;
		bHitTotal = bHitTotal + bHit;
		totalKills = totalKills + killCount;
		StartCoroutine(GameObject.FindWithTag("dManager").GetComponent<CS_DataManager>().saveGameData());
	}
}
