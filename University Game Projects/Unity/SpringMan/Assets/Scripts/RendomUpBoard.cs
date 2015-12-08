using UnityEngine;
using System.Collections;

public class RendomUpBoard : MonoBehaviour {
	
	//float BoardUpSpeed=2.0f;
	public Rigidbody2D Board;
	const float MAXHEIGHT = 5.5f, MINHEIGHT=-5.5f;
	float currentHeight;
	float spawnTime=2f;
	float spawnDelay=2f;

	//private Rigidbody2D kk;
	
	
	// Use this for initialization
	void Start () 
	{

		//if(GameObject.FindGameObjectWithTag ("Player").velocity!=new Vector2(0,0f))
		   InvokeRepeating("boardAppare", spawnDelay, spawnTime);
		
	}
	void boardAppare()
	{
		float x = Random.Range(-2.73f, 2.73f);
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y < 0 ) 
		{
			if(Mathf.Abs (currentHeight-transform.position.y)>3f)
			   {	Rigidbody2D clone;
						clone = Instantiate (Board, new Vector3 (x, transform.position.y, 10), Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
						//clone.AddForce (new Vector2 (0, 1f));
						currentHeight = clone.transform.position.y;
						clone.velocity = new Vector2 (0, 0f);
			    }
		}
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y > -5 && GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y < 0) 
		{
			CancelInvoke() ;
			spawnDelay=1f;
			spawnTime=1f;
			InvokeRepeating ("boardAppare",spawnDelay,spawnTime);
		}
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y < -5 && GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y >-10) 
		{
			CancelInvoke() ;
			spawnDelay=0.5f;
			spawnTime=0.5f;
			InvokeRepeating ("boardAppare",spawnDelay,spawnTime);
		}

	}


	
	// Update is called once per frame
	

}
