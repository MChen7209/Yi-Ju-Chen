using UnityEngine;
using System.Collections;

public class magnet : MonoBehaviour 
{
	public float range=30f;
	HeroController playerControl;
	GameObject player;
	Vector2 distance;
	public int presscount;
	bool magneteffect;
	// Use this for initialization
	void Start () 
	{

	
	}
	void Awake()
	{
		range = 30f;
		playerControl = gameObject.GetComponent<HeroController> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		presscount = 0;
		magneteffect = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		distance.x=gameObject.transform.position.x-player.transform.position.x;
		distance.y = gameObject.transform .position.y - player.transform.position.y;
		if (Mathf.Abs (distance.x) < range&&Mathf.Abs (distance.y)<5f &&!HeroController .GameOver )
		{
			if(magneteffect)
			{
				//player.rigidbody2D .velocity=new Vector2 (0,0);
			
				if(player.rigidbody2D.velocity.y<0)
					player.rigidbody2D.velocity=new Vector2(player.rigidbody2D.velocity.x, -10f);
				//else
					//player.rigidbody2D.velocity=new Vector2(player.rigidbody2D.velocity.x,5f);
				player.rigidbody2D .AddForce (new Vector2 (800*distance.x/Mathf.Abs(distance.x), 0));

			}
			/*else 
			{
				presscount=0;
				magneteffect =false;
				Invoke("enablemagnet",2);
			}*/

			if(Input.GetKeyDown (KeyCode.RightArrow )||Input.GetKeyDown (KeyCode.LeftArrow)||Input.GetKeyDown (KeyCode.A)||Input.GetKeyDown (KeyCode.D))
			{
				presscount++;
			}

		}


	}
	void enablemagnet()
	{
		CancelInvoke ();
		magneteffect = true;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player") 
		{
			//magneteffect =false;
		}
	}

}