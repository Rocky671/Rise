﻿	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	[Header("Health Options")]
	public int health;
	public Slider healthSlider;
	[SerializeField]
	private UnityEvent OnDeath;
	public AudioSource deathSound;

	[Header("Bullet Damage")]
	public int bulletDamage = 10;



	// Use this for initialization
	void Start () {
		health = 100;	


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// when player picks up this item, heal player.
	/// </summary>
	/// <param name="healthToGive">Health to give.</param>
	public void giveHealth(int healthToGive) {
		health = health + healthToGive;

		if(healthSlider != null){
			healthSlider.value = health;
		}
	}

	/// <summary>
	/// if a bullet collides with the target, deal damage to players health.
	/// if a targets health goes less than or equal to 0, set object to false and then respawn it in 5 seconds.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Bullet")) {
			health -= bulletDamage;

			if(healthSlider != null){
				healthSlider.value = health;
			}

			if (health <= 0) {
				if (gameObject.CompareTag ("Player")) {
					// set player to inactive if he dies
					gameObject.SetActive (false);
					if (deathSound != null) {
						deathSound.Play ();
					}

				}

				OnDeath.Invoke ();
			}
		}
	}

	/// <summary>
	/// Respawn this object
	/// </summary>
	public void respawn() {
			gameObject.SetActive (true);
	}

}
