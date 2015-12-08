using UnityEngine;
using System.Collections;

public class ProjectileMove : MonoBehaviour {
	private float boardWidth=0;
	Animator enemyanim;
	
	
	
	private bool faceright;
	private float moveSpeed=0.05f;
	private GameObject touchedBoard;
	float x;
	
	
	
	// Use this for initialization
	void Start () {
		enemyanim = GetComponent<Animator> ();
		//Flip ();
		faceright = false;		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (boardWidth!=0&&touchedBoard!=null) {
			x=touchedBoard.GetComponent<BoxCollider2D >().center.x*touchedBoard.GetComponent <Transform>().localScale .x ;

			//enemyanim.SetFloat("EnemySpeed",moveSpeed);
			if (transform.position.x >= touchedBoard.GetComponent<Transform> ().position.x +x+ boardWidth / 2 - 1.9) {
				Flip ();
				//faceright = false;
			} else if (transform.position.x <= touchedBoard.GetComponent<Transform> ().position.x +x- boardWidth / 2 + 1.9) {
				Flip ();
				//faceright = true;
			}
			if (faceright)
			{	
				
				transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
			}
			else if (!faceright)
			{
				
				transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
			}
		} else {
			//transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}
		
	}
	
	void Flip()
	{
		Transform body = transform.Find ("Body");
		faceright=!faceright;
		Vector3 theScale = body.localScale;
		theScale.x *= -1;
		body.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "ground") {
			boardWidth = other.collider.bounds.size.x;
			touchedBoard = other.gameObject;
		} 
		
		if (other.collider.tag == "trap")
		{
			//faceright =!faceright ;
			Flip ();
			if(faceright)
				transform.position=new Vector2(transform.position.x+0.5f,transform.position.y);
			else
				transform.position=new Vector2(transform.position.x-0.5f,transform.position.y);
			
		}
		
		
		
		
	}
	
	
	
}
