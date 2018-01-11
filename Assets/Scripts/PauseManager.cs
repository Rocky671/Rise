using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	public static PauseManager instance;

	public bool isPaused;

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		// singleton
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		unPause ();
	}

	// Update is called once per frame
	void Update () {

		// Toggles the pause
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused)
				unPause ();
			else
				pause ();
		}

	}

	/// <summary>
	/// unPause this game.
	/// </summary>
	public void unPause(){
		isPaused = false;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
	}

	/// <summary>
	/// Pause this game.
	/// </summary>
	public void pause(){
		isPaused = true;
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
	}
}
