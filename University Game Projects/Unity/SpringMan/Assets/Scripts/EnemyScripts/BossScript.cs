using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
	
	private bool dead;
	public AudioClip enemydead;
	public int energyReleased;
	public int scoreReleased;
	public AudioClip Springkill;
	private Meteor meteor;
	private GameObject playerObj;
	private HeroController player;
	public GameObject heal;
	
	public bool Stomped
	{ //Can be used to build in a stomped animation, versus a powerup kill
		get
		{
			return stomped;
		}
		set
		{
			stomped = true;
			Death();
			dead = true;	
		}
	}
	
	private bool stomped = false;
	
	// Use this for initialization
	void Start()
	{
		meteor = GameObject.FindGameObjectWithTag("Meteor").GetComponent<Meteor>();
		playerObj = GameObject.FindGameObjectWithTag("Player");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
		dead = false;
		rigidbody2D.velocity = new Vector3(0, -10f, 0);
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		//print(screenPos.y);
		if (dead)
		{
			if (Screen.height * 2 < screenPos.y)
				Destroy(transform.gameObject);
			if (transform.position.y - Screen.height * 2 > screenPos.y)
				Destroy(transform.gameObject);
		}
		if (stomped)
		{
			if (Input.GetAxis("Jump") >0)
			{
				
				playerObj.rigidbody2D.velocity=new Vector2(playerObj.rigidbody2D.velocity.x,28f); 
				stomped=false;
			}
			if(player.grounded)
				stomped=false;
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
	}
	
	
	
	public void Kill()
	{
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		body.AddForce(new Vector2(0, 250f));
		Death();
	}
	
	void Death()
	{
		if (!dead && !HeroController.GameOver)
		{
			if (stomped)
			{
				playerObj.rigidbody2D.velocity = new Vector2(playerObj.rigidbody2D.velocity.x, (-playerObj.rigidbody2D.velocity.y<25f)?18f:22f);
				Invoke ("cancealJump",0.1f);
			}
			
			player.Vitals.AbsorbEnergy(energyReleased);
			AudioSource.PlayClipAtPoint(enemydead, transform.position);
			AudioSource.PlayClipAtPoint(Springkill, transform.position);
			
			meteor.SlowDown(.15f, 2f); //Slows down meteor by .1 for 2 seconds
			Collider2D k = GetComponent<Collider2D>();
			k.isTrigger = true;
			Collider2D[] col = GetComponentsInChildren<Collider2D>();
			foreach (Collider2D cc in col)
				cc.isTrigger = true;
			Rigidbody2D body = GetComponent<Rigidbody2D>();
			body.AddForce(new Vector2(0, 200f));
			body.fixedAngle = false;
			body.AddTorque(Random.Range(-100f, 100f));
			
			Score.score += scoreReleased;
			dead = true;
			
			GenerateHealth();
		}
	}
	
	void GenerateHealth()
	{
		if (VitalsScript.CurrentHealth <= VitalsScript.MaxHealth / 2)
		{
			float pro = 0.3f;
			if (Random.value <= pro)
				Instantiate(heal, new Vector2(this.transform.position.x, this.transform.position.y - 1), Quaternion.identity);
		}
	}
	void cancealJump()
	{
		stomped = false;
	}
	
	
}
