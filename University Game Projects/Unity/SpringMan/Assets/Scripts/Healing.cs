using UnityEngine;
using System.Collections;

public class Healing : MonoBehaviour 
{
	private GameObject player;
    public VitalsScript vitals;
	public Vector2 Direction;
	private float moveSpeed;



	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
        

	}

	void FixedUpdate()
	{
		Direction = player.transform.position-this.gameObject.transform.position;

		InvokeRepeating ("MoveToPlayer", 0.5f,0f);
		//this.gameObject.rigidbody2D.velocity = Direction*20 / Direction.magnitude;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{

			player.GetComponent<HeroController>().Vitals.Heal();

			Destroy (this.gameObject );
		}
	}
	void MoveToPlayer()
	{
		if (this.gameObject == null)
						CancelInvoke ();
		else 
			this.gameObject.rigidbody2D.velocity = Direction*25 / Direction.magnitude;
	}
}
