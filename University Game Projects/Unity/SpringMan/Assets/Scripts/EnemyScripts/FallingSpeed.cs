using UnityEngine;
using System.Collections;

public class FallingSpeed : MonoBehaviour {

	// Use this for initialization

	// float FallSpeed = -3f;
	public float FallSpeed;
	private Animator anim;
	public float velocity;
	private bool stomped;
	void Start () {
		this.gameObject.rigidbody2D.velocity =new Vector2(0, FallSpeed);

//		Debug.Log ("fallspeed");
		anim = GetComponent<Animator>();
		anim.enabled = true; 

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		velocity =  this.gameObject.rigidbody2D.velocity.y;

	/*			if (this.rigidbody2D.velocity.y > -10f)
						;
				else
						this.rigidbody2D.gravityScale = 0;
						

*/
	}
	/*
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "descendingground") {//this.g 	ameObject.rigidbody2D.velocity =new Vector2(0, FallSpeed) ;
						this.rigidbody2D.gravityScale = 1f;
						//anim.Play(IdleAnim);
						anim.enabled = false;
						//Debug.Log ("gravity");
				}
	}
	*/
}
