using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollController : MonoBehaviour {

	private Rigidbody mainRigidbody;
	private Collider mainCollider;
	private Rigidbody[] childRigidbodies;
	private Collider[] childColliders;

	private Animator anim;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		mainRigidbody = GetComponent<Rigidbody> ();
		mainCollider = GetComponent<Collider> ();
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

		childRigidbodies = GetComponentsInChildren<Rigidbody> ();
		childColliders = GetComponentsInChildren <Collider> ();

		Deactivate ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Deactivate(){

		// children are off
		foreach (Rigidbody rb in childRigidbodies) {
			rb.isKinematic = true;
		}

		foreach (Collider c in childColliders) {
			c.enabled = false;
		}
		// main objects are on
		mainCollider.enabled = true;
		mainRigidbody.isKinematic = false;
		anim.enabled = true;
		agent.enabled = true;

	}

	public void Activate(){

		//children are on 
		foreach (Rigidbody rb in childRigidbodies) {
			rb.isKinematic = false;
		}
		foreach (Collider c in childColliders) {
			c.enabled = true;
		}
		// main objects are off
		mainCollider.enabled = false;
		mainRigidbody.isKinematic = true;
		anim.enabled = false;
		agent.enabled = false;

	}







}
