using UnityEngine;
using System.Collections;

public class SubMarineBossHealthBar: MonoBehaviour {
	bool OldFace;
	private SubmarineBossCharge  RightOrNot;
	// Use this for initialization
	void Start () {
		if (GetComponentInParent <SubmarineBossCharge > () != null) {
			RightOrNot = GetComponentInParent<SubmarineBossCharge > ();
			OldFace = RightOrNot.FaceRight;
		}
	}
	// Update is called once per frame
	void Update () {
		if (OldFace !=  RightOrNot.FaceRight) 
		{
			Flip();
			OldFace= RightOrNot.FaceRight ;
			
		}
		
	}
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
	}
}
