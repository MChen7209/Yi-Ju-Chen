using UnityEngine;
using System.Collections;

public class SubmarineProjectile : MonoBehaviour {
	
	//private Animator anim;
	private bool fired = false;
	private bool facingLeft = true;
	private bool aimed = false;
	private float lastAimTime;
	public GameObject projectile;
	private GameObject lastProjectile;
	private GameObject player;
	private Transform cannon;
	private float angle;
	private bool inRange = false;
	public float shotTime;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		cannon = transform.Find ("Cannon");
	}
	
	// Update is called once per frame
	void Update () {
		// if (player == null)
		//     player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate(){
		angle = CalculateAngle ();
		if (player.transform.position.y < transform.position.y)
			angle *= -1;
		//Debug.Log ("the angle is " + angle);
		if (inRange) {			
			Vector3 rotationVector = new Vector3 (0, 180, angle);
			cannon.rotation = Quaternion.Euler (rotationVector);
			//if (lastProjectile == null)
			//{
				if (aimed)
					Fire();
				else
					Aim();
			//}
		} 		
		else{
			//anim.enabled = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
			return;
		inRange = true;
		if (aimed && !fired)
			Fire();
		else
			Aim();
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag != "Player")
			return;
		if (aimed && !fired)
			Fire();
		else
			Aim();
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
			return;
		inRange = false;
	}
	
	void Fire()
	{
		/*if (lastProjectile != null)
			Destroy(lastProjectile);*/
		/*lastProjectile=*/Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));// as GameObject ;
		//lastProjectile.transform.parent = this.transform; 
		fired = true;
		aimed = false;
	}
	
	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void Aim()
	{
		if (player == null)
			return;

		if (Time.time > lastAimTime + shotTime)
		{
			aimed = true;
			lastAimTime = Time.time;
		}
	}
	
	
	float CalculateAngle()
	{
		float y = 0;
		float x = 0;
		y = player.transform.position.y - transform.position.y;
		x = player.transform.position.x - transform.position.x;
		
		return Mathf.Abs(Mathf.Atan(y / x) * Mathf.Rad2Deg);
	}
	
	
}
