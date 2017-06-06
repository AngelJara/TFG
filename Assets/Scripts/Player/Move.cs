using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float Speed;
	public float turnSpeed;
	public float turnTime = 1f;
	public Canvas HUDCanvas;


	string movementAxisName;
	string turnAxisName;
	string runAxisName;
	Rigidbody rb;
	float movementInputValue;
	float turnInputValue;
	float runInputValue;
	float timer;



	void Awake(){
		rb = GetComponent<Rigidbody> ();
		timer = 1f;


	}

	/*void OnEnable(){
		rb.isKinematic = false;
		movementInputValue = 0f;
		turnInputValue = 0f;

	}

	void OnDisable(){
		rb.isKinematic = true;

	}*/

	void Start () {
		movementAxisName = "Vertical";
		turnAxisName = "Horizontal";
		runAxisName = "Jump";


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
	

	void Update () {
		movementInputValue = Input.GetAxis (movementAxisName);
		turnInputValue = Input.GetAxis (turnAxisName);
		runInputValue = Input.GetAxis (runAxisName);
		timer += Time.deltaTime;
	}

	void FixedUpdate(){

		if (HUDCanvas.GetComponent<OpenMenu> ().Closed == true) {
			Moves ();
			Turns ();
		}
	}

	void Moves(){

		if (movementInputValue >= 0) {

			Vector3 movement = transform.forward * movementInputValue * (Speed + Speed*runInputValue) * Time.deltaTime;
			rb.MovePosition (rb.position + movement);
		}

		else if (timer>=turnTime) {
			transform.RotateAround(transform.position,Vector3.up,transform.position.y - 180);
			timer = 0f;
		}
	}

	void Turns(){
		float turn = turnInputValue * (turnSpeed+turnSpeed*runInputValue) * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		rb.MoveRotation (rb.rotation * turnRotation);

	}
}
