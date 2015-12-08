using UnityEngine;
using System.Collections;

public class platformChangePosition : MonoBehaviour {
	public GameObject platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider .tag == "Player") 
		{
			platform.transform.position=new Vector2(this.gameObject.transform.position.x,platform.transform.position.y);
		}
	}
}
