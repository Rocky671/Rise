using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapons : PickUpClass {

	public GameObject playerWeapon;
	public GameObject weaponPickup;

	public override void pickUp(Collider other){
		// check if what is collided with is the player. 
		if (other.gameObject.CompareTag("Player")) {

			// set weapon to false upon pickup, set current weapon in hand to false and new weapon picked up to true 
			playerWeapon.SetActive (false);
			gameObject.SetActive (true);
			weaponPickup.SetActive (true);


		}
	}

}
