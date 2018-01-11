using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {
	public AudioMixer mixer;

	public Slider SFXSlider;
	public Slider BGMSlider;

	public Dropdown resolutionList;
	private List<string> resStrings;


	// Use this for initialization
	void Start () {
		// Gets the players preference for volume
		SFXSlider.value = PlayerPrefs.GetFloat ("SFX", 1.0f);
		BGMSlider.value = PlayerPrefs.GetFloat ("BGM", 1.0f);

		// if the volume chosen is lower than 20, mute volume. 
		if (SFXSlider.value < -20.0) {
			mixer.SetFloat ("SFX", -80.0F);
		} else {
			mixer.SetFloat ("SFX", SFXSlider.value);
		}

		// if the volume chosen is lower than 20, mute volume. 
		if (BGMSlider.value < -20.0) {
			mixer.SetFloat ("BGM", -80.0F);
		} else {
			mixer.SetFloat ("BGM", BGMSlider.value);
		}

		// lists the resolutions available
		resStrings = new List<string> ();
		foreach (Resolution res in Screen.resolutions)
		{
			if (!resStrings.Contains(res.ToString()))
				resStrings.Add (res.ToString ());
		}

		resolutionList.AddOptions (resStrings);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// sets the volume
	/// </summary>
	/// <param name="newVol">New vol.</param>
	public void SFX(float newVol)
	{
		// sets player preference from options menu
		PlayerPrefs.SetFloat("SFX", newVol);

		if (newVol < -20.0) {
			mixer.SetFloat ("SFX", -80.0F);
		} else {
			mixer.SetFloat ("SFX", newVol);
		}
	}

	/// <summary>
	/// sets the background volume 
	/// </summary>
	/// <param name="newVol">New vol.</param>
	public void background (float newVol)
	{
		// sets player preference from option menu
		PlayerPrefs.SetFloat("BGM", newVol);


		if (newVol < -20.0) {
			mixer.SetFloat ("BGM", -80.0F);
		} else {
			mixer.SetFloat ("BGM", newVol);
		}
	}






}
