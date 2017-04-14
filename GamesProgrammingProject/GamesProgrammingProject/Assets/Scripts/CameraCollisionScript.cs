using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Wall" || col.tag == "Ground") {
			CameraScript.cam = true;
		} 
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Wall" || col.tag == "Ground") {
			CameraScript.cam = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Wall" || col.tag == "Ground") {
			CameraScript.cam = false;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
