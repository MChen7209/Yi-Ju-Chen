using UnityEngine;
using System.Collections;

public class TutorialLevelTrap : MonoBehaviour {
	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (enemy == null)
						Destroy (this.gameObject);
	
	}
}
