﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	private bool hit = false;
	[SerializeField] private Transform fpsTarget;
	Rigidbody theRigidbody;

	// Use this for initialization
	void Start () {
		theRigidbody = GetComponent<Rigidbody> ();
		fpsTarget = GameObject.FindWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if(fpsTargetDistance < enemyLookDistance && fpsTargetDistance > attackDistance && hit == false){
			lookAtPlayer ();

		}
		if (fpsTargetDistance < attackDistance &&  hit == false) {
			baseAttack ();
			hit = true;
		}

		if (fpsTargetDistance > 3 && hit == true){
			hit = false;

			theRigidbody.velocity = Vector3.zero;
			theRigidbody.angularVelocity = Vector3.zero;
		}

		if (fpsTargetDistance <= attackDistance && hit == true) {
			hitReturn ();

		}

		if (fpsTargetDistance > enemyLookDistance) {
			theRigidbody.velocity = Vector3.zero;
			theRigidbody.angularVelocity = Vector3.zero;
		}

	}

	void baseAttack (){
		theRigidbody.velocity = Vector3.zero;
		theRigidbody.angularVelocity = Vector3.zero;
		//theRigidbody.position = transform.position;


	}

	void hitReturn (){
		theRigidbody.AddForce (transform.forward * (-1 * enemyMovementSpeed));

	}

	void lookAtPlayer (){
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		theRigidbody.AddForce (transform.forward * enemyMovementSpeed);
		//Vector3 moveHorizontal = transform.right * enemyMovementSpeed;
		//Vector3 moveVertical = transform.forward * enemyMovementSpeed;
		//Vector3 movement = (moveHorizontal + moveVertical).normalized;
		//theRigidbody.MovePosition (theRigidbody.position + Vector3 (10, 0, 0) * Time.fixedDeltaTime);
	}
}
