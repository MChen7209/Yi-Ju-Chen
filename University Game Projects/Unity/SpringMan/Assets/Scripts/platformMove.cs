using UnityEngine;
using System.Collections;

public class platformMove : MonoBehaviour {
	float moveSpeed=0.05f;
	float distance=4f;
	bool faceright=true;
	float position;
	// Use this for initialization
	void Start () {
		position = transform.position.x;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!HeroController.GameOver)
		{
			if (transform.position.x >= position+distance) {

				faceright = false;
			} else if (transform.position.x <=position-distance) {

				faceright = true;
			}
			if (faceright)
			{	
				
				transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
			}
			else if (!faceright)
			{
				
				transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
			}
		}
	
	}
}