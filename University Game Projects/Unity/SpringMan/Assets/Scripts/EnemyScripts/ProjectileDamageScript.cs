using UnityEngine;
using System.Collections;

public class ProjectileDamageScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
			other.gameObject.GetComponent<HeroController>().Vitals.TakeDamage();
		}

	}
	/*  
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "descendingground") 
		{
			Destroy(this.gameObject);
		}
	}
	*/

}