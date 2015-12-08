using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	float lastingtime = 0.7f;
	public AudioSource ExplosionSound;
	void Start () {
		ExplosionSound.Play ();
		//Rigidbody2D body = GetComponent<Rigidbody2D>();
		//body.AddForce(new Vector2(0, 20000f));
		//body.AddTorque(Random.Range(-100000f, 100000f));
		Invoke("DestroySelf",lastingtime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
			if(other.gameObject.GetComponent<HeroController >().Vitals.TakeDamage ())
			{
				var shield = GameObject.Find("SpikeShield").gameObject;
				shield.GetComponent<SpikeShieldScript>().Drop();
			}


		}
	}

	void DestroySelf()
	{
		Destroy (this.gameObject);
	}
}
