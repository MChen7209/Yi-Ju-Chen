using UnityEngine;
using System;
using System.Collections;

public class MoveProjectileFollowing : MonoBehaviour {
	
	float xSpeed;
	float ySpeed;
	float angle;
	private GameObject player;
	private GameObject parent;
	private int maxspeed;
	private float timeLeft;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//parent = transform.parent.gameObject;
		maxspeed = 30;

		CalculateVelocity();
		if (xSpeed != Mathf.Infinity && ySpeed != Mathf.Infinity) 
		{
			if(player.transform.position.y<transform.position.y)
				rigidbody2D.velocity = new Vector2(xSpeed*1.5f, ySpeed*1.5f+player.rigidbody2D .velocity.y);
			else
				rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
		}
			
		AlligntoTarget ();
		timeLeft = 2.5f;
	}
	
	void FixedUpdate () {
		if (timeLeft <= 0) //Switch to time based.
			Destroy(this.gameObject);
		else
		{
			timeLeft -= Time.deltaTime;
		}
	}
	
	void CalculateVelocity()
	{
		angle = CalculateAngle();
		var absAngle = Mathf.Abs (angle);
		//if (parent != null)
		maxspeed = 30;//+ Math.Abs((int) player.rigidbody2D.velocity.x)+ Math.Abs((int) player.rigidbody2D.velocity.y);
		float div = 45 / (maxspeed / 2);
		xSpeed = maxspeed - (float) Math.Round(absAngle / div);
		ySpeed = maxspeed - xSpeed;
		if (player.transform.position.x < transform.position.x)
			xSpeed *= -1;

		if (player.transform.position.y < transform.position.y)
			ySpeed *= -1;
		if (ySpeed < -20)
			ySpeed -= 30;


	}
	
	float CalculateAngle()
	{
		float y = 0;
		float x = 0;
		y = player.transform.position.y - transform.position.y;
		x = player.transform.position.x - transform.position.x;
		if(y < 0)
			return Mathf.Atan (y / x) * Mathf.Rad2Deg * -1;
		else
			return Mathf.Atan (y / x) * Mathf.Rad2Deg;
	}
	
	void AlligntoTarget()
	{
		Vector3 diff = player.transform.position - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
		
	}
	
	
	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.collider.tag == "Wall" || other.collider.tag == "ground"||other.collider.tag=="SuperBarrier") 
		{
			Destroy (this.gameObject);
			
		}
	}
	
	
}

