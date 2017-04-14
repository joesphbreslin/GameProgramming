using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform _close;
	public Transform _far;
	public Transform cameraTransform;
	Transform transform;
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	Vector3 newCameraTransform;
	public float speed;
	static public bool cam;
	Quaternion originalRotation;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -0F;
	public float maximumX = 70F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	float rotationX = 0f;


	// Use this for initialization
	void Start () {
		transform = this.gameObject.GetComponent<Transform> ();
		newCameraTransform = cameraTransform.transform.position;
		originalRotation = transform.localRotation;
	}
		
	// Update is called once per frame
	void Update () {
		
		clamp ();
	}
		
	public void Move_towards()
	{
		cameraTransform.transform.position = Vector3.MoveTowards (cameraTransform.transform.position, _close.transform.position, speed * Time.fixedDeltaTime);
	}
	public void Move_away()
	{

		cameraTransform.transform.position = Vector3.MoveTowards (cameraTransform.transform.position, _far.transform.position, speed * Time.fixedDeltaTime);

	}

	void clamp(){

		if (Input.GetKeyDown (KeyCode.G)) {
			rotationY = 0;
			rotationX = 0;
		}

		rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
		rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
	}

	void FixedUpdate ()
	{
		if (cam) {
			Move_towards ();
		}
		if (!cam) {
			Move_away ();
		}
			cameraTransform.transform.LookAt (transform);
		
	}
}	

