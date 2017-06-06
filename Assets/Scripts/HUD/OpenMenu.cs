using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {


	public bool Closed;


	Animator anim;
	float timer;
	string itemButton;
	bool animating;



	void Awake () {
		itemButton = "Item";
		anim = GetComponent<Animator> ();
		timer = 0f;
		animating = false;

	}
	
	void Update () {

		Closed = anim.GetBool ("Closed");

		float button;

		button = Input.GetAxis (itemButton);

		if (button != 0f && !animating) {

			anim.SetTrigger ("ButtonPressed");
			animating = true;
		}

		if (animating) {
			timer += Time.deltaTime;
			anim.SetFloat ("AnimationTime", timer);
		}

		if (timer >= 1f) {
			animating = false;
			timer = 0f;
			if (anim.GetBool ("Closed") == true) {
				anim.SetBool ("Closed", false);
			} 

			else {
				anim.SetBool ("Closed", true);
			}
		}
	}
}
