using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum Movement{
	calm, walking, running
}

public class Following : MonoBehaviour {

	public GameObject Player;
	public NavMeshAgent nav;
	float distance;
	float RunToWalk = 70f;
	float WalkToCalm = 15f;
	float RunSpeed = 20f;
	float WalkSpeed = 5f;
	Movement moving;




	void Awake () {
		moving = Movement.calm;
		nav = transform.GetComponent<NavMeshAgent> ();
	}
	

	void Update () {
		distance = Vector3.Distance (Player.transform.position, transform.position);


		if (distance > RunToWalk) {
			moving = Movement.running;
		} else if (distance > WalkToCalm) {
			moving = Movement.walking;
		} else {
			moving = Movement.calm;
		}

		Moves ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Character1") {
			transform.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Character1") {
			transform.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

	void Moves(){
		//transform.LookAt (Player.transform.position,Vector3.zero);

		if (moving == Movement.running) {
			//nav.isStopped = false;
			nav.enabled = true;
			nav.SetDestination (Player.transform.position);
			nav.speed = RunSpeed;
		} else if (moving == Movement.walking) {
			//nav.isStopped = false;
			nav.enabled = true;
			nav.SetDestination (Player.transform.position);
			nav.speed = WalkSpeed;
		} else {
			//nav.isStopped == true;
			nav.speed = 0f;
			nav.enabled = false;
		}


	}
}
