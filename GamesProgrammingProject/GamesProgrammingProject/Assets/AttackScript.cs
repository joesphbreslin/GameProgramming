using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {

			EnemyBehaviour.attack = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {

			EnemyBehaviour.attack = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {

			EnemyBehaviour.attack = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
