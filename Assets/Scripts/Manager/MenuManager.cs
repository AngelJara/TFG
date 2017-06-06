using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject ItemImage;
	public GameObject MenuImage;



	string ItemButton;
	string MenuButton;
	bool itemActive;
	bool menuActive;


	void Awake(){
		ItemButton = "ItemButton";
		MenuButton = "MenuButton";

		itemActive = false;
		menuActive = false;

	}

	void Update(){
		float item = Input.GetAxisRaw (ItemButton);
		float menu = Input.GetAxisRaw (MenuButton);

		if (item != 0) {
			Check (itemActive);
		}

		if (menu != 0) {
			Check (menuActive);

		}

	}

	void Check(bool active){
		if (active) {
			active = false;

		} 
		else 
		{
			active = true;

		}
	}



}
