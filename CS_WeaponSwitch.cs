using UnityEngine;

public class CS_WeaponSwitch : MonoBehaviour {

	public int weaponInt = 0;

	void Start()
	{
		SelectWeapon();
	}
	void Update()
	{
		int previousSelected = weaponInt;
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if(weaponInt >= transform.childCount -1)
			{
				weaponInt = 0;
			}
			else
			{
				weaponInt++;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if(weaponInt >= transform.childCount -1)
			{
				weaponInt = 0;
			}
			else
			{
				weaponInt++;
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			weaponInt = 0;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			weaponInt = 1;
		}
		
		if(previousSelected != weaponInt)
		{
			SelectWeapon();
		}
	}
	void SelectWeapon()
	{
		int i = 0;
		foreach (Transform weapon in transform)
		{
			if(i == weaponInt)
			{
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
