using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour {

	private bool hasHit;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool getHasHit(){
		return hasHit;
	}
	
	public void resetHit(){
		hasHit = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Wizard" || other.gameObject.tag == "Archer" || other.gameObject.tag == "Warrior")
		{
			Debug.Log("Should be pushing");
			//other.gameObject.rigidbody2D.AddForce(Vector3.left*7000);
			Vector3 newPos = new Vector3(other.transform.position.x-5, other.transform.position.y ,other.transform.position.z);
			iTween.MoveTo(other.transform.gameObject, newPos, .5f);
			hasHit = true;
		}//end if
	}
}
