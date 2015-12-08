using UnityEngine;
using System.Collections;

public class ChargeBoss : MonoBehaviour {

	bool charge;
	bool chargeRight;
	public bool stun;
	public GameObject background;
	private GameObject player;
	private Color bosscolor;

	// Use this for initialization
	void Start () {
		bosscolor = this.gameObject.GetComponent<SpriteRenderer> ().color;
		charge = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		stun = false;
		chargeRight = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!charge) 
		{
			if(this.gameObject.transform.position.x-player.transform.position.x<17f&&this.gameObject.transform.position.y-player.transform.position.y>0f&&this.gameObject.transform.position.x>player.transform.position.x)
			{
				charge=true;
				chargeRight=false;

				if(this.gameObject.GetComponent<EnemyMove>().faceright )
				{

					Flip ();
					this.gameObject.GetComponent<EnemyMove>().enabled=false;
					Invoke ("startCharge",3f);
				}
				if(!this.gameObject.GetComponent <EnemyMove>().faceright)
				{
					this.gameObject.GetComponent<EnemyMove>().enabled=false;
					Invoke ("startCharge",3f);
				}
			}
			if(this.gameObject.transform.position.x-player.transform.position.x>-17f&&this.gameObject.transform.position.y-player.transform.position.y>0f&&this.gameObject.transform.position.x<player.transform.position.x)
			{

				charge=true;
				chargeRight=true;
				if(this.gameObject.GetComponent<EnemyMove>().faceright )
				{
					this.gameObject.GetComponent<EnemyMove>().enabled=false;
					Invoke ("startCharge",3f);
				}
				if(!this.gameObject.GetComponent <EnemyMove>().faceright)
				{
					Flip ();
					this.gameObject.GetComponent<EnemyMove>().enabled=false;
					Invoke ("startCharge",3f);
				}
			}
		}
		if (stun) 
		{
				this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
		else
				this.gameObject.GetComponent<SpriteRenderer> ().color = bosscolor;
	
	}
	void Flip()
	{

		this.gameObject.GetComponent<EnemyMove>().faceright=!this.gameObject.GetComponent<EnemyMove>().faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void startCharge()
	{
		if (stun)
						return;
		CancelInvoke ();
		if(chargeRight)
						this.gameObject.rigidbody2D .velocity = new Vector2 (50f, 0);
		if (!chargeRight)
						this.gameObject.rigidbody2D.velocity = new Vector2 (-50f, 0);
	}

	public void Stuned()
	{
		if(!stun)
			this.gameObject.rigidbody2D.AddForce (new Vector2 ((this.gameObject.transform.position.x - player.transform.position.x)/Mathf.Abs(this.gameObject.transform.position.x-player.transform.position.x)*200000f, 0f));
		stun = true;
		CancelInvoke ();

		Invoke ("startNormal", 3f);



	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (charge && other.collider .tag == "Wall") 
		{	
			//this.gameObject.rigidbody2D .velocity = new Vector2 (0, 0);
			Flip ();
			if(!stun)
				iTween.ShakePosition (background ,new Vector3(0.6f,0.6f,0),1.5f);
			Stuned ();

		}
	}
	public void startNormal()
	{
		stun = false;
		charge = false;
		this.gameObject.GetComponent<EnemyMove>().enabled=true;
	}
}
