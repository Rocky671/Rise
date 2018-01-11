using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// if user clicks menu button, game will load menu
	public void mainMenu(){
		SceneManager.LoadScene ("Menu");
	}

	// if the user clicks start game, loads game
	public void startGame()
	{
		SceneManager.LoadScene ("Heraklios");
	}

	public void optionsMenu()
	{
		SceneManager.LoadScene ("Options");
	}


	public void quitGame()
	{
		// quits game during play of application
		#if UNITY_STANDALONE
		Application.Quit();
		#endif

		// allows quit to be used during unity editor
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	// if user clicks resume game, game resumes
	public void resumeGame(){
		PauseManager.instance.unPause ();
	}
}
