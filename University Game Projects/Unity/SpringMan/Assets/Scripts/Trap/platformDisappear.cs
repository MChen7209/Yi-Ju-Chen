using UnityEngine;
using System.Collections;

public class platformDisappear : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start()
	{
		anim = GetComponent<Animator> ();
		if (anim != null)
						anim.SetBool ("TOUCHED", false);
	}
	// Update is called once per frame

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.collider.tag == "Player"||other.collider.tag=="SpikeShield") 
		{
			anim.SetBool ("TOUCHED",true);
			Invoke ("Disappear",0.5f);
		}
	}

	void Disappear()
	{

		CancelInvoke ();
		this.gameObject.SetActive (false);
	}
}
