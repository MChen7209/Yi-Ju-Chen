using UnityEngine;
using System.Collections.Generic;

public class HeroController : MonoBehaviour
{
	private float originalHelmetPositionX;
    public Animator anim;
	private Animator helmetanim;
    public ParticleSystem particle;
    public bool grounded = false;
    private float groundRadius = 0.01f;
    private float lastHitTime;
    private bool stunned = false;
    private bool restarting = false;    //Checks if HandleDeath has been called.
    private int numberOfJumps = 0;
	private float acceleratorNum=1f;
	public AudioSource HurtSound;
	public AudioSource HealSound;
	private int localMemory = 0;

    public bool facingRight = true;
    private bool letgo = true;
    private bool jumping;
    private bool falling = true;
	private bool InWater = false;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public static float walkSpeed = 20f;
    public float maxFallSpeed = -50f;
    public float jumpForce = 700f;
    public VitalsScript Vitals;
	public GameObject Helmet;
	public bool suitOn;

    public static bool GameOver = false;
	private bool OnElevator;


	public bool GetFall()
	{
		return falling;
	}
	public bool SetFall(bool c)
	{
		falling = c;
		return falling;
	}

    void Start()
    {
		OnElevator = false;
		//power.HeroStartCharge = false;
        anim = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();
        Collider2D[] col = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D cc in col)
            cc.isTrigger = false;
        anim.SetBool("Dead", false);
        lastHitTime = Time.time;
		if (Application .loadedLevelName != "MainMenu")
        	Vitals = new VitalsScript();
        HeroController.GameOver = false;
        restarting = false;
        falling = true;
		originalHelmetPositionX = Helmet.transform.position.x;
        jumping = false;

		saveMemory ();

