using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIcons : MonoBehaviour {

	[Header("Weapon Icons")]
	public GameObject ump45;
	public GameObject mp5;
	public GameObject pistol;

	/// <summary>
	/// Changes the weapon icon.
	/// </summary>
	/// <param name="icon">Icon.</param>
	public void changeWeaponIcon(string icon)
	{
		ump45.SetActive (false);
		mp5.SetActive (false);
		pistol.SetActive (false);

		if (icon == "mp5") {
			mp5.SetActive (true);
		}

		if (icon == "pistol") {
			pistol.SetActive (true);
		}

		if (icon == "ump45") {
			ump45.SetActive (true);
		}
	}
}
