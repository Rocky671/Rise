using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
    private Transform tf;
    private Animator anim;

	[Header("Stamina Options")]
	[SerializeField]
    private int stamina;
	public Slider staminaSlider;

	[Header("Movement Options")]
    public float turnSpeed;
    public float moveSpeed;

	[Header("Hand Placements")]
	public Transform rightHand;
	public Transform leftHand;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
        anim = GetComponent<Animator>();

		// starting stamina of 600
		stamina = 600;
	}
	
	// Update is called once per frame
	void Update () {
		// allows user to set movespeed
        anim.speed = moveSpeed;

        faceTowardsMouse();

        // Sets the animation to match the input
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

		staminaCount ();
	}
		

	/// <summary>
	/// Stamina Tracker
	/// </summary>
    void staminaCount()
	{
		// displays stamina
		staminaSlider.value = stamina;
		// when user holds the left shift button, character will sprint.
		if (Input.GetKey (KeyCode.LeftShift)) {
			// if stamina is greater than 0, stamina will -1 per frame while the key is held down
			if (stamina > 0) {
				stamina = stamina - 1;
				anim.SetFloat ("Vertical", Input.GetAxis ("Vertical") * 2);
			}
				
			// if stamina is less than 600, it will add 1 stamina per frame
		} else {
			if (stamina < 600) {
				stamina = stamina + 1;
			}
		}
    }

	/// <summary>
	/// Faces the player towards the mouse
	/// </summary>
    void faceTowardsMouse()
    {
        // Creates an imaginary plane for the character 
        Plane groundPlane;
        groundPlane = new Plane(Vector3.up, tf.position);

        // finds how far the raycast is from the camera
        Ray castRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

		// 
        if (groundPlane.Raycast(castRay, out distance)){
			// the target point is "that far" from the ray
            Vector3 lookPoint = castRay.GetPoint(distance);

			// calculates the angle to look at the point
            Quaternion endRotation;
            Vector3 lookVector;

			// length of vector between vector itself and where you look 
            lookVector = lookPoint - tf.position;
            endRotation = Quaternion.LookRotation(lookVector);

			// rotates toward the angle
            tf.rotation = Quaternion.RotateTowards(tf.rotation, endRotation, turnSpeed * Time.deltaTime);
        }

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




}
