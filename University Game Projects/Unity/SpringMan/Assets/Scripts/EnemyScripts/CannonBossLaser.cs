using UnityEngine;
using System.Collections;

public class CannonBossLaser : MonoBehaviour 
{
	//Based on wanted selection
	public float laserCooldownTime;
	public float laserChargeTime;
	public float laserPrefireTime;
	public float laserShootTime;
	public float laserUnfireTime;
	public float laserChargeScaleSize;
	public float laserBeamScaleSize;

	public float time1 = 0;
	public float time2 = 0;
	public float time3 = 0;

	public float step;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;
	private GameObject laserChargeBall;
	private GameObject bossLaser;
	private CannonBossLife BossLife;
	//Reference to needed scripts
	private camerafollowing mainCameraScript;

	//Bools
	public bool playerInRange;
	public bool laserOnCooldown;
	public bool laserCharging;

	Vector3 chargeStartingScale;
	Vector3 chargeFinalScale;
	Vector3 laserFinalScale;
	Vector3 laserStartingScale;

	//Values inside

	//outside references
	public bool PlayerInRange
	{
		get {	return playerInRange;	}
	}

	public float Step
	{
		get {	return step;			}
	}

	// Use this for initialization
	void Start () 
	{
		bossBody = gameObject;
		playerBody = GameObject.FindGameObjectWithTag("Player");
		laserChargeBall = transform.FindChild("Charge").gameObject;
		bossLaser = transform.FindChild("Blast").gameObject;
		bossLaser.transform.localScale = new Vector3(0, bossLaser.transform.localScale.y, bossLaser.transform.localScale.z);
		laserOnCooldown = false;
		playerInRange = false;
		BossLife = this.gameObject.GetComponentInParent <CannonBossLife> ();
		step = 0;
		mainCameraScript = GameObject.FindGameObjectWithTag("MainCamera").transform.parent.GetComponent<camerafollowing>();

		chargeStartingScale = laserChargeBall.transform.localScale;
		chargeFinalScale = new Vector3(laserChargeScaleSize,laserChargeScaleSize,laserChargeScaleSize);
		laserStartingScale = bossLaser.transform.localScale;
		laserFinalScale = new Vector3(laserBeamScaleSize, bossLaser.transform.localScale.y, bossLaser.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(step == 0 && playerInRange)
			step = 1;
		if(step == 1 && !laserOnCooldown)
		{
			if(time1 < 1)
			{
				time1 += Time.deltaTime / laserChargeTime;
			}
			laserChargeBall.transform.localScale = Vector3.Lerp(chargeStartingScale, chargeFinalScale, time1);
			StartCoroutine("laserCharge");
		}
		else if(step == 1.5)
		{
			StartCoroutine("laserPrefire");
		}
		else if(step == 2 )
		{
			if(time2 < 1)
			{
				time2 += Time.deltaTime / laserShootTime;
			}
			//laserChargeBall.transform.localScale = Vector3.Lerp(chargeFinalScale, chargeStartingScale, time2);

			bossLaser.transform.localScale = Vector3.Lerp(laserStartingScale, laserFinalScale, time2);
			mainCameraScript.screenShake(2f,laserShootTime);
			StartCoroutine("laserFire");
		}
		else if(step == 3)
		{
			if(time3 < 1)
			{
				time3 += Time.deltaTime / laserUnfireTime;
			}
			laserChargeBall.transform.localScale = chargeStartingScale;
			bossLaser.transform.localScale = Vector3.Lerp(laserFinalScale, laserStartingScale, time3);
			laserChargeBall.transform.localScale = Vector3.Lerp(chargeFinalScale, chargeStartingScale, time3);
			StartCoroutine("laserUnfire");
		}
		else if(step == 4)
		{
			StartCoroutine("laserCooldown");
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("Player"))
			playerInRange = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag.Equals("Player"))
			playerInRange = false;
	}

	IEnumerator laserCharge()
	{
		yield return new WaitForSeconds(laserChargeTime);
		if(step == 1f)
			step = 1.5f;
	}

	IEnumerator laserPrefire()
	{
		yield return new WaitForSeconds(laserPrefireTime);
		if(step == 1.5f)
			step = 2f;
	}
	
	IEnumerator laserFire()
	{
		//Debug.Log("Doom");
		yield return new WaitForSeconds(laserShootTime);
		if(step == 2f)
			step = 3f;
	}

	IEnumerator laserUnfire()
	{
		yield return new WaitForSeconds(1);
		if(step == 3f)
			step = 4f;
	}

	IEnumerator laserCooldown()
	{
		time1 = 0;
		time2 = 0;
		time3 = 0;
		yield return new WaitForSeconds(laserCooldownTime);
		if(step == 4f)
			step = 0f;
	}

}
