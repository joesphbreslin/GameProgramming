using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguMovement : MonoBehaviour {
	
	Rigidbody rigidbody;
	public Animator animator;
	public float factor, rotFactor, jumpSpeed, jumpTime,runMult, walkMult;
	float rotSpeed, speed;
	bool grounded, run, crouch;

	//Triggers for Grounded variables

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Ground") {
			grounded = true;
			animator.SetBool ("Jump", false);
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
		//Assign Horizontal Axis to rotation.
		rotSpeed = Input.GetAxisRaw ("Horizontal");
		animator.SetFloat ("Rotation", rotSpeed);
		rigidbody.transform.Rotate (Vector3.up * rotSpeed * rotFactor);
	}

	void Strike(){
		if (Input.GetKeyDown (KeyCode.Return) && grounded) {
			animator.SetTrigger ("Strike_1");
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
