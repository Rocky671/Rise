using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]

public abstract class PickUpClass : MonoBehaviour {
	private Transform tf;

	[Header("Spin Speed")]
	public int SpinSpeed = 90;

	[SerializeField]
	private UnityEvent OnTrigger;

	private new Collider collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider> ();
		collider.isTrigger = true;
		tf = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		Spin ();
	}

	/// <summary>
	/// Once player picks up the item, destroy game object
	/// only the player can pick up items
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")){
			pickUp (other);

			// Call any other functions 
			OnTrigger.Invoke ();

			// destroy object
			Destroy (gameObject);
		}

	}

	// spins the game object
	void Spin(){
		tf.Rotate(0, SpinSpeed * Time.deltaTime, 0);
	}

	// pick up inheritance class
	public virtual void pickUp(Collider other){

	}

}
