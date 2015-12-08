using UnityEngine;
using System.Collections;

public class UpPlatformGroup : MonoBehaviour {
	private float moveSpeed=0.1f;
	private bool canmove;
	// Use this for initialization
	void Start () {
		canmove = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(canmove)
			transform.position = new Vector2 (transform.position.x , transform.position.y+ moveSpeed);
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ground")
						canmove = true;
			
	}
}
