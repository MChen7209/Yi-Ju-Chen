using UnityEngine;
using System.Collections;

public class ActivateFall : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			enemy1.GetComponent<FallWithPlayer> ().enabled = true;
			enemy2.GetComponent<FallWithPlayer> ().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
