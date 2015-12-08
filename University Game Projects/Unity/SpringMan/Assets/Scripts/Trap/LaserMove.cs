using UnityEngine;
using System.Collections;

public class LaserMove : MonoBehaviour {
	private float moveSpeed=0.1f;
	private float moveDistance=12f;
	private float UpBound;
	private float DownBound;
	private bool moveUp;
	// Use this for initialization
	void Start () {
		moveUp = false;
		UpBound = transform.position.y;
		DownBound = transform.position.y - moveDistance ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!moveUp&&!HeroController.GameOver)
						transform.position = new Vector2 (transform.position.x, transform.position.y - moveSpeed);
				
		if(moveUp&&!HeroController.GameOver)
			transform.position = new Vector2 (transform.position.x , transform.position.y+ moveSpeed);
		if (transform.position.y > UpBound)
						moveUp = false;
		if(transform.position.y<DownBound)
			moveUp=true;


	}
}
