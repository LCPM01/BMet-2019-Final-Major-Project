using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CS_WeaponScript : MonoBehaviour {

	public float damage = 50f;
	public float range = 100f;
	public float fireRate = 15f;
	public bool fireRateBool = false;
	public float shakePower = 0.1f;
	public float shakeDuration = 0.4f;

	public Camera cam;
	public ParticleSystem muzzleF;
	public CS_CameraShake camShake;
	public Text ammoText;

	private float nextFire = 0f;

	public int maxAmmo = 120;
	public int maxMagazine = 15;
	public int remainingAmmo;
	private int ammoShot;
	public int currentAmmo;
	public float reloadPeriod = 1f;
	private bool isReloading = false;

	public CS_GameManager gManager;

	void Start()
	{
		gManager = GameObject.FindWithTag("gManager").GetComponent<CS_GameManager>();

		currentAmmo = maxMagazine;
		remainingAmmo = maxAmmo;
		ammoShot = 0;
		ammoText.text = (currentAmmo + "/" + remainingAmmo);
	}

	void OnEnable()
	{
		isReloading = false;
		ammoText.text = (currentAmmo + "/" + remainingAmmo);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collider Trigger");
		if(other.tag == "ammoCrate")
		{
			Debug.Log("AmmoCrate");
			if(remainingAmmo < maxAmmo)
			{
				remainingAmmo = maxAmmo;
				ammoText.text = (currentAmmo + "/" + remainingAmmo);
			} else
			{
				Debug.Log("Else Statement Reached");
			}
		}
	}

	void Update () {

		//Physics.queriesStartInColliders = false;

		if(isReloading)
		{
			return;
		}
		if(Input.GetButtonDown("Reload") && currentAmmo < remainingAmmo && currentAmmo != maxMagazine)
		{
			StartCoroutine(Reload());
			return;
		}
		if(currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}
		if(Input.GetButtonDown("Fire1") && fireRateBool == false)
		{
			Shoot();
		}
		if(Input.GetButton("Fire1") && fireRateBool == true && Time.time >= nextFire)
		{
			nextFire = Time.time + 1f/fireRate;
			Shoot();
		}
	}

	void Shoot()
	{
		currentAmmo--;
		ammoShot++;
		ammoText.text = (currentAmmo + "/" + remainingAmmo);
		//StartCoroutine(camShake.CamShake(shakeDuration, shakePower));
		muzzleF.Play();
		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			CS_EnemyScript eScript = hit.transform.GetComponent<CS_EnemyScript>();
			if(eScript != null)
			{
				Debug.Log("Enemy");
				eScript.TakeDamage(damage);
				gManager.bFired++;
				gManager.bHit++;
			} else {
				Debug.Log("No Enemy");
				gManager.bFired++;
			}
		}
	}
	IEnumerator Reload()
	{
		isReloading = true;
		Debug.Log("Reloading...........");

		yield return new WaitForSeconds(reloadPeriod);

		remainingAmmo = remainingAmmo - ammoShot;
		ammoShot = 0;
		currentAmmo = maxMagazine;
		ammoText.text = (currentAmmo + "/" + remainingAmmo);
		isReloading = false;
	}
}
