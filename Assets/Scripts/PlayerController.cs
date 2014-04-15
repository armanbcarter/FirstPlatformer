using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int JumpHeight = 6;			
	public bool isGrounded = false;
	public Transform groundedEnd;

	// Update is called once per frame
	void Update () {
		Movement();
		Raycasting ();
	}

	// Show line used for raycasting and use raycasting to determine if player isGrounded
	void Raycasting () {
		Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);
		isGrounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	// Handle player movement
	void Movement() {

		if (Input.GetKey (KeyCode.RightArrow)) {
			if(isGrounded) {
				transform.Translate (Vector2.right * 4f * Time.deltaTime);
			}
			else {
				transform.Translate (Vector2.right * 2f * Time.deltaTime);
			}		
		//	transform.eulerAngles = new Vector3(0,0,-10);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if(isGrounded) {
				transform.Translate (-Vector2.right * 4f * Time.deltaTime);
			}
			else {
				transform.Translate (-Vector2.right * 2f * Time.deltaTime);
			}
		//	transform.eulerAngles = new Vector3(0,0,10);
		}
	
		if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded == true) {
			rigidbody2D.velocity = new Vector2 (0, JumpHeight);
		}

	}
	
}
