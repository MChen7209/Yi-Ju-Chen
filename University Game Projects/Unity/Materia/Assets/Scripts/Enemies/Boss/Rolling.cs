using UnityEngine;
using System.Collections;

public class Rolling : MonoBehaviour {

	private bool rollingHit;
	public Vector3 collisionPos;
	
	// Use this for initialization
	void Awake(){
		transform.collider2D.enabled = false;
	}
	
	void Start () {
		rollingHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void colliderSwitcher(bool theEnabler){
		transform.collider2D.enabled = theEnabler;
	}
	
	public Vector3 getCollisionPos(){
		return collisionPos;
	}
	
	public bool getRollingHit(){
		return rollingHit;
	}
	
	public void resetRollingHit(){
		rollingHit = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Wizard" || other.gameObject.tag == "Archer" || other.gameObject.tag == "Warrior")
		{
			collisionPos = other.transform.position;
			Vector3 newPos = new Vector3(other.transform.position.x-10, other.transform.position.y ,other.transform.position.z);
			iTween.MoveTo(other.transform.gameObject, newPos, .5f);
			Debug.Log("Hit while rolling");
			rollingHit = true;
		}//end if
		
	}
}
