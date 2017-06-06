using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


	public Canvas HUDCanvas;
	public GameObject Player;
	public float smoothing = 15f;
	public float SpeedX = 10f;
	public float SpeedY = 10f;
	public float camPosX = 0;
	public float camPosY = 3;
	public float camPosZ = 5;
	public float MoveSpeed = 2;

	Transform lookingAt;

	Vector3 pos;
	//float timer;
//	float turnTime;
	Vector3 movement;
	Vector3 camPos;

	void Start () {



		//timer = 0f;
		//turnTime = ChangeManager.ChangeTime;

		//camPos.Set(Player.transform.position.x - camPosX, Player.transform.position.y + camPosY, Player.transform.position.z - camPosZ);
		//transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);



	}
	
	void FixedUpdate () {
		//transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		//transform.position = targetCamPos;


		float v = Input.GetAxis ("Vertical");


		float r = Input.GetAxisRaw ("Jump");



		//transform.RotateAround (Player.transform.position, Vector3.up * h, Player.GetComponent<Moving> ().thisSpeed *4* Time.deltaTime);


		//transform.rotation = camRot;


		//camPos.Set(Player.transform.position.x - camPosX, Player.transform.position.y + camPosY, Player.transform.position.z - camPosZ);
		//transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);


		if (HUDCanvas.GetComponent<OpenMenu> ().Closed == true) {
			Move (v, r);
			Turn ();
		}



		//float x = Input.GetAxis ("Mouse X");
		//float y = Input.GetAxis ("Mouse Y");




	}

	void Turn(){

		transform.LookAt (Player.transform);

		float xPos = Input.mousePosition.x / Screen.width;
		float yPos = Input.mousePosition.y / Screen.height;

		if (xPos > 1 || xPos < 0 || yPos > 1 || yPos < 0)
			return;
			
		float turnX;
		float turnY;

		if (xPos < 0.2f) {
			turnX = MoveSpeed;
			if (xPos < 0.1f) {
				turnX *= 2;
				//turnX += MoveSpeed * Time.deltaTime;
				if (xPos < 0.05f) {
					turnX *= 2;
					//turnX += MoveSpeed * Time.deltaTime;
				} 
			} 
		} 

		else if (xPos > 0.8f) {
			turnX = -MoveSpeed;
			if (xPos > 0.9f) {
				turnX *= 2;
				//turnX += -MoveSpeed * Time.deltaTime;
				if (xPos > 0.95f) {
					turnX *= 2;
					//turnX += -MoveSpeed * Time.deltaTime;
				}
			}
		}

		else {
			turnX = 0;
		}

		if (yPos < 0.3f) {
			turnY = MoveSpeed * Time.deltaTime;
			if (yPos < 0.2f) {
				turnY += MoveSpeed * Time.deltaTime;
				if (yPos < 0.1f) {
					turnY += MoveSpeed * Time.deltaTime;
				} 
			} 
		} 

		else if (yPos > 0.7f) {
			turnY = -MoveSpeed * Time.deltaTime;
			if (yPos > 0.8f) {
				turnY += -MoveSpeed * Time.deltaTime;
				if (yPos > 0.9f) {
					turnY += -MoveSpeed * Time.deltaTime;
				}
			}
		}
			
		else {
			turnY = 0;
		}

		//Debug.Log (turnX);


		transform.RotateAround (Player.transform.position, Vector3.up, turnX * Time.deltaTime);




		/*if (Mathf.Abs(transform.rotation.x) < 0.1f && turnY>0 || transform.rotation.x > 0.4f && turnY<0)
			turnY = 0;


		Debug.Log (Mathf.Abs(transform.rotation.x));
		transform.RotateAround (Player.transform.position, Vector3.left * turnY, MoveSpeed * Time.deltaTime);

		*/


	//	transform.RotateAround (Player.transform.position, Vector3.left * y, 20*Time.deltaTime);
	//	transform.RotateAround (Player.transform.position, Vector3.up * x, 20*Time.deltaTime);

	}

	void Move(float v, float r){


		//lookingAt = Player.transform;

		//Vector3 aux;

		//aux.Set(lookingAt.position.x,lookingAt.position.y,lookingAt.position.z += 5f);
		//lookingAt.position.Set(aux);

		//transform.LookAt (Player.transform);


		//transform.LookAt(Player.transform.GetChild(0).gameObject.transform);


		if (v >= 0) {

			//movement = transform.forward * v * Player.GetComponent<Moving>().thisSpeed * Time.deltaTime;
			movement = transform.forward * v * (Player.GetComponent<Move>().Speed+Player.GetComponent<Move>().Speed*r) * Time.deltaTime;
			movement.Set(movement.x+transform.position.x,transform.position.y,movement.z+transform.position.z);
			transform.position = (movement);
		}

	}

	public void ChangePlayer(float speed){


		pos.Set (Player.transform.position.x, Player.transform.position.y + camPosY, Player.transform.position.z - camPosZ);
		transform.position = Vector3.Lerp(transform.position, pos , speed * Time.deltaTime);

	}

}
