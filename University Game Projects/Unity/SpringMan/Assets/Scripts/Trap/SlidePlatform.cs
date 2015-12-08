using UnityEngine;
using System.Collections;

public class SlidePlatform : MonoBehaviour {

	public HeroController player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController > ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player") 
		{
			player.enabled=false;
			other.collider.rigidbody2D.AddForce(new Vector2(0f,-50f));

		}
	}
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.collider.tag == "Player") 
		{
			player.enabled=false;
			other.collider.rigidbody2D .AddForce (new Vector2(0f,-50f));
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			player.enabled=true;
			player.rigidbody2D .velocity =new Vector2(player.rigidbody2D .velocity.x,-1f);

		}
	}
}
