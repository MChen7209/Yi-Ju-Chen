using UnityEngine;
using System.Collections;

public class EnemyMoveEllipse : MonoBehaviour {
	public bool faceright;
	public bool rotateleft;
	private Vector3 rotatepointleft;
	private Vector3 rotatepointright;
	private float moveSpeed=0.1f;

	// Use this for initialization
	void Start () 
	{
		rotatepointleft = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.z);
		rotatepointright=new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f, this.gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (faceright && rotateleft) 
		{

			if(transform.rotation.z<=0.001)
			{
				transform.position=new Vector2(transform.position.x + moveSpeed, transform.position.y);
				rotatepointleft = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.z);

			}
			if(transform.position.x>10f)
			{

				transform.RotateAround(rotatepointleft, Vector3.forward, 50*Time.deltaTime);
			}

			

			if(transform.rotation.z==1)
			{

				transform.position=new Vector2(transform.position.x-moveSpeed,transform.position.y);
				rotatepointright = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f, this.gameObject.transform.position.z);

			}
			if(transform.position.x<-8f)
			{

				transform.RotateAround (rotatepointright,Vector3.forward,50*Time.deltaTime);
			}
		}
		if (faceright && !rotateleft) 
		{
			if(transform.rotation.z<=0.001)
			{
				transform.position=new Vector2(transform.position.x + moveSpeed, transform.position.y);
				rotatepointright = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f, this.gameObject.transform.position.z);
				
			}
			if(transform.position.x>10f)
			{

				transform.RotateAround(rotatepointright, Vector3.forward, -50*Time.deltaTime);
				if(transform.rotation.z>=0.9999f)
					transform.position=new Vector2(10f,transform.position.y);
			}
			
			
			
			if(transform.rotation.z>=0.9999f)
			{
				
				transform.position=new Vector2(transform.position.x-moveSpeed,transform.position.y);
				rotatepointleft = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.z);
				
			}
			if(transform.position.x<-8f)
			{

				transform.RotateAround (rotatepointleft,Vector3.forward,-50*Time.deltaTime);
				if(transform.rotation.z<=0.001)
					transform.position=new Vector2(-8f,transform.position.y);
			}
		}


	}
	void Flip()
	{
		Vector3 theScale =transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
