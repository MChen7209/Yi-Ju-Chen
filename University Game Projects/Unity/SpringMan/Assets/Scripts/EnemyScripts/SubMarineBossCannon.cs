using UnityEngine;
using System.Collections;

public class SubMarineBossCannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!this.gameObject.GetComponentInParent <SubMarineBoss > ().ShotPhase)
						this.gameObject.SetActive (false);
				
	
	}
}
