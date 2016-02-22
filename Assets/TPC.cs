using UnityEngine;
using System.Collections;
//This is a test
public class TPC : MonoBehaviour {

	private float h, v; // Axis 
	private Rigidbody rb;
	private bool isMoving;
	private Animator anim;

	public float speed;

	private int isRunning;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); // Get Rigidbody
		anim = GetComponent<Animator> (); // Get the Animator
		isRunning = Animator.StringToHash("Running");
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		isMoving = h != 0 || v != 0;
	}

	void FixedUpdate () {

		MovementManagement (h, v); // Handles the direction its facing and moving

	}

	public void MovementManagement(float horizontal, float vertical){
	
			
		Vector3 newDirection =  new Vector3(h,0,v);

		if (isMoving) { // Checking if its moving

			anim.SetBool (isRunning, true); // if moving enable run animation

			Quaternion targetRotation = Quaternion.LookRotation (newDirection);
			Quaternion newRotation = Quaternion.Slerp (rb.rotation, targetRotation, 2 * Time.deltaTime);

			GetComponent<Rigidbody> ().MoveRotation (newRotation);

			rb.MovePosition (transform.position + transform.forward * speed * Time.deltaTime);

		} else {
			anim.SetBool (isRunning, false);
		}



			
		}

	}


