using UnityEngine;

public class CS_EnemyScript : MonoBehaviour {

	public CS_GameManager gManager;

	public float health = 100f;
	[SerializeField]
	private float healthRemaining;

	public float critHitModifier;
	public int critHitChance;
	public float critScore;
	public float killScore;

	void Start()
	{

		gManager = GameObject.FindWithTag("gManager").GetComponent<CS_GameManager>();
		critHitChance = gManager.critChance;
		critHitModifier = gManager.critModifier;
		critScore = gManager.critScore;
		killScore = gManager.killScore;
		health = 100f;
		healthRemaining = health;
	}

	public void TakeDamage (float amount)
	{
		if(Random.Range(0, critHitChance) == 3)
		{
			healthRemaining = healthRemaining - (amount * critHitModifier);
			gManager.pScore = gManager.pScore + 5;
			if(healthRemaining <= 0f)
			{
				gManager.pScore = gManager.pScore + critScore;
				Die();
			}
		} else{
			healthRemaining = healthRemaining - amount;
			gManager.pScore = gManager.pScore + 5;
			if(healthRemaining <= 0f)
			{
				gManager.pScore = gManager.pScore + killScore;
				Die();
			}
		}
	}
	void Die()
	{
		gManager.killCount++;
		Destroy(transform.parent.gameObject);
	}
}
