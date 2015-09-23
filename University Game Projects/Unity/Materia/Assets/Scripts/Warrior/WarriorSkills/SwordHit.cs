using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

	public float damage;
	Vector3 direction;

	public void OnTriggerEnter2D(Collider2D target){
		
		if (target.gameObject.tag == "Enemy")
		{
			target.transform.root.GetComponentInChildren<PlayerHealth> ().TakeDamage (damage);
		}//end if
		if (target.gameObject.tag == "Arrow")
		{
			direction = transform.position-target.transform.position;
			target.gameObject.transform.rigidbody2D.velocity = transform.TransformDirection (Vector3.left*50);
		}//end if
		
	}
	
	public void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.tag == "Arrow")
		{
			target.gameObject.transform.rigidbody2D.velocity = transform.TransformDirection (Vector3.left*50);
		}//end if
	}

}
