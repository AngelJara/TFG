using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

	public float speed = 10f;
	public float runSpeed = 15f;
	public float turnSpeed = 40f;
	public float runningTurnSpeed = 40f;
	public float turnTime = 1f;
	public float thisSpeed;


	Vector3 movement;
	Quaternion rotation;
	Rigidbody playerRigidbody;
//	int floorMask;
//	float camRayLength = 100f;
	float timer;


	void Awake () {
//		floorMask = LayerMask.GetMask ("Floor");
		playerRigidbody = GetComponent<Rigidbody> ();
		timer = 1f;
	}
	

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float r = Input.GetAxisRaw ("Jump");
		timer += Time.deltaTime;


		Move (h,v,r);
		//Turning ();
	}

	void Move(float h, float v, float r){


		//movement.Set (0f, 0f, v);
		//movement = movement.normalized * (speed + r*runSpeed) * Time.deltaTime;
		//playerRigidbody.MovePosition (transform.localPosition + movement);
		//transform.localPosition = (transform.localPosition + movement);
		//playerRigidbody.MovePosition(Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)+(movement));



		thisSpeed = speed + r * runSpeed;


		rotation.Set (0f, transform.rotation.y + h, 0f, 0f);
		transform.RotateAround(transform.position,Vector3.up,h*(turnSpeed+runningTurnSpeed*r)*Time.deltaTime);

		if (v >= 0) {
			movement = transform.forward * v * thisSpeed * Time.deltaTime;
			playerRigidbody.MovePosition (playerRigidbody.position + movement);
		}


		else if (timer>=turnTime) {
			transform.RotateAround(transform.position,Vector3.up,transform.position.y - 180);
			timer = 0f;
			//transform.rotation.Set (transform.rotation.x, transform.rotation.y - 180, transform.rotation.z, transform.rotation.w);
		}
			

		/*movement2.Set (x, y, z);
		movement.Set (0f, 0f, v);
		movement = movement.normalized * (speed + r*runSpeed) * Time.deltaTime;
		transform.position = (transform.position + movement+movement2;*/


	}

	/*void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}*/
}
