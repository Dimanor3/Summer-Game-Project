using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;
	Rigidbody theRigidbody;

	// Use this for initialization
	void Start () {
		theRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if(fpsTargetDistance < enemyLookDistance){
			lookAtPlayer ();

		}
		if (fpsTargetDistance < attackDistance) {
			baseAttack ();
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
	void lookAtPlayer (){
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		theRigidbody.AddForce (transform.forward*enemyMovementSpeed);

	}
}
