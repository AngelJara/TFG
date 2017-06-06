using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	public float closeTime = 5f;
	public bool isLocked = false;
	public float closeSpeed  =2f;

	GameObject[] players;
	float timer;
	Vector3 open;
	Vector3 close;
	bool opening = false;
	bool closing = false;
	//MeshFilter door;



	void Start () {

		//door = transform.GetComponent<MeshFilter> ();
		timer = 0f;
		close.Set (transform.position.x, transform.position.y, transform.position.z);
		open.Set (transform.position.x, transform.position.y + transform.localScale.y+3f, transform.position.z);
		//players = GameObject.FindGameObjectsWithTag ("Character1");
	}
	

	void Update () {

		timer += Time.deltaTime;

		if (closing && timer <= closeTime && !isLocked) {
			closeDoor ();
		}



		if (opening && timer <= closeTime && !isLocked) {
			openDoor ();
		}


		//if(isLocked)
		//	Debug.Log (transform.position.y);
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Character1") {
			opening = true;
			closing = false;
			timer = 0;
		}
	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Character1") {
			timer = 0;
			closing = true;
			opening = false;


		}
	}

	void OnTriggerStay (Collider other){
		if (other.tag == "Character1") {
			timer = 0f;
		}
	}

	void openDoor(){

		//door.transform.position = Vector3.Lerp (door.transform.position, open, closeSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, open, closeSpeed * Time.deltaTime);


	}

	void closeDoor(){
		transform.position = Vector3.Lerp (transform.position, close, closeSpeed * Time.deltaTime);
		//door.transform.position = Vector3.Lerp (door.transform.position, close, closeSpeed * Time.deltaTime);

	}
}