        CheckPoint.Check();
    }

    void FixedUpdate()
    {

		if (Application .loadedLevelName != "MainMenu")
		{
			Vitals.HandleEnergy ();
			if (HeroController.GameOver || Vitals.Dead) 
			{
				HandleDeath ();
				Fall ();
			}
		}
        if (!stunned&&!HeroController .GameOver)
        {
            Controls();
        }

    }

    void Controls()
    {

        if (Input.GetAxis("Jump") == 1 && numberOfJumps == 0)
        {
            jumping = true;
            falling = false;
        }
        else if (Input.GetAxis("Jump") < 1 && jumping)
        {
            jumping = false;
            falling = true;
            numberOfJumps++;
        }
        if (jumping)
        {
			OnElevator =false;
            Jump();

        }
		else if (falling)
        {
            Fall();
        }
		if (!OnElevator)
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		else
				grounded = true;
        if (grounded && numberOfJumps > 0)
        {
            Invoke("ResetFatigue", .01f);
        }
		else if (!grounded&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge )
        {
            falling = true;
            if (Input.GetAxis("Jump") == 0)
                numberOfJumps++;
        }

        anim.SetBool("Ground", grounded);
		if (!OnElevator)
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		else
		{
			anim.SetFloat ("vSpeed", 0f);

		}
        float move = Input.GetAxis("Horizontal");
		float UpOrDown = Input.GetAxis ("Vertical");
        anim.SetFloat("Speed", Mathf.Abs(move));
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
		if (InWater) 
		{
			//Helmet.GetComponent<SpriteRenderer> ().enabled = true;
			//Helmet.GetComponent<Collider2D> ().enabled = true;

			if(!grounded&&facingRight )
				Helmet.transform.position=new Vector3 (this.gameObject.transform.position.x-0.7f,Helmet.transform.position.y,Helmet.transform.position.z);
			if(!grounded&&!facingRight )
				Helmet.transform.position=new Vector3 (this.gameObject.transform.position.x+0.7f,Helmet.transform.position.y,Helmet.transform.position.z);
			Helmet.SetActive (true);
			helmetanim = GameObject.FindGameObjectWithTag ("Helmet").GetComponent<Animator> ();
			if(grounded&&Input.GetAxis ("Horizontal")>0)
			{
				Helmet.transform.position=new Vector3 (this.gameObject.transform.position.x+0.03f,Helmet.transform.position.y,Helmet.transform.position.z);
			}
			if(grounded&&Input.GetAxis ("Horizontal")<0)
			{
				Helmet.transform.position=new Vector3 (this.gameObject.transform.position.x-0.03f,Helmet.transform.position.y,Helmet.transform.position.z);
			}
			else if(grounded&&Input.GetAxis ("Horizontal")==0)
			{
				if(facingRight )
					Helmet.transform.position=new Vector3(this.gameObject.transform.position.x -0.7f,Helmet.transform.position.y,Helmet.transform.position.z);
				else
					Helmet.transform.position=new Vector3(this.gameObject.transform.position.x +0.7f,Helmet.transform.position.y,Helmet.transform.position.z);
			}
				
			if (Input.GetAxis ("Jump") == 1)
			{
				acceleratorNum = 1.6f;
				helmetanim.SetBool ("accelerating", true);
			}

			if (Input.GetAxis ("Jump") == 0)
				helmetanim.SetBool ("accelerating", false);
						//rigidbody2D.velocity=new Vector2(rigidbody2D.velocity.x,20f);
			Swim (UpOrDown * acceleratorNum, rigidbody2D.velocity.x);

		} 
		else 
		{
			//Helmet.GetComponent<SpriteRenderer>().enabled=false;
			//Helmet.GetComponent<Collider2D>().enabled=false;
			Helmet.SetActive (false);
		}
		Walk (move*acceleratorNum  , rigidbody2D.velocity.y);
		acceleratorNum = 1f;
    }

    void Walk(float move, float fallSpeed)
    {

        if (grounded&&!this.gameObject.GetComponentInChildren<HeroPowers >().HeroStartCharge)
            rigidbody2D.velocity = new Vector2(move*walkSpeed, fallSpeed);
        if(!grounded&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
			rigidbody2D.velocity = new Vector2(move*walkSpeed , fallSpeed);

    }
	void Swim(float move, float fallSpeed)
	{
		if (grounded&&!this.gameObject.GetComponentInChildren<HeroPowers >().HeroStartCharge )
			rigidbody2D.velocity = new Vector2(fallSpeed, move*walkSpeed-3f);
		if(!grounded&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
			rigidbody2D.velocity = new Vector2(fallSpeed, move*walkSpeed-3f );
	}
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.collider .tag == ("elevator")) 
		{
			OnElevator = true;
		}
		else 
		{
			OnElevator =false;
		}
		if ((other.collider.tag == ("Weapon") || other.collider.tag == ("Enemy")||other.collider.tag=="Boss")&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
        {
            if (Time.time > lastHitTime + .55)
            {
                TakeHit(other);
                lastHitTime = Time.time;
            }
        }
        else
        {
        }
		if(other.collider.tag=="Boss"&&this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
		{
			if(other.collider.GetComponent<ChargeBoss>()!=null)
				other.collider.GetComponent <ChargeBoss>().Stuned ();

		}
		if(other.collider.tag=="ChargePoint"&&this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
		{

			if(other.collider.GetComponentInParent<SubMarineBoss >()!=null)
			{
				other.collider.GetComponentInParent<SubMarineBoss>().Shot ();
				iTween.ShakePosition (other.collider.GetComponentInParent<SubMarineBoss>().gameObject  ,new Vector3(0.6f,0.6f,0),1f);
				
			}
		}
		if ((other.collider.tag == ("Weapon") || other.collider.tag == ("Enemy")) && this.gameObject.GetComponentInChildren<HeroPowers> ().HeroStartCharge)
		{
			if (other.collider.GetComponent<EnemyScript>() != null&&other.collider.tag!="Boss")
				other.collider.GetComponent<EnemyScript>().Kill();

			if(facingRight )
				this.gameObject.rigidbody2D.velocity=new Vector2(40f,0f);
			else
				this.gameObject.rigidbody2D.velocity=new Vector2(-40f,0f);

		
		}
		else if (other.collider.tag == "trap"||other.collider.tag=="Wall"&&this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge) 
		{
			StopCharge();
		}/*
		else if (this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge) 
		{
			if(facingRight )
			{
				rigidbody2D.velocity=new Vector2(50f,rigidbody2D.velocity.y);
			}
			else
				rigidbody2D.velocity=new Vector2(-50f,rigidbody2D.velocity.y);
		}*/


    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Water") 
		{
			InWater=true;
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Water")
						InWater = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Water") 
		{
			InWater=false;
		}
	}
	void OnCollisionStay2D(Collision2D other)
	{
		/*if (this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge&&this.enabled) 
		{
			if(facingRight )
			{
				rigidbody2D.velocity=new Vector2(50f,rigidbody2D.velocity.y);
			}
			else
				rigidbody2D.velocity=new Vector2(-50f,rigidbody2D.velocity.y);
		}*/
		if ((other.collider.tag == ("Weapon") || other.collider.tag == ("Enemy")||other.collider.tag=="Boss")&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
		{
			if (Time.time > lastHitTime + .55)
			{
				TakeHit(other);
				lastHitTime = Time.time;
			}
		}
	}
	/*void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.tag == "elevator") 
		{
			OnElevator =false;
		}
	}*/
    void TakeHit(Collision2D other)
    {
		if (other.gameObject.GetComponent<MoveProjectileScript> () != null)
						Destroy (other.gameObject);
       if (Vitals.TakeDamage ())
		{
			stunned = true;
			anim.SetBool ("Hurt", true);
			if (transform.position.x < other.transform.position.x)
					rigidbody2D.velocity = new Vector2 (-10f, rigidbody2D.velocity.y / 2 + 5f);
			else
					rigidbody2D.velocity = new Vector2 (10f, rigidbody2D.velocity.y / 2);
			Invoke ("unstun", 0.25f);
			var shield = transform.Find ("SpikeShield").gameObject;
			shield.GetComponent<SpikeShieldScript> ().Drop ();
			particle.Emit (15);

			StopCharge ();
       

			if (Vitals.Dead) 
			{
				particle.Emit (10);

			}
		}
        //Activate particle system or flash the character.
    }

    void unstun()
    {
        stunned = false;
		anim.SetBool ("Hurt", false);
    }

    public void Restart()
    {
		LevelChangeScript.RestartLevel();
        VitalsScript .CurrentEnergy = 0;
        VitalsScript .CurrentHealth = 3;
        Score.score = 0;
		Score.memory = localMemory;

        /*Shop.speedlevel = 0;
        Shop.energylevel = 0;
        Shop.healthlevel = 0;
        walkSpeed = 20f;
        VitalsScript .MaxEnergy = 100f;
        VitalsScript .MaxHealth = 100f;*/
    }

    /* 
     * This code will handle the players death. If it has not been called before,
     * it will set GameOver to true and Invoke Restart after two seconds.
     */
    public void HandleDeath()
    {
        if (!restarting)
        {
            HeroController.GameOver = true;

            Collider2D[] col = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D cc in col)
                cc.isTrigger = true;
            restarting = true;
			this.gameObject.rigidbody2D.velocity=new Vector2(0,0);
            falling = true;

            Invoke("Restart", 2);

        }
    }

    int maxJumpTime = 15;
    int jumpHeldTime = 0;
    void Jump()
    {
		if (InWater)
				return;
        if (jumpHeldTime < maxJumpTime && numberOfJumps == 0)
        {
            anim.SetBool("Ground", false);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 20f);
            if (jumpHeldTime == 0)
                rigidbody2D.AddForce(new Vector2(0, 325f));
            else if (jumpHeldTime < maxJumpTime / 2)
                rigidbody2D.AddForce(new Vector2(0, 40f));
            else
                rigidbody2D.AddForce(new Vector2(0, 30f));
            jumpHeldTime++;
        }
        else
        {
            jumping = false;
            falling = true;
            numberOfJumps++;
        }
    }

    void ResetFatigue()
    {
        if (grounded)
        {
            jumpHeldTime = 0;
            numberOfJumps = 0;
            falling = false;
            jumping = false;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        }
    }

    /* This is used when the hero picks up a powerup.
     *  It is publically callable from the powerup script.
     * Returns true if powerup accepted. False if not.
     */
    public bool PowerUp(string power)
    {
        if (power == "Spike")
        {
            var shield = transform.Find("SpikeShield").gameObject;
            shield.GetComponent<SpikeShieldScript>().PickUp();
            return true;
        }
        return false;
    }

    void Fall()
    {
		maxFallSpeed = -40;

		 

			if (rigidbody2D.velocity.y < maxFallSpeed)
			{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, maxFallSpeed);
			} 
			else
				rigidbody2D.AddForce (new Vector2 (0, -50f));
	}
    
	void StopCharge()
	{

		this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge =false;
	}

	 void saveMemory()
	{
		localMemory = Score.memory;
	}
	public int GetLocalMemory()
	{
		return localMemory;
	}
}
