using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour {

	public Text currentPoints;
	public int points;

	// Use this for initialization
	void Start () {
		points = 0;

		updatePointText();
	}

	/// <summary>
	/// Adds a point to score. If user reaches 10 points, user wins game (loads win screen)
	/// </summary>
	public void addPoints(){
		points++;
		updatePointText ();

		if (points >= 10) {
			SceneManager.LoadScene ("Win");
		}
	}

	// updates the text box with a point
	void updatePointText(){
		currentPoints.text = "Points: " + points;
	}
}
