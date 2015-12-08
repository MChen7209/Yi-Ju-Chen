using UnityEngine;
using System.Collections;

public class FallingdownSpeed : MonoBehaviour {

	public  float fallingdownspeed;
	Vector3 lastPosition=Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		fallingdownspeed = (transform.position.y - lastPosition.y);
		lastPosition = transform.position;
	}
}
