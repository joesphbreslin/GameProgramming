using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
	public GameObject EnemyStrike;
	public int wayPointCount;
	public Transform[] waypoint;
	public Transform player;
	static public bool chase;
	static public bool attack;
	Rigidbody rb;
	Transform transform;
	public float speed, attackWalkSpeed;
	Animator anim;
	public int health;
	public float pubTime;
	float timer; 
	public Slider enemyHealthSlider;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		anim = this.gameObject.GetComponent<Animator> ();
		chase = false;
		attack = false;
		speed = 2;
		attackWalkSpeed = 1;
		timer = 0.0f;

	}
void death()
	{
		anim.SetBool ("Death", true);
	
		if (timer < pubTime) {
			timer = timer + 0.1f;
		} 
		if (timer > pubTime) {
			Destroy (this.gameObject);
		}
	}

	void Chase(){
		rb.transform.LookAt (player);
		rb.transform.Translate (Vector3.forward * speed * Time.deltaTime);
		anim.SetBool ("Chase", chase);
		Debug.Log ("Chasing");
	}

	void Attack(){
		rb.transform.LookAt (player);
		rb.transform.Translate (Vector3.forward * attackWalkSpeed * Time.deltaTime);
		anim.SetTrigger("Attack");
	}
		
	void Wander(){
		if (wayPointCount > 2) {
			wayPointCount = 0;
		}
		rb.transform.LookAt (waypoint[wayPointCount]);
		//rb.transform.Translate (speed * Time.deltaTime, 0.0f, speed * Time.deltaTime);
		rb.transform.Translate (Vector3.forward * speed * Time.deltaTime);
		Debug.Log ("Wandering");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "WayPoint") {
			wayPointCount = wayPointCount + 1;
		}
	
	
	}

	void OnTriggerStay(Collider other)
	{
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Sword") {
			health = health - 2;
			anim.SetTrigger ("Hurt");
		}
		if (other.tag == "PlayerPunch") {
			health = health - 1;
			anim.SetTrigger ("Hurt");
		}
		
	}


	
	// Update is called once per frame
	void Update ()
	{
		
		if (health < 1) {
			death ();
		} else {
			

			if (chase && !attack) {
				Chase ();
			} else if (chase && attack) {
				EnemyStrike.tag = "EnemyStrike";
				Attack ();
			} else {
				EnemyStrike.tag = "Untagged";
				Wander ();
			}
			Debug.Log (health);
			if (chase || attack ) {
				enemyHealthSlider.value = health;
			}
		}
	}


	}

