using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {


	//public GameObject ExplosionEffectTiming[] = new GameObject[4];
	//public GameObject ExplosionEffectTiming1;
	//public GameObject ExplosionEffectTiming2;
	public GameObject ExplosionEffect;
	private Animator anmi;
	public float delay;

	private float angle;
	private bool nottiming ;
	// Use this for initialization
	void Start () {
		nottiming = true;
		anmi = this.gameObject.GetComponent<Animator> ();
		if (anmi != null)
						anmi.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!nottiming&&anmi!=null)
						anmi.enabled = true;
	}


	/*void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player" || other.collider.tag == "trap") 
		{
			Invoke ("Explosion",delay);
			//Debug.Log("Explosion");

		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.collider.tag == "Player" || other.collider.tag == "trap") 
		{
			Invoke ("Explosion",delay);
			//Debug.Log("Explosion");
			
		}
	}*/


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "trap") 
		{
			nottiming=false;
			Invoke ("Explosion",delay);
			//Debug.Log("Explosion");
			
		}
	}



	void Explosion()
	{
		CancelInvoke ();

			Instantiate (ExplosionEffect, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
		if(!nottiming) 
		{
			//Instantiate (ExplosionEffectTiming1, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			//angle = 170;
			//SetAnglewithSpeed(angle);
			//Rigidbody2D body1 = ExplosionEffectTiming1.GetComponent<Rigidbody2D>();
			//body1.AddForce(new Vector2(-10f, 0f));
			//body1.AddTorque(Random.Range(-100000f, 0f));
			//body1.gravityScale = 5;


			//Instantiate (ExplosionEffectTiming2, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			//angle = 120;
			//SetAnglewithSpeed(angle);
			//Rigidbody2D body2= ExplosionEffectTiming2.GetComponent<Rigidbody2D>();
			//body2.AddForce(new Vector2(100f, 100f));
			//body2.AddTorque(Random.Range(-100000f, 100000f));
/*
			Instantiate (ExplosionEffectTiming, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			angle = 60;
			SetAnglewithSpeed(angle);

			Instantiate (ExplosionEffectTiming, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			angle = 10;
			SetAnglewithSpeed(angle);*/

		}

		Destroy(this.gameObject);
	}

	/*void SetAnglewithSpeed(float angle)
	{
		Rigidbody2D body = ExplosionEffectTiming.GetComponent<Rigidbody2D>();
		body.AddForce(new Vector2(100f*angle, 100f*angle));
		body.AddTorque(Random.Range(-100000f, 0f));
	}*/


}
