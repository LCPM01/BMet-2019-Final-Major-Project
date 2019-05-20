using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CS_GameData
{
	public float highScore;
	public float totalBulletsFired;
	public float totalBulletsHit;
	public int globalKills;

	public CS_GameData (CS_DataManager dManager)
	{
		highScore = dManager.pHighScore;
		totalBulletsFired = dManager.bFired;
		totalBulletsHit = dManager.bHit;
		globalKills = dManager.totalKills;
	}
}
