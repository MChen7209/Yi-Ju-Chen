using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	[SerializeField]
	private GameObject frozenThrone;
	
	[HideInInspector]
	private GameObject enemy;
	public GameObject leftHand;
	
	public float movementSpeed;
	
	private bool facingRight;
	private bool isFrozen;
	private bool moving;
	private bool isMoving;
	private bool rolling;
	
	//rolling spell stuff
	private bool isRolling;
	public GameObject rollingObject;
	private int delay;
	private float timeDelay;
	
	//gnome firing stuff
	private GameObject[] playerCharacters;
	public GameObject gnomeProjectile;
	private GameObject playerPosition;
	private bool isGnomeFiring;
	private int gnomeCount;
	private bool gnomeFireOnCooldown;
	private float gnomeFireWait;
	public int gnomeFireCooldown;
	
	private Animator anim;
	private bool isMovingToOriginalPos;
	private Vector3 newPosition;
	public GameObject originalBossPos;
	public GameObject rollingPos;
	
	// Use this for initialization
	void Start () 
	{
		moving = false;
		isMovingToOriginalPos = false;
		rolling = true;
		anim = transform.root.gameObject.GetComponent<Animator> ();
		facingRight = true;
		enemy = transform.parent.gameObject;
		isFrozen = false;
		isGnomeFiring = false;
		isRolling = false;
		delay = 2;
		playerCharacters = new GameObject[3];
		
		//		frozenThrone = transform.parent.FindChild ("FrozenThrone").gameObject;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerCharacters [0] = GameObject.FindGameObjectWithTag ("Wizard");
		playerCharacters [1] = GameObject.FindGameObjectWithTag ("Archer");
		playerCharacters [2] = GameObject.FindGameObjectWithTag ("Warrior");
		
		if (rollingObject.GetComponent<Rolling> ().getRollingHit ()){
			isRolling = false;
			bounceToOriginalPos();
		}
		
		if (leftHand.GetComponent<KnockBack> ().getHasHit ()){
			//Debug.Log("moving");
			isMovingToOriginalPos = true;
			moveBackToOriginalPosition();
		}//end if
		
		if (isGnomeFiring){
			fireGnome();
		}//end if
		
		if (isRolling){
			rollingGnome();
		}//end if
		
	}
	
	public void OnTriggerStay2D(Collider2D other)
	{
		if (isFrozen || isMovingToOriginalPos || isGnomeFiring || isRolling)
			return;
		if (other.gameObject.tag == "Wizard" || other.gameObject.tag == "Archer" || other.gameObject.tag == "Warrior")
		{
			anim.SetBool("Idle", false);
			Transform target = other.gameObject.transform;
			float distance = Vector2.Distance (other.gameObject.transform.position, transform.position);
			//Debug.Log("THIS IS THE DISTANCE: " + distance);
			if (distance < 15)
			{
				Debug.Log("Should be attacking");
				anim.SetBool ("Walking", false);
				anim.SetBool ("Attacking", true);
				isMoving = false;
			} else if (distance >= 20)
			{
				isMoving = true;
				anim.SetBool ("Attacking", false);
				anim.SetBool ("Walking", true);
			}
			if ((target.transform.position.x > enemy.transform.position.x) && !facingRight) 
				FlipDirection ();
			else if ((target.transform.position.x < enemy.transform.position.x) && facingRight) 
				FlipDirection ();
			
			if (facingRight && isMoving)
				enemy.transform.Translate (Vector3.right * Time.deltaTime * movementSpeed);
			else if (!facingRight && isMoving)
				enemy.transform.Translate (Vector3.left * Time.deltaTime * movementSpeed);
		} 
		else {
			//anim.SetBool("Idle", true);
			anim.SetBool("Walking", false);
		}//end if
	}
	
	private void moveBackToOriginalPosition(){
		anim.SetBool("Attacking", false);
		anim.SetBool("Walking", true);
		//move the character until it reaches original position
		if(!facingRight)
			FlipDirection();
		enemy.transform.Translate (Vector3.right * Time.deltaTime * movementSpeed);
		float distance = Vector3.Distance (enemy.transform.position, originalBossPos.transform.position);
		Debug.Log("THIS IS THE DISTANCE: " + distance);
		if (distance <= 13){
			FlipDirection();
			isMovingToOriginalPos = false;
			leftHand.GetComponent<KnockBack> ().resetHit ();
			isGnomeFiring = true;
		}//end if
		
	}
	
	private void fireGnome(){
		anim.SetBool ("Casting", true);
		anim.SetBool("Walking", false);
		if (gnomeCount == 100){
			isGnomeFiring = false;
			gnomeCount = 0;
			isRolling = true;
			rollingObject.GetComponent<Rolling>().colliderSwitcher(true);
			timeDelay = Time.time + delay;
			anim.SetBool("Casting", false);
			anim.SetBool("Rolling", true);
		}
		else if (!gnomeFireOnCooldown){
			
			//			Debug.Log(playerCharacters[0]);
			//			for (int i=0; i<playerCharacters.Length; i++){
			//				if(playerCharacters[i]!=null)
			//					playerPosition = playerCharacters[i];
			//			}//end for
			gnomeFireOnCooldown = true;
			GameObject gnomeClone = Instantiate (gnomeProjectile, transform.position, transform.rotation) as GameObject;
			gnomeClone.transform.position = new Vector3(transform.position.x-6, transform.position.y + 15, transform.position.z);
			//Debug.Log(playerPosition.transform.position.x);
			//Debug.Log(gnomeClone.transform.position.x);
			Vector3 rotationVector = gnomeClone.transform.rotation.eulerAngles;
			rotationVector.z = 150;
			gnomeClone.rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((18), (-9))*Mathf.Rad2Deg - 90);	
			gnomeClone.rigidbody2D.velocity = transform.TransformDirection (new Vector3 (-40-Random.Range(0,30), Random.Range(10,50), 0));
			iTween.RotateTo(gnomeClone, rotationVector, 3);
			//			Vector3 midPoint = new Vector3((playerPosition.transform.position.x + gnomeClone.transform.position.x)/2, gnomeClone.transform.position.y + 20, gnomeClone.transform.position.z);
			//			Vector3[] path = new Vector3[2] {midPoint, playerPosition.transform.position};
			//			iTween.MoveTo(gnomeClone, iTween.Hash("path", path, "time", 1, "easeType", "easeOutCirc"));
			
			
			Destroy(gnomeClone, 5); 
			StartCoroutine(simulateGnomeFireCooldown());
			gnomeCount++;
		}//end if else
	}
	
	private void rollingGnome(){
		Vector3 newPos = new Vector3 (transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, 15);
		transform.parent.gameObject.transform.position = newPos;
		anim.SetBool("Rolling", true);
		
		//iTween.MoveTo (enemy, iTween.Hash("position", rollingPos.transform.position, "time", 3, "delay", 1));
		if( Time.time > timeDelay)
			enemy.transform.Translate (Vector3.left * Time.deltaTime * 150f);
	}
	
	private void bounceToOriginalPos(){
		
		Vector3 playerPos = rollingObject.GetComponent<Rolling> ().getCollisionPos ();
		//Vector3 midPoint = new Vector3 ((playerPos.x + originalBossPos.transform.position.x) / 2, playerPos.y + 10, originalBossPos.transform.position.z);
		Vector3 midPoint = new Vector3 ((playerPos.x + originalBossPos.transform.position.x) / 2, playerPos.y + 10, 15);
		Vector3 endPoint = new Vector3 (originalBossPos.transform.position.x, originalBossPos.transform.position.y, 15);
		Vector3[] path = new Vector3[2] {midPoint, endPoint};
		
		iTween.MoveTo (enemy, iTween.Hash ("path", path, "time", 2, "easetype", "easeOutCirc","oncompletetarget", this.gameObject, "oncomplete", "endRollingAnimation"));
		
		rollingObject.GetComponent<Rolling> ().resetRollingHit ();
		rollingObject.GetComponent<Rolling> ().colliderSwitcher (false);
		
		anim.SetBool ("Idle", true);
	}
	
	private void endRollingAnimation(){
		anim.SetBool ("Rolling", false);
		anim.SetBool ("Idle", true);
		Vector3 newPos = new Vector3 (transform.parent.gameObject.transform.position.x,transform.parent.gameObject.transform.position.y , 0);
		transform.parent.gameObject.transform.position = newPos;
	}
	
	public void setFrozen(int frozenTime)
	{
		if(!isFrozen)
		{
			isFrozen = true;
			GameObject freezeHim = Instantiate(frozenThrone,transform.parent.position,frozenThrone.transform.rotation) as GameObject;
			freezeHim.transform.parent = transform.parent;
			transform.parent.rigidbody2D.isKinematic = true;
			Destroy (freezeHim, frozenTime);
			StartCoroutine(simulateFreeze(frozenTime));
		}
		else
		{
			Debug.Log ("Already frozen");
		}
	}
	
	private IEnumerator simulateFreeze(int theTime)
	{
		yield return new WaitForSeconds (theTime);
		transform.parent.rigidbody2D.isKinematic = false;
		isFrozen = false;
	}
	
	private IEnumerator simulateGnomeFireCooldown(){
		gnomeFireWait = gnomeFireCooldown;
		for (var x = 1; x < gnomeFireCooldown; x++) {
			gnomeFireWait--;
			yield return new WaitForSeconds(1f);
		}//end for
		gnomeFireOnCooldown = false;
		gnomeFireWait = 0;
	}
	
	void FlipDirection()
	{
		facingRight = !facingRight;
		Vector3 charScale = enemy.transform.localScale;
		charScale.x *= -1;
		enemy.transform.localScale = charScale;
	}
}
