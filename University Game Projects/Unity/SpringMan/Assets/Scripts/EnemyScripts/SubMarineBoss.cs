using UnityEngine;
using System.Collections;

public class SubMarineBoss : MonoBehaviour {
	public bool ShotPhase;
	public GameObject[] BossCannon;
	public GameObject[] SummonPoint;
	public GameObject HeroChargePoint;
	//public GameObject StompZone;
	public bool ChargePhase;
	public bool SummonPhase;
	private bool BeginFight;

	private Animator anim;
	private HingeJoint2D hingeJoint2D;

	private bool StartShot=false;



	private camerafollowing camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Camera").GetComponent<camerafollowing > ();
		ShotPhase = false;
		ChargePhase = false;
		SummonPhase = false;
		BeginFight = false;
		anim = GetComponent<Animator>();
		hingeJoint2D = GetComponentInChildren<HingeJoint2D>();

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!camera.trackX && !camera.trackY)
						BeginFight = true;
		if (ShotPhase&&!ChargePhase&&!SummonPhase&&!StartShot)
			Shot ();
		if(ChargePhase&&!ShotPhase&&!SummonPhase)
			Charge();
		if (SummonPhase&&!ShotPhase&&!ChargePhase)
			Summon ();
		if (BeginFight && !ShotPhase && !ChargePhase && !SummonPhase) 
		{

			ShotPhase = true;
		}
	}
	/*	public void Shot()
	
	{
		anim.SetBool ("startshooting", true);
		anim.SetBool ("startcharging", false);
		anim.SetBool ("startsummoning", false);
		JointMotor2D motor = hingeJoint2D.motor;
		motor.motorSpeed = 20;
		hingeJoint2D.motor = motor;
		foreach(GameObject l in BossCannon)
		{
			l.SetActive (true);
		}
		StompZone .SetActive (true);
		ShotPhase = true;
		ChargePhase = false;
		SummonPhase = false;
		Invoke ("Charge", 15f);

*/
	public void Shot()
	{	
		anim.SetBool ("preparecharging", false);
		anim.SetBool ("startshooting", true);
		anim.SetBool ("startcharging", false);
		anim.SetBool ("startsummoning", false);
		JointMotor2D motor = hingeJoint2D.motor;
		motor.motorSpeed = 20;
		hingeJoint2D.motor = motor;
		StartShot = true;
		HeroChargePoint .SetActive (false);
		StartCoroutine(DoAnimation ());
		ShotPhase = true;
		ChargePhase = false;
		SummonPhase = false;


	}

	public void Charge()
	{
		JointMotor2D motor = hingeJoint2D.motor;
		motor.motorSpeed = -60;
		hingeJoint2D.motor = motor;
		//anim.SetBool ("startcharging", true);
		anim.SetBool ("startshooting", false);
		anim.SetBool ("startsummoning", false);
		CancelInvoke ();
		StartShot = false;
		ShotPhase = false;
		ChargePhase = true;
		SummonPhase = false;

	
	
		//Invoke ("Summon", 3f);
	}
	public void Summon()
	{

		anim.SetBool ("startsummoning", true);
		anim.SetBool ("startshooting", false);
		anim.SetBool ("startcharging", false);

		HeroChargePoint.SetActive (false);

		foreach (GameObject l in SummonPoint)
		{
			l.SetActive (true);
		}
		StartShot = false;
		ChargePhase = false;
		ShotPhase = false;
		SummonPhase = true;

		//Invoke ("Shot", 3f);
	}
	IEnumerator DoAnimation()
	{

		yield return new WaitForSeconds (3f);
		foreach(GameObject l in BossCannon)
		{
			l.SetActive (true);
		}
		//StompZone .SetActive (true);

		Invoke ("Charge", 15f);

	}
}
