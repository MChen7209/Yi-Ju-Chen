using UnityEngine;
using System.Collections;

public class Downwards : MonoBehaviour {

	// Use this for initialization
	public float FallingSpeed = -1f;
	public float velocity;
	public GameObject[] ParachuteEnemySpawner;

	void Start () {
		//this.gameObject.rigidbody2D.velocity = new Vector2 (0, FallingSpeed);
		foreach (GameObject l in ParachuteEnemySpawner)
		{
			//l.SetActive (false);
			l.GetComponent<ParachuteEnemySpawnScript> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//velocity = this.gameObject.rigidbody2D.velocity.y; 	
}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player") {
						//this.gameObject.rigidbody2D.velocity = new Vector2 (0, FallingSpeed);
						Debug.Log ("playertouched");

						//GameObject.Find ("Hero").rigidbody2D.velocity=new Vector2(GameObject.Find ("Hero").rigidbody2D.velocity.x,0f);
				}
		else if((other.collider.tag == "Enemy")) {
			this.gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
				}
						;
	}



	void OnCollisionStay2D(Collision2D other)
	{
		if (other.collider.tag == "Enemy") {

			this.gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
						//this.gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
						Debug.Log ("parachutetouched");
						//GameObject.Find ("Hero").rigidbody2D.velocity=new Vector2(GameObject.Find ("Hero").rigidbody2D.velocity.x,0f);
				} 
		/*else if(other.collider.tag == "Player") {
				this.gameObject.rigidbody2D.velocity = new Vector2 (0, FallingSpeed);
				}*/
	}


	void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.tag == "Enemy")
		{
			this.gameObject.rigidbody2D.velocity =new Vector2(0,FallingSpeed);
			Debug.Log ("move");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			this.gameObject.rigidbody2D.velocity = new Vector2(0, FallingSpeed);
			foreach(GameObject l in ParachuteEnemySpawner)
			{
				l.GetComponent<ParachuteEnemySpawnScript> ().enabled = true;
			}

		}
	}

	//void OnTriggerEnter2D(Collision2D other)
	//{
	//	if (other.collider.tag == "Player")
	//	{
	//		rigidbody2D.velocity = new Vector2(0, FallingSpeed);
	//	}		
	//}
}