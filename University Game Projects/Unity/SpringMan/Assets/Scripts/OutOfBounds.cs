using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	HeroController player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == ("Player")) 
		{
			player.Vitals.Dead = true;
		} 
		else {
			Destroy(other.gameObject);
		}
	}
}
