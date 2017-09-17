using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forearmBend : MonoBehaviour {

	private Animator testAnim;
	//private GameObject test
	private float vert;
	private float horz;
	private float time;
	private Transform leftArmRotation;
	private HumanBodyBones leftForearm = HumanBodyBones.LeftLowerArm;
	private HumanBodyBones leftShoulder = HumanBodyBones.LeftUpperArm;
	private HumanBodyBones leftHand = HumanBodyBones.LeftHand;

	private float shoulderMaxZ = 45f;
	private float shoulderMinZ = -90f;

	private float shoulderMaxX = 130f;
	private float shoulderMinX = -45;

	private float shoulderRotationX = 0f;
	private float shoulderRotationZ = 60f;
	private float shoulderRotationY = 0f;

	private float forearmRotationX = 0f;
	private float forearmRotationZ = 0f;
	private float forearmRotationY = 0f;

	private float forearmMaxY = 135f;
	private float forearmMinY = -25f;

	private float forearmMaxX = 135f;
	private float forearmMinX = 0;

	private float handRotationX = 0f;
	private float handRotationZ = 0f;
	private float handRotationY = 0f;
	private int counter = 0;
	private Vector3 initialRotation = new Vector3(0,0,0);



	//private float timePassed = 0f;

	//private Vector3 increment = Vector3(30,0,0);

	// Use this for initialization
	void Start () {

		//Transform forearmLoc = GameObject.Find("LeftLowerArm").transform;
		testAnim = GetComponent<Animator> ();
		testAnim.speed = 0;

		//leftArmRotation = testAnim.GetBoneTransform (HumanBodyBones.LeftLowerArm);
		//leftArmRotation = GameObject.transform.forearm;
//		Transform forearmLoc = GameObject.Find("LeftLowerArm").transform;

		//Transform forearmLoc = .Find("LeftLowerArm").transform;

		leftArmRotation = testAnim.GetBoneTransform (leftForearm);


	}
	
	// Update is called once per frame
	void Update () {

		horz = Input.GetAxis ("Vertical");
		time = testAnim.GetCurrentAnimatorStateInfo (0).normalizedTime;
		//print (time);
		if (horz > 0 && time < 0.5) {
			testAnim.SetFloat ("Speed", 1);
			testAnim.speed = 1;
		} else if (horz < 0 && (time <= 0.53 && time > 0.01)) {
			testAnim.SetFloat ("Speed", -1);
			testAnim.speed = 1;
		} else if (horz > 0 && (time >= 0.5 && time <= 0.53)) {
			testAnim.speed = 0;
		}
		else
		{
			testAnim.speed = 0;
		}

	}

	void OnAnimatorIK() {
		print (Time.deltaTime);


		testAnim.SetBoneLocalRotation (leftShoulder, Quaternion.Euler (new Vector3 (shoulderRotationX, shoulderRotationY, shoulderRotationZ)));
		testAnim.SetBoneLocalRotation (leftForearm, Quaternion.Euler (new Vector3 (forearmRotationX, forearmRotationY, forearmRotationZ)));
		testAnim.SetBoneLocalRotation (leftHand, Quaternion.Euler (new Vector3 (handRotationX, handRotationY, handRotationZ)));

		//if (Input.GetButton("Fire1")) {
			//Quaternion testQuat = Quaternion (1);
			//testAnim.SetBoneLocalRotation(forearm, testQuat );
		//timePassed += 15*Time.deltaTime;

		//print (xRotate);


		//-------------------------------------------------------------------//
		/*-------------------------------Forearm Movement--------------------*/
		//-------------------------------------------------------------------//
		/*
		if (timePassed <= 135) {
			testAnim.SetBoneLocalRotation (leftForearm, Quaternion.Euler (new Vector3 (0, timePassed, 0)));
			timePassed += 15 * Time.deltaTime;
		} else {
			testAnim.SetBoneLocalRotation (leftForearm, Quaternion.Euler (new Vector3 (0, timePassed, 0)));
		}
		*/
		//-------------------------------------------------------------------//

		//-------------------------------------------------------------------//
		/*-------------------------------Shoulder Movement-------------------*/
		//-------------------------------------------------------------------//

		vert= Input.GetAxis ("Vertical");

		if (vert > 0) {
			forearmRotationX += 10 * Time.deltaTime;
		}



		if (forearmRotationX < forearmMaxX) {

			forearmRotationY += (90 / 135) * (10) * Time.deltaTime;

			testAnim.SetBoneLocalRotation (
				leftForearm, 
				Quaternion.Euler (new Vector3 (forearmRotationX, forearmRotationY, forearmRotationZ)));
		} else {
			forearmRotationX -= 10 * Time.deltaTime;
		}

			
			//shoulderRotationZ -= 15 * Time.deltaTime;



			//forearmLoc += increment;
			//print(1);
		//print(new Vector3(Time.deltaTime,0,0) );

			//leftArmRotation.Rotate (Time.deltaTime, Time.deltaTime, Time.);

		//}
		//print (Quaternion.identity);
		
	}

	void LateUpdate() {


		//print (leftArmRotation);

		//print(forearmLoc);


		//forearmLoc.Rotate (Vector3.right * Time.deltaTime);

	}

}
