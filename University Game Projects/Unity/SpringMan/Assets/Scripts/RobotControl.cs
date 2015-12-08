using UnityEngine;
using System.Collections;

public class RobotControl : MonoBehaviour {
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			//rigidbody2D.AddForce (new Vector2 (0, 650f));
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 15f);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float maxSpeed = 5f;
		float moveForce = 850f;
		float move = Input.GetAxis ("Horizontal");


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (move));
		anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);

		if (move * rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce(Vector2.right * move * moveForce);

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(move > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(move < 0 && facingRight)
			// ... flip the player.
			Flip();
	}

	void Flip(){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
