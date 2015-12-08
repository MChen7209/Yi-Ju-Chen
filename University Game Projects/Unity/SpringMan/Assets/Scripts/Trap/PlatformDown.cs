using UnityEngine;
using System.Collections;

public class PlatformDown : MonoBehaviour {

	//private GameObject player;
	public  bool touchedorNot;
	public GameObject player;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
		touchedorNot = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//vel=this.gameObject.rigidbody2D.velocity.y;
		if (touchedorNot&&player!=null) 
		{
			//player.GetComponent <HeroController >().SetFall (false);

			//this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y-0.1f);
			//player.transform.position=new Vector2(player.transform.position.x,this.gameObject.transform.position.y+3.3f);
			if (Input.GetAxis("Jump") != 1)
				player.rigidbody2D.velocity=new Vector2(player.rigidbody2D.velocity.x,-5f);
		}
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			//player.rigidbody2D.velocity=new Vector2(player.rigidbody2D.velocity.x, 0f);
			touchedorNot=true;
			//other.gameObject.transform.position=new Vector2(other.gameObject.transform.position.x, this.gameObject.transform.position.y+3.36f);
			this.gameObject.rigidbody2D .velocity=new Vector2(0,-3f);

			//this.gameObject.rigidbody2D .isKinematic =false;

			//Invoke ("donotKinematic",1.5f);
		}
		/*
		if (other.collider.tag == "ground") 
		{
				Debug.Log ("hitground");
				this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
				this.gameObject.rigidbody2D.mass = 1000000;
				this.gameObject.rigidbody2D.velocity = new Vector2 (0, 0);	
				this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}*/

	}
	void OnCollisionStay2D(Collision2D other)
	{
		if(other.collider.tag=="Player")
			touchedorNot = true;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.collider.tag=="Player")
			touchedorNot = false;
	}
//<<<<<<< HEAD
//	void OnCollisionStay2D(Collision2D other)
//	{
//		if(other.collider.tag=="Player")
//			touchedorNot = true;
//	}

//	void OnCollisionExit2D(Collision2D other)
//	{
//				if (other.collider.tag == "Player")
//						touchedorNot = false;
//		}
//=======

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ElevatorStopSign") 
		{
			Debug.Log ("stop");
			this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			this.gameObject.rigidbody2D.mass=1000000;
			this.gameObject.rigidbody2D.velocity=new Vector2(0,0);	
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;



		}
//>>>>>>> origin/wujk
	}


}
