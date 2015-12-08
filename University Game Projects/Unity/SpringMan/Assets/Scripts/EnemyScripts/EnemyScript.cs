using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public bool dead;
    public AudioClip enemydead;
   // public int energyReleased;
    public int scoreReleased;
    public AudioClip Springkill;
    private Meteor meteor;
    private GameObject playerObj;
    private HeroController player;
    public GameObject heal;
	public int BossHealth;
	public GameObject Points;

    public bool Stomped
    { //Can be used to build in a stomped animation, versus a powerup kill
        get
        {
            return stomped;
        }
        set
        {
			if(this.gameObject.tag=="Boss")
			{
				AudioSource.PlayClipAtPoint(Springkill, transform.position);
				if(this.gameObject.GetComponent<ChargeBoss>()!=null)
				{
					if(this.gameObject.GetComponent<ChargeBoss>().stun)
					{
					BossHealth--;
					player.Vitals.AbsorbEnergy(1);
					this.gameObject.GetComponent<ChargeBoss>().startNormal ();
					}
				}
				if(this.gameObject.GetComponent<SubMarineBoss>()!=null)
				{
					if(this.gameObject.GetComponent<SubMarineBoss>().ShotPhase)
					{
						this.gameObject.GetComponent<SubMarineBoss>().ShotPhase=false;
						//player.Vitals.AbsorbEnergy (3);
						this.gameObject.GetComponent<SubMarineBoss>().ChargePhase=true;
						BossHealth--;
					}
				}
				if(BossHealth<=0)
				{
					HeroPowers.BarrierSkill = true;
					Death ();
				}
			}
            stomped = true;
			if(this.gameObject.tag!="Boss")
			{
            	Death();
            	dead = true;
			}
        }
    }

    private bool stomped;

    // Use this for initialization
    void Start()
    {
		//BossHealth = 3;
        meteor = GameObject.FindGameObjectWithTag("Meteor").GetComponent<Meteor>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //print(screenPos.y);
        if (dead)
        {
            if (Screen.height * 2 < screenPos.y)
                Destroy(transform.gameObject);
            if (transform.position.y - Screen.height * 2 > screenPos.y)
                Destroy(transform.gameObject);
        }
		if (stomped)
		{
			if(this.gameObject.tag == "Boss")playerObj.rigidbody2D.velocity = new Vector2(playerObj.rigidbody2D.velocity.x, (-playerObj.rigidbody2D.velocity.y<25f)?18f:22f);
			if (Input.GetAxis("Jump") >0)
			{
				playerObj.rigidbody2D.velocity=new Vector2(playerObj.rigidbody2D.velocity.x,28f); 
				stomped=false;
			}

				stomped=false;
		}

    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }



    public void Kill()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(0, 250f));
        Death();
    }

    void Death()
    {
        if (!dead && !HeroController.GameOver)
        {
			if (stomped&&!playerObj.gameObject.GetComponentInChildren<HeroPowers> ().HeroStartCharge)
			{
				playerObj.rigidbody2D.velocity = new Vector2(playerObj.rigidbody2D.velocity.x, (-playerObj.rigidbody2D.velocity.y<25f)?18f:22f);
				Invoke ("cancelJump",0.1f);
			}

            player.Vitals.AbsorbEnergy(1);
			Instantiate (Points,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

            AudioSource.PlayClipAtPoint(enemydead, transform.position);
            AudioSource.PlayClipAtPoint(Springkill, transform.position);

            meteor.SlowDown(.15f, 1.5f); //Slows down meteor by .1 for 2 seconds
            Collider2D k = GetComponent<Collider2D>();
            k.isTrigger = true;
            Collider2D[] col = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D cc in col)
                cc.isTrigger = true;
            Rigidbody2D body = GetComponent<Rigidbody2D>();
			this.rigidbody2D.gravityScale = 1f;
			body.velocity=new Vector2(0f,0f);
            body.AddForce(new Vector2(0, 200f));
            body.fixedAngle = false;
            body.AddTorque(Random.Range(-100f, 100f));

			//Debug.Log ("stomped");

            Score.score += scoreReleased;
            dead = true;

            GenerateHealth();
        }
    }

    void GenerateHealth()
    {
        if (VitalsScript .CurrentHealth <= VitalsScript.MaxHealth / 2)
        {
            float pro = 0.3f;
            if (Random.value <= pro)
                Instantiate(heal, new Vector2(this.transform.position.x, this.transform.position.y - 1), Quaternion.identity);
        }
    }
	void cancelJump()
	{
		stomped = false;
	}


}
