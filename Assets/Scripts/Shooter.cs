using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
	public Transform muzzle;
	public GameObject muzzleFlash;

	private AudioSource gunSound;

	[Header("Bullet/Gun Attributes")]
	public float shootForce;
	public float shotsPerSecond;
	public int numberOfBullets;
	public float lifespan = 5.0f;
	public float spread; 

	private float nextShotTime;


	// Use this for initialization
	void Start () {
		nextShotTime = Time.time;
		gunSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && Time.time >= nextShotTime && !PauseManager.instance.isPaused) {
			// spawns a new bullet from muzzle position
			GameObject spawnedBullet = Instantiate (bullet, muzzle.position, muzzle.rotation);
			// gives force to bullet
			spawnedBullet.GetComponent<Rigidbody> ().AddForce (muzzle.forward * shootForce);
			// creates a muzzle flash
			GameObject flash = Instantiate (muzzleFlash, muzzle.position + Vector3.up, muzzle.rotation);
			// destroy bullet after a certain time
			Destroy (spawnedBullet, lifespan); 
			//Destroy (flash, 1.0F); 
			// amount of shots per second
			nextShotTime = Time.time + 1.0f / shotsPerSecond;
			// play gun shot
			gunSound.Play ();






		}
	}
}
