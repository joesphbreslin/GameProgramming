using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguMovement : MonoBehaviour {
	public GameObject hitBox, sword; 
	Rigidbody rigidbody;
	public Animator animator;
	public float factor, rotFactor, jumpSpeed, jumpTime,runMult, walkMult, timer, strikeTime;
	float rotSpeed, speed;
	bool grounded, run, crouch;
	public static bool strikeCool, swordEquip;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Ground") {
			grounded = true;
			animator.SetBool ("Jump", false);
		}
		if (col.tag == "EnemyStrike") {
			GameManager.health = GameManager.health - 5;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Ground") {
			grounded = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Ground") {
			grounded = false;
		}
	}
		
	void Start () {
		rigidbody = this.gameObject.GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
		
	void Jump()
	{
		//Using grounded bool to know when player is able to jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			rigidbody.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);	
			animator.SetBool ("Jump", true);
		}
	}

	void Crouch()
	{
		if (Input.GetKey (KeyCode.Z) && grounded) {
			animator.SetBool ("Crouch", true);
		} else {
			animator.SetBool ("Crouch", false);
		}
	}
		
	void RunWalk()
	{
		// Assign speed variable to vertical Axis and animator float speed
		speed = Input.GetAxis ("Vertical");
		speed = speed * walkMult;
		animator.SetFloat ("Speed", speed);

		//Run Transition with LShift
		if(Input.GetKey (KeyCode.LeftShift) && grounded ){
			run = true;
			Debug.Log ("Run");
		} else { 
			run = false;
		}
		//Assign run Bool to animator bool Run
		animator.SetBool ("Run", run);

		//Transform based off speed and run variables
		if (run == false) {
			rigidbody.AddForce (transform.forward * speed * factor);
		} else if (run == true){
			rigidbody.AddForce (transform.forward * speed * factor * runMult);
		}
		
	}

	void Rotate(){
		rotSpeed = Input.GetAxisRaw ("Horizontal");
		animator.SetFloat ("Rotation", rotSpeed);
		rigidbody.transform.Rotate (Vector3.up * rotSpeed * rotFactor);
	}

	void Strike(){
		if (Input.GetKeyDown (KeyCode.Return) && grounded) {
			animator.SetTrigger ("Strike_1");
			strikeCool = true;
		}

		if (strikeCool) {
			if (timer < strikeTime) {
				timer = timer + 0.01f;
				if (GameManager.sword == true) {
					hitBox.tag = "Untagged";
					sword.tag = "Sword";
				} else {
					hitBox.tag = "PlayerPunch";
				}
			} else if (timer > strikeTime) {
				strikeCool = false;
				hitBox.tag = "Untagged";
				sword.tag = "Untagged";

			}

		} else {
			timer = 0.0f;
		}
	}
	


	void FixedUpdate () {

		Crouch ();
		Strike ();
		Rotate ();
		RunWalk ();
		Jump();
	}
}
