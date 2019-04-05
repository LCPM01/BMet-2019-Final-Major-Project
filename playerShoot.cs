using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerShoot : MonoBehaviour {

	public float damage = 50f;
	public float range = 100f;
	public float fireRate = 15f;

	public Camera cam;
	public ParticleSystem muzzleF;
	public Text ammoText;

	private float nextFire = 0f;

	public int maxAmmo = 15;
	private int currentAmmo;
	public float reloadPeriod = 1f;
	private bool isReloading = false;

	void Start()
	{
		currentAmmo = maxAmmo;
		ammoText.text = (currentAmmo + "/" + maxAmmo);
	}

	void OnEnable()
	{
		isReloading = false;
		ammoText.text = (currentAmmo + "/" + maxAmmo);
	}

	void Update () {
		if(isReloading)
		{
			return;
		}
		if(Input.GetButtonDown("Reload") && currentAmmo < maxAmmo)
		{
			StartCoroutine(Reload());
			return;
		}
		if(currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}
		if(Input.GetButtonDown("Fire1") && fireRate == 0f)
		{
			Shoot();
		}
		if(Input.GetButton("Fire1") && Time.time >= nextFire)
		{
			nextFire = Time.time + 1f/fireRate;
			Shoot();
		}
	}

	void Shoot()
	{
		currentAmmo--;
		ammoText.text = (currentAmmo + "/" + maxAmmo);
		muzzleF.Play();
		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			enemyScript eScript = hit.transform.GetComponent<enemyScript>();
			if(eScript != null)
			{
				eScript.TakeDamage(damage);
			}
		}
	}
	IEnumerator Reload()
	{
		isReloading = true;
		Debug.Log("Reloading...........");

		yield return new WaitForSeconds(reloadPeriod);

		currentAmmo = maxAmmo;
		ammoText.text = (currentAmmo + "/" + maxAmmo);
		isReloading = false;
	}
}
