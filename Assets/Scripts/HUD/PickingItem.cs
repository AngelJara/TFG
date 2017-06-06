using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickingItem : MonoBehaviour {

	public GameObject ItemImage;
	public GameObject Inventory;
	public Text text;
	public float ItemNumber;
	public float ChangeSceneTimer = 5f;

	private GameObject inventoryItem;
	private float pickedNumber = 0;
	float timer;

	void Start() {
		inventoryItem = Inventory.transform.Find (transform.name).gameObject;
		timer = 0;
	}
	

	void Update () {
		//text.text = (pickedNumber + "/" + ItemNumber);

		if (pickedNumber == ItemNumber) {
			timer += Time.deltaTime;
			if (timer >= ChangeSceneTimer) {
				
			}

		}
		
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Character1") {
			inventoryItem.SetActive(true);
			Destroy (transform.gameObject);
			ItemImage.SetActive(true);


		}
	}
}
