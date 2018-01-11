using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {
	private Transform tf;
	private Animator anim;
	private NavMeshAgent agent;
	private GameObject player;

	public enum AIStates{Idle, Attack, Dead};
	public AIStates currentState;

	public GameObject bullet;
	public Transform muzzle;

	[Header("View Data")]
	public float fieldOfView;
	public float viewDistance;

	[Header("Hand Placements")]
	public Transform rightHand;
	public Transform leftHand;

	[Header("Bullet/Gun Attributes")]
	public float shootForce;
	public float shotsPerSecond;
	public int numberOfBullets;
	public float lifespan = 5.0f;
	public float spread; 

	private float nextShotTime;


	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

		player = GameObject.FindGameObjectWithTag ("Player");

		currentState = AIStates.Attack;

	}
	
	// Update is called once per frame
	void Update () {
		// if the state is idle, do the idle function
		if (currentState == AIStates.Idle) {
			DoIdle ();
			// if the enemy can see player, switch to attack state
			if (CanSee (player)) {
				currentState = AIStates.Attack;
			}
			// if the state is on attack, do the attack function
		} else if (currentState == AIStates.Attack) {
			DoAttack ();
			// if he can't see player, switch to idle
			if (!CanSee (player)) {
				currentState = AIStates.Idle;
			}
			// if the state is on dead, do the dead function
		} else if (currentState == AIStates.Dead) {
			DoDead ();
		}

			
	}

	bool CanSee(GameObject target){
		// Checking if target exists
		if (target == null) {
			return false;
		}

		// Checks if in field of view
		Vector3 vectorToTarget = target.transform.position - tf.position;
		if (Vector3.Angle (tf.forward, vectorToTarget) <= fieldOfView) {
			RaycastHit info;

			// check if ray cast hits something
			if (Physics.Raycast (tf.position, vectorToTarget, out info, viewDistance)) {
				if (info.collider.gameObject == target) {
					return true;
				}
			}
		}

		return false;
	}

	// shoot function for the enemy
	void Shoot (){
		if (Time.time >= nextShotTime) {
			GameObject spawnedBullet = Instantiate (bullet, muzzle.position, muzzle.rotation);// spawns a new bullet from muzzle position
			spawnedBullet.GetComponent<Rigidbody> ().AddForce (muzzle.forward * shootForce);// gives force to bullet
			Destroy (spawnedBullet, lifespan); // destroy bullet after a certain time
			nextShotTime = Time.time + 1.0f / shotsPerSecond; // amount of shots per second
		}
	}


	void DoIdle(){
		// realized this was causing enemy to stutter step
		//anim.SetFloat ("Horizontal", 0.0f);
		//anim.SetFloat ("Vertical", 0.0f);

		//agent.Stop ();
	}

	void DoAttack(){
		Shoot ();

		//agent.Resume ();
		if (player == null)
			return;

		// sets enemy destination to player
		agent.SetDestination (player.transform.position);
		Vector3 localizedVelocity = tf.InverseTransformDirection (agent.desiredVelocity);
		anim.SetFloat ("Horizontal", localizedVelocity.x);
		anim.SetFloat ("Vertical", localizedVelocity.z);
	}

	void DoDead(){

	}

	/// <summary>
	/// Uses IK for hand placements
	/// </summary>
	public void OnAnimatorIK() {
		// if there is a right hand
		if (rightHand != null) {
			// set IK Point to that position
			anim.SetIKPosition (AvatarIKGoal.RightHand, rightHand.position);
			// set IK weight to 1
			anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1.0f);
			// set the Ik rotation to that rotation
			anim.SetIKRotation (AvatarIKGoal.RightHand, rightHand.rotation);
			// set IK rotation weight to 1
			anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 1.0f);
		} else {
			// set the Ik weight and rotation to 0
			anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 0.0f);
			anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 0.0f);
		}


		// if there is a left hand
		if (leftHand != null) {
			// set IK Point to that position
			anim.SetIKPosition (AvatarIKGoal.LeftHand, leftHand.position);
			// set IK weight to 1
			anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1.0f);
			// set the Ik rotation to that rotation
			anim.SetIKRotation (AvatarIKGoal.LeftHand, leftHand.rotation);
			// set IK rotation weight to 1
			anim.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1.0f);
		} else {
			// set the Ik weight and rotation to 0	
			anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 0.0f);
			anim.SetIKRotationWeight (AvatarIKGoal.LeftHand, 0.0f);
		}
	}

	// checks to make sure the agent and anim are not null
	private void OnAnimatorMove(){
		if (agent != null && anim != null) {
			agent.velocity = anim.velocity;
		}
	}

	/// <summary>
	/// if enemy dies, do dead state
	/// </summary>
	public void hesDead(){
		currentState = AIStates.Dead;
	}
}
