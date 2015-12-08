using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {
	private bool dead;
	private Meteor meteor;

	// Use this for initialization
	void Start () {
		meteor = GameObject.FindGameObjectWithTag ("Meteor").GetComponent<Meteor>();
		dead = false;
		rigidbody2D.velocity = new Vector3 (0, -10f,0);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		//print(screenPos.y);
		if (dead) {
			if (Screen.height * 2 < screenPos.y)
					Destroy (transform.gameObject);
			if (transform.position.y - Screen.height * 2 > screenPos.y)
					Destroy (transform.gameObject);
		}
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player" && other.transform.position.y > transform.position.y + 2.7f)
		{
			other.collider.rigidbody2D.AddForce(new Vector2(0,200f));
			HeroController hc = other.gameObject.GetComponent<HeroController>();
			hc.Vitals.AbsorbEnergy(1);
			Death();
		}
	}

	public void Kill(Rigidbody2D body)
	{
		body.AddForce(new Vector2(0,250f));
		Death();
	}

	void Death()
	{
		meteor.SlowDown (.15f, 2f); //Slows down meteor by .1 for 2 seconds
		Collider2D c = GetComponent<Collider2D> ();
		c.isTrigger = true;
		Rigidbody2D b = GetComponent<Rigidbody2D> ();
		b.AddForce (new Vector2 (0, 200f));
		b.fixedAngle = false;
		rigidbody2D.AddTorque(Random.Range(-100f,100f));
		Score.score += 1;
		dead = true;
	}
		

}
