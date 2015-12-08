using UnityEngine;
using System.Collections;

public class CBossBouncy : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
			other.gameObject.rigidbody2D.velocity = new Vector2(other.gameObject.rigidbody2D.velocity.x, (-other.gameObject.rigidbody2D.velocity.y<25f)?18f:22f);
	}
}
