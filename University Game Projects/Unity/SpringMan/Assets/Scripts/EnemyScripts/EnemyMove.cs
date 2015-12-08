using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	private float boardWidth=0;
	Animator enemyanim;



	public  bool faceright;
	private float moveSpeed=0.05f;
	private GameObject touchedBoard;
	float x;



	// Use this for initialization
	void Start () {
		enemyanim = GetComponent<Animator> ();
		if(enemyanim !=null)
			enemyanim.SetFloat("EnemySpeed",moveSpeed);
		//Flip ();
		faceright = false;


	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (boardWidth!=0&&touchedBoard!=null) {
			x=touchedBoard.GetComponent<BoxCollider2D >().center.x*touchedBoard.GetComponent <Transform>().localScale .x ;

			if (transform.position.x >= touchedBoard.GetComponent<Transform> ().position.x +x+ boardWidth / 2 - 1.9) {
				Flip ();
				//faceright = false;
			} else if (transform.position.x <= touchedBoard.GetComponent<Transform> ().position.x+x - boardWidth / 2 + 1.9) {
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
		faceright=!faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "ground") {
			boardWidth = other.collider.bounds.size.x;
			touchedBoard = other.gameObject;
		} 
			
		if (other.collider.tag == "trap"||other.collider.tag=="Wall")
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
