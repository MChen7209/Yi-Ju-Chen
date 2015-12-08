using UnityEngine;
using System.Collections;

public class FallWithPlayer : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float yVelocity = player.rigidbody2D.velocity.y;
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, yVelocity);
	}
}
