using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(Health))] 

public class Lives : MonoBehaviour {

	public GameObject[] lifeIcons;
	private int playerLives;

	// Use this for initialization
	void Start () {
		// sets player lives into 3
		playerLives = 3;

		// sets all life icons active
		foreach (GameObject icon in lifeIcons){
			icon.SetActive (true);
		}
	}

	/// <summary>
	/// Loses the life.
	/// </summary>
	public void loseLife(){
		// minus's player lives
		playerLives--;

		// sets player lives to false 
		lifeIcons [playerLives].SetActive (false);

		// if player loses all lives, loads lose screen
		if (playerLives <= 0) {
			SceneManager.LoadScene ("Lose");
			return;
		}

		// player respawns after 2 seconds
		Invoke ("respawn", 4.0f);
	}
		
	private void respawn()
	{
		// sends player to position zero
		transform.position = Vector3.zero;
		// gives player full health
		GetComponent<Health> ().giveHealth (100);
		// sets player to active again
		GetComponent<Health> ().respawn();
	}
}
