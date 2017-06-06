using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour {

	public static float ChangeTime = 2f;
	public GameObject cam;
	public GameObject[] characters;
	GameObject leader;
	float changeButton;
	float timer;


	int leaderNumber;

	
	void Awake () {


		timer = 0f;


		if (characters.Length > 0) {
			leaderNumber = 0;
			leader = characters [0];
			cam.transform.GetComponent<CameraMovement> ().Player = leader;
			cam.transform.GetComponent<CameraMovement> ().ChangePlayer (100);
			leader.GetComponent<Move> ().enabled = true;
			leader.GetComponent<Following> ().enabled = false;

			for (int i = 1; i < characters.Length; i++) {
				characters [i].GetComponent<Move> ().enabled = false;
				characters [i].GetComponent<Following> ().enabled = true;
				characters [i].GetComponent<Following> ().Player = leader;
			}
		}
	}
	

	void Update () {
		changeButton = Input.GetAxis("ChangeCharacter");
		if (changeButton!=0 && timer > ChangeTime)
			Change (changeButton);
			timer += Time.deltaTime;

	}

	void Change(float button){
		if (leaderNumber == characters.Length - 1) {
			leaderNumber = 0;
		} else
			leaderNumber++;

		for (int i = 0; i < characters.Length; i++) { 
			if (i == leaderNumber) {
				leader = characters [i];
				cam.transform.GetComponent<CameraMovement> ().Player = leader;
				cam.transform.GetComponent<CameraMovement> ().ChangePlayer (100);
				leader.GetComponent<Move> ().enabled = true;
				leader.GetComponent<Following> ().nav.enabled = false;
				leader.GetComponent<Following> ().enabled = false;

			}


			else {
				characters [i].GetComponent<Move> ().enabled = false;
				characters [i].GetComponent<Following> ().enabled = true;
				characters [i].GetComponent<Following> ().nav.enabled = true;
				characters [i].GetComponent<Following> ().Player = leader;
				leader.GetComponent<Following> ().nav.enabled = true;
			}
		}

		timer = 0f;

	}
}
