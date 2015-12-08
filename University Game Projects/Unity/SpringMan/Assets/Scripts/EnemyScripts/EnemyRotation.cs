using UnityEngine;
using System.Collections;

public class EnemyRotation : MonoBehaviour {
	public bool rotateleft;
	public bool rotateright;
	public bool faceright;
	private Vector3 rotatepointleft;
	private Vector3 rotatepointright;
	// Use this for initialization
	void Start () {
		rotatepointleft = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.z);
		rotatepointright=new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f, this.gameObject.transform.position.z);
		if (!faceright)
						Flip ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (rotateleft&&faceright)
		{
			transform.RotateAround(rotatepointleft, Vector3.forward, 50 * Time.deltaTime);
		}
		if (rotateright && !faceright) 
		{

			transform.RotateAround(rotatepointleft, Vector3.forward, -50 * Time.deltaTime);
		}
		if (rotateright&&faceright) 
		{
			transform.RotateAround(rotatepointright, Vector3.forward, -50 * Time.deltaTime);
		}
		if (rotateleft && !faceright) 
		{

			transform.RotateAround(rotatepointright, Vector3.forward, 50 * Time.deltaTime);
		}
	}
	void Flip()
	{
		//faceright=!faceright;
		Vector3 theScale =transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
