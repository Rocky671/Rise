using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSetter : MonoBehaviour {

	public AudioMixer mixer;

	// Use this for initialization
	void Start () {
		// mutes if lower than 20
		if (PlayerPrefs.GetFloat ("SFX", 0.0F) < -20.0) {
			mixer.SetFloat ("SFX", -80.0F);
		} else {
			mixer.SetFloat ("SFX", PlayerPrefs.GetFloat ("SFX", 0.0F));
		}

		// mutes if lower than 20
		if (PlayerPrefs.GetFloat ("BGM", 0.0F) < -20.0) {
			mixer.SetFloat ("BGM", -80.0F);
		} else {
			mixer.SetFloat ("BGM", PlayerPrefs.GetFloat ("BGM", 0.0F));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
