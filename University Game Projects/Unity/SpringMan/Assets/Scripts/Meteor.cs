using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	/* 
	 * The Meteor class handles all meteor interactions. The meteor is the object in the sky that the player
	 * must run from. It kills the player immediately on touch, but can be slowed down by killing enemies
	 * or stopped for a limited time when the player summons barriers.
	 */

	public static float fallSpeed = .25f;
	public static float originalFallSpeed = Meteor.fallSpeed;
	private float slowTime = 0f;
	private bool slowed = false;
	private bool started = false;
	private GameObject barrier;
	private float distance;
	public float count=0;
	public static float  barrierTime=2f;


	// Use this for initialization
	void Start () {
		started = false;
		slowed = false;

		Meteor.fallSpeed = Meteor.originalFallSpeed;
		Invoke ("StartMoving", 3f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (started)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
		}
		if (slowed)
		{
			unSlow();
		}

	}
		
	void StartMoving()
	{
		this.started = true;
	}

	/*
	 * This method kills the player upon touch or stops if it hits a barrier.
	 */
	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") {
			Invoke ("Restart", 2.5f);
			HeroController.GameOver = true;
			//started = false;
		}
		else if (other.tag == "Barrier"&&started)
		{
			count=count+barrierTime;
			started = false;

			barrier=other.gameObject;

			Invoke ("HitBarrier",count);
		}
		else if(other.tag == "SuperBarrier"&&started)
		{
			count=count+barrierTime;
			started = false;
			barrier=other.gameObject;
			Invoke("HitBarrier",180f);
			//Destroy (other.gameObject);
		}
		else if(other.tag == "PowerfulBarrier"&&started)
		{
			count=count+barrierTime;;
			started = false;
			barrier=other.gameObject;
			Invoke("HitBarrier",20f);
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{

		
		if (other.tag == "Player") {
			Invoke ("Restart", 2.5f);
			HeroController.GameOver = true;
			//started = false;
		}
		else if (other.tag == "Barrier"&&started)
		{
			count=count+barrierTime;
			started = false;
			
			barrier=other.gameObject;
			
			Invoke ("HitBarrier",count);
		}
		else if(other.tag == "SuperBarrier"&&started)
		{
			count=count+barrierTime;
			started = false;
			barrier=other.gameObject;
			Invoke("HitBarrier",180f);
			//Destroy (other.gameObject);
		}
		else if(other.tag == "PowerfulBarrier"&&started)
		{
			count=count+barrierTime;
			started = false;
			barrier=other.gameObject;
			Invoke("HitBarrier",20f);
		}
	}

	 //This method restarts the current Level.
	public void Restart()
	{
		LevelChangeScript.RestartLevel();
	}

	/*
	 * If the slow time is up, the meteor is reset back to original speed.
	 * Otherwise this method keeps track of how much time has passed.
	 */
	void unSlow()
	{
		if (slowTime <= 0) {
			Meteor.fallSpeed = Meteor.originalFallSpeed;
			slowed = false;
		} else {
			slowTime -= Time.deltaTime;
		}
	}

	/*
	 * Slows down the meteor and/or adds time the variable keeping track of how long the meteor
	 * is slowed.
	 */
	public void SlowDown(float howMuch, float howLong)
	{
		Meteor.fallSpeed = Meteor.originalFallSpeed - howMuch;
		slowTime += howLong;
		slowed = true;
	}


	//Once this method is called, the barrier object is destroyed and the meteor begins to move again. 
	void HitBarrier() 
	{
		StartMoving();
		if (barrier != null)
		{
			Destroy(barrier);
			count=0;
			barrier = null;
		}
	}

	float CalculateDistance()
	{
		return 0f;
	}
}