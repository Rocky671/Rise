using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform tf;
	private Transform prtf;

	// Use this for initialization
	void Start () {
		prtf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		prtf.position = new Vector3 (tf.position.x, 15, tf.position.z);
	}
}
