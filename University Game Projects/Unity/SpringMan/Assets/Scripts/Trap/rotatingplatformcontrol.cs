using UnityEngine;
using System.Collections;

public class rotatingplatformcontrol : MonoBehaviour {
	//public bool trapOn=true;
	//public GameObject rotatingplatform;
	public GameObject[] rotatingplatform;
	public AudioSource Switch;
	private bool Rotate = false;
	public bool Rotatepub;
	
	// Use this for initialization
	void Start () 
	{
		foreach (GameObject l in rotatingplatform)
		{
			//l.SetActive (false);
			l.GetComponent<platformrotating> ().enabled = false;
		}

		//rotatingplatform.GetComponent<platformrotating> ().enabled = false;
		//Debug.Log ("rotation disabled");
	}
	
	// Update is called once per frame
	void Update () {

		if (!Rotate) {
				} 
		else 
		{	
			foreach(GameObject l in rotatingplatform)
			{
				l.GetComponent<platformrotating> ().enabled = true;
			}

		}
			
	}
	/*void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			trapOn=false;
		}
	}*/
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" &&Rotate ==false) 
		{
			FlipLever(false);
			Rotate = true;
			Rotatepub = Rotate;
		}
	}
	
	void FlipLever(bool state)
	{
		Switch.Play ();
		if (state)
		{
		}
		else
		{
			transform.Find("leverred").GetComponent<SpriteRenderer>().enabled = false;
			transform.Find("levergreen").GetComponent<SpriteRenderer>().enabled = true;
			
		}
	}
	
}
