using UnityEngine;
using System.Collections;

public class ShotSpikeAndDestroy : MonoBehaviour {
	private float moveSpeed=0.5f;
	private bool startmove;
	public bool faceright;
	public bool faceleft;
	// Use this for initialization
	void Start () {
		startmove = false;
		if (faceleft)
				Flip ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(startmove&&faceright)
			transform.position = new Vector3 (transform.position.x + moveSpeed, transform.position.y,1f);
		if (startmove && faceleft) 
		{	
			transform.position = new Vector3 (transform.position.x - moveSpeed, transform.position.y,1f);
		}
		Invoke ("CanMove", 0.6f);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Wall")
						Destroy (this.gameObject);
	}
	void CanMove()
	{
		startmove = true;
	}
	void Flip()
	{
		//faceright=!faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}