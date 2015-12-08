using UnityEngine;
using System.Collections;

public class CannonBoss : MonoBehaviour 
{
	//The set speeds
	public float moveSpeed = 1f;
	public float laserRechargeSpeed = 5f;
	public float laserAimTime = 1f;

	//The current speeds
	private float laserRechargeTimer;
	private bool laserOnCooldown;
	private bool laserAiming;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;

	private bool facingRight;
	private Vector3 forwardDirection;

	//Reference to the laser script
	private CannonBossLaser laserReference;

	//Constants
	float displacement = 90 * Mathf.Deg2Rad;

	//Alive?
	private bool living = true;

	// Use this for initialization
	void Start () 
	{
		bossBody = transform.gameObject;
		playerBody = GameObject.FindGameObjectWithTag("Player");
		facingRight = true;
		laserRechargeTimer = 0;
		laserOnCooldown = false;
		forwardDirection = Vector3.right;
		laserReference = transform.FindChild("Laser").GetComponent<CannonBossLaser>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((laserReference.Step < 1.5 || laserReference.Step > 3) && laserReference.PlayerInRange)
		{
			float angle = (Mathf.Atan2 ((playerBody.transform.position.y - transform.position.y), (playerBody.transform.position.x - transform.position.x)) - displacement) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	void FixedUpdate()
	{
		//Foward movement
		RaycastHit2D wallCheck = Physics2D.Raycast(new Vector2(bossBody.transform.position.x, bossBody.transform.position.y), forwardDirection, 3, 1<<12);
		Debug.DrawRay(transform.position, forwardDirection*3);

		if(!wallCheck)
		{
			if (facingRight)
				transform.root.transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
			else if (!facingRight)
				transform.root.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}

		if(wallCheck)
			Flip ();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		if(facingRight)
			forwardDirection = Vector3.right;
		else if(!facingRight)
			forwardDirection = Vector3.left;
	}

	public void setAlive(bool state)
	{
		Destroy(gameObject);
	}
}
