using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public int wayPointCount;
	public Transform[] waypoint;
	public Transform player;
	static public bool chase;
	static public bool attack;
	Rigidbody rb;
	Transform transform;
	public float speed, attackWalkSpeed;
	Animator anim;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
		chase = false;
		attack = false;
		speed = 2;
		attackWalkSpeed = 1;
	}

	void Chase(){
		rb.transform.LookAt (player);
		rb.transform.Translate (speed * Time.deltaTime, 0.0f, speed * Time.deltaTime);
		anim.SetBool ("Chase", chase);
		Debug.Log ("Chasing");
	}

	void Attack(){
		rb.transform.LookAt (player);
		rb.transform.Translate (attackWalkSpeed * Time.deltaTime, 0.0f, attackWalkSpeed * Time.deltaTime);
		anim.SetTrigger("Attack");
		Debug.Log ("Attacking");
	}
		
	void Wander(){
		if (wayPointCount > 2) {
			wayPointCount = 0;
		}
		rb.transform.LookAt (waypoint[wayPointCount]);
		rb.transform.Translate (speed * Time.deltaTime, 0.0f, speed * Time.deltaTime);
		Debug.Log ("Wandering");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "WayPoint") {
			Debug.Log ("other");
			wayPointCount = wayPointCount + 1;
	}
	}

	void OnTriggerStay(Collider other)
	{
	}
	void OnTriggerExit(Collider other)
	{
	}


	
	// Update is called once per frame
	void Update ()
	{

		if (chase && !attack) {
			Chase ();
		} else if (chase && attack) {
			Attack ();
		} else if (!chase && !attack) {
			Wander ();
		} else {
			Wander ();
		}


	}
}
