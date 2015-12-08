using UnityEngine;
using System.Collections;

public class boardsmove : MonoBehaviour {
	float movespeed=1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(Vector3.left*movespeed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(Vector3.right*movespeed*Time.deltaTime);
		}	
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)){
			rigidbody2D.velocity=new Vector3(0,5f,0);
		}
	}
}
