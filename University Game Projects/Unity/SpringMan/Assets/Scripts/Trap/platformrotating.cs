using UnityEngine;
using System.Collections;

public class platformrotating : MonoBehaviour {


	//float rotatingspeed=90;
	//public bool useMotor;
	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<HingeJoint2D>().useMotor = true;
		//Debug.Log ("rotate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
