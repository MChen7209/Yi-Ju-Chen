using UnityEngine;
using System.Collections;

public class HealthBarFlip : MonoBehaviour {
	bool OldFace;
	private EnemyMove RightOrNot;
	// Use this for initialization
	void Start () {
				if (GetComponentInParent <EnemyMove> () != null) {
						RightOrNot = GetComponentInParent<EnemyMove> ();
						OldFace = RightOrNot.faceright;
				}
		}
	// Update is called once per frame
	void Update () {
		if (OldFace != RightOrNot.faceright) 
		{
			Flip();
			OldFace=RightOrNot .faceright ;

		}
	
	}
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
