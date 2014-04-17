using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	float jumpForce = 300f;			
	float maxSpeed = 5f;
	bool facingRight = true;
	public bool isGrounded = false;
	public Transform groundedEnd;

	// Handle most physics in the game
	void FixedUpdate ()
	{
		LeftRightMovement();
		Raycasting ();
	}

	// Handle player input
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded == true) 
		{
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}
	}

	// Show line used for raycasting and use raycasting to determine if player isGrounded
	void Raycasting () 
	{
		Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);
		isGrounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	// Handle left/right player movement
	void LeftRightMovement() 
	{
		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 &&!facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	void Flip () 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
