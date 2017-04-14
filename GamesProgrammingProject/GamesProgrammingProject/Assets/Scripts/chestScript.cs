using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour {

	Animator anim;

	bool open;
	bool inRange;
	string chestString;
	string objectText;

	void Start () {
		chestString = "Press L to open";
		open = false;
		inRange = false;
		anim = this.gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player" && open == false) {
			inRange = true;
			GameManager.textUi = chestString;
		} 
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player" && open == false) {
			inRange = true;
			GameManager.textUi = chestString;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			inRange = false;
			GameManager.textUi = " ";

		}
	}

	void stringText(){
		if (GameManager.inventoryCount == 0) {
			objectText = "Potion";
		}
		if (GameManager.inventoryCount == 1) {
			
			objectText = "Key";
		}
		if (GameManager.inventoryCount == 2) {
			objectText = "Katana";
		}
	}

	void Open(){
		if (inRange && Input.GetKeyDown(KeyCode.L) && open == false) {
			open = true;
			GameManager.textUi = objectText;
			anim.SetBool ("Open", true);
			GameManager.inventoryCount += 1;
		}
	}

	void Update () {
		stringText ();
		Open ();
	}
}
