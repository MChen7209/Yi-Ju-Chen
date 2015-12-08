using UnityEngine;
using System.Collections;

public class WindHole : MonoBehaviour {
	private VitalsScript player;
	private float lastHitTime;
	private ParticleSystem  particle;
	private HeroController playerController;
	// Use this for initialization
	void Start () {
		player = new VitalsScript ();
		playerController = gameObject.GetComponent<HeroController> ();
		particle =GameObject.FindGameObjectWithTag ("Player"). GetComponent<ParticleSystem > ();
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{

			other.rigidbody2D .AddForce (new Vector2(0,1200f));
			/*if (Time.time > lastHitTime + 1.25)
			{
				player.TakeDamage (30);
				particle .Emit (15);
				lastHitTime = Time.time;
			}
			if (player.Dead) 
			{
				particle.Emit (10);
				HeroController .GameOver=true;
			}*/
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{

			/*int upSpeed = 10;
			other.transform.Translate (transform.up*Time.deltaTime*upSpeed );*/
			other.rigidbody2D .AddForce (new Vector2(0,40f));

		/*	if (Time.time > lastHitTime + 1.25)
			{
				player.TakeDamage (30);
				particle .Emit (15);
				lastHitTime = Time.time;
			}
			if (player.Dead) 
			{
				particle.Emit (10);
				HeroController .GameOver=true;
			}*/
		}


	}
	void Update () {
	
	}
}
