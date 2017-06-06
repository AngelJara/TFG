using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

	public GameObject HUD;
	//public GameObject Inventory;

	private float changeTime;
	private float timer;
	bool changed = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (HUD);
		//DontDestroyOnLoad (Inventory);
		timer = 0;
		changeTime = 5f;

	}
	
	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
		if (timer >= changeTime && !changed) {
			ChangeScene ();

		}
	}

	public void ChangeScene(){

		changed = true;
		Debug.Log ("Hola");
		SceneManager.LoadScene (1, LoadSceneMode.Single);

	}
}
