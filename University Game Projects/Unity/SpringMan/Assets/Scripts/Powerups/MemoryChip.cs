using UnityEngine;
using System.Collections;

public class MemoryChip : MonoBehaviour {

	public AudioSource Chips;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {

			Chips.Play();
			Destroy(this.gameObject);
		}
	}
}