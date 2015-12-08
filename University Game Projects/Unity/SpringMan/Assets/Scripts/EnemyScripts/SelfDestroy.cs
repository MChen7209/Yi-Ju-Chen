using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	private bool destroyprojectile = false;
	private bool destroyparachute = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if(this.gameObject.tag == "weapon")
		if(destroyprojectile||destroyparachute)
		{
			Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (this.gameObject.tag == "Weapon") 
		{
			if (other.tag == "ProjectileStopSign") 
			{
				destroyprojectile = true;
				//Destroy(this.gameObject);
			}		
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (this.gameObject.tag == "Enemy") 
		{
			if (other.collider.tag == "ground") 
			{
				destroyparachute = true;
			//	Debug.Log("ParachteDestroyed");	
				//Destroy(this.gameObject);
			}		
		}

	}
}
