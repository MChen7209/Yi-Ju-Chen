using UnityEngine;
using System.Collections;

public class PointMoveAndDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(this.gameObject!=null)
			this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+0.07f);

	
	}
	void destroy()
	{
		CancelInvoke ();
		Destroy (this.gameObject);
	}
}
