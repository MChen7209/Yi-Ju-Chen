using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{	
	public float health = 100f;					// The player's health.
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player
	
	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
//	private PlayerController playerController;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player

	private bool immunity;

	private bool alive;
	
	
	void Awake ()
	{
		// Setting up references.
//		playerController = GetComponent<PlayerController>();
//		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthBar = gameObject.GetComponentInChildren<SpriteRenderer> ();
		anim = GetComponent<Animator>();
		
		// Getting the intial scale of the healthbar (whilst the player has full health).
		healthScale = healthBar.transform.localScale;
		alive = true;
		immunity = false;
	}
	
	
	void OnCollisionEnter2D (Collision2D col)
	{
		// If the colliding gameobject is an Enemy...
		//		if(col.gameObject.tag == "Enemy")
		//		{
		// ... and if the time exceeds the time of the last hit plus the time between hits...
		if (Time.time > lastHitTime + repeatDamagePeriod) 
		{
			// ... and if the player still has health...
			if(health > 0f)
			{
				// ... take damage and reset the lastHitTime.
				TakeDamage(col.transform); 
				lastHitTime = Time.time; 
			}
			// If the player doesn't have health, do some stuff, let him fall into the river to reload the level.
			else
			{
				// Find all of the colliders on the gameobject and set them all to be triggers.
				Collider2D[] cols = GetComponents<Collider2D>();
				foreach(Collider2D c in cols)
				{
					c.isTrigger = true;
				}
				
				// Move all sprite parts of the player to the front
				SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
				foreach(SpriteRenderer s in spr)
				{
					s.sortingLayerName = "UI";
				}
				
				// ... disable user Player Control script
				GetComponent<PlayerControl>().enabled = false;
				
				// ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
				//GetComponentInChildren<Weapon>().enabled = false;
				
				// ... Trigger the 'Die' animation state
				anim.SetTrigger("Die");
			}
		}
		//		}
	}

	void TakeDamage (Transform enemy)
	{
		// Make sure the player can't jump.
		//playerController.jump = false;
		if (immunity)
			return ;
		
		// Create a vector that's from the enemy to the player with an upwards boost.
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;
		
		// Add a force to the player in the direction of the vector and multiply by the hurtForce.
		rigidbody2D.AddForce(hurtVector * hurtForce);
		
		// Reduce the player's health by 10.
		health -= damageAmount;
		
		// Update what the health bar looks like.
		UpdateHealthBar();
	}

	public void TakeDamage(float damage, Transform enemyMedium)
	{
		Vector3 hurtVector = transform.position - enemyMedium.position + Vector3.up * 5f;
		rigidbody2D.AddForce (hurtVector * hurtForce);
		if(immunity)
			return;
		health -= damage;
		UpdateHealthBar ();
	}

	public void TakeDamage (float damage)
	{
		health -= damage;
		if (health < 0)
			health = 0;
		Debug.Log ("Health: " + health);
		UpdateHealthBar ();
	}

	public void setImmunity()
	{
		immunity = !immunity;
	}
	
	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
		
		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
	}

	void Update()
	{
		if (health <= 0)
		{
			if(transform.parent.CompareTag("Wizard") || transform.parent.CompareTag("Warrior") || transform.parent.CompareTag ("Archer"))
			{
				alive=false;
				StartCoroutine("ReloadGame");
				//Destroy (transform.parent.gameObject);
			}
			else
				Destroy (transform.parent.gameObject);
		}
	}

	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(0);
		// ... and then reload the level.
		Application.LoadLevel(Application.loadedLevel);
		//Also reload health game object.
	}

	public bool isLiving()
	{
		return alive;
	}
}