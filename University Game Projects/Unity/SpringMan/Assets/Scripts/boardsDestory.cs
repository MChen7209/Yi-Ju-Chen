using UnityEngine;
using System.Collections;

public class boardsDestory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Destroy (gameObject,10);

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		//print(screenPos.y);
		if (Screen.height*2 < screenPos.y)
			Destroy(transform.gameObject);

	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name=="tryboard"||other.name=="testenemy(Clone)") {
		}
		else{
		Destroy (other.gameObject);
		}
	}
}
