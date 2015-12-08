using UnityEngine;
using System.Collections;

public class FreeBarrier : MonoBehaviour {
	public GameObject Barrier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		var meteor = GameObject.Find ("Meteor");

		if (other.tag == "Player") {
			Instantiate (Barrier, new Vector3 (0.5859733f, transform.position.y + 3, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			Destroy(this.gameObject);
		}
	}
}
