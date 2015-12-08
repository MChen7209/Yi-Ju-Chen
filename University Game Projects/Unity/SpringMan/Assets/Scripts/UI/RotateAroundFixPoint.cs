using UnityEngine;
using System.Collections;

public class RotateAroundFixPoint : MonoBehaviour {
	public float x;
	public float y;
	private Vector3 rotatePoint;
	public bool rotateleft;
	// Use this for initialization
	void Start () {
		rotatePoint = new Vector3 (x, y, this.gameObject.transform.position.z);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rotateleft)
			this.gameObject.transform.RotateAround (rotatePoint, Vector3.forward, -30 * Time.deltaTime);
		if(!rotateleft)
			this.gameObject.transform.RotateAround (rotatePoint,Vector3.forward ,30*Time.deltaTime );

	
	}
}
