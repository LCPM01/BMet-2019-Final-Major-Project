using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_EnemySpawner : MonoBehaviour {

	public CS_GameManager gManager;

	public int enemyInt;
	public Transform[] eSpawns;
	public Transform EnemyObjects;

	private GameObject leftEnemy;
	private GameObject bottomEnemy;
	private GameObject topEnemy;
	private GameObject rightEnemy;

	//Target Prefab Variants
	[Header("Target Prefabs")]
	public GameObject leftTarget;
	public GameObject rightTarget;
	public GameObject topTarget;
	public GameObject bottomTarget;

	void Start()
	{
		gManager = GameObject.FindWithTag("gManager").GetComponent<CS_GameManager>();
		gManager.numOfEnemies = eSpawns.Length;
		SpawnEnemies();
	}
	void SpawnEnemies()
	{
		foreach(Transform spawn in eSpawns)
		{
			if(enemyInt == 1 || enemyInt == 3)
			{
				// Spawn target left variation
				leftEnemy = Instantiate(leftTarget, eSpawns[enemyInt].transform.position, eSpawns[enemyInt].transform.rotation);
				leftEnemy.transform.SetParent(EnemyObjects.transform);
			}
			if(enemyInt == 6)
			{
				// Spawn target top variation
				topEnemy = Instantiate(topTarget, eSpawns[enemyInt].transform.position, eSpawns[enemyInt].transform.rotation);
				topEnemy.transform.SetParent(EnemyObjects.transform);
			}
			if(enemyInt == 7)
			{
				// Spawn target right variation
				rightEnemy = Instantiate(rightTarget, eSpawns[enemyInt].transform.position, eSpawns[enemyInt].transform.rotation);
				rightEnemy.transform.SetParent(EnemyObjects.transform);
			}
			if(enemyInt == 0 || enemyInt == 2 || enemyInt == 4 || enemyInt == 5)
			{
				// Spawn bottom variation
				bottomEnemy = Instantiate(bottomTarget, eSpawns[enemyInt].transform.position, eSpawns[enemyInt].transform.rotation);
				bottomEnemy.transform.SetParent(EnemyObjects.transform);
			}

			enemyInt++;
		}
	}
}
