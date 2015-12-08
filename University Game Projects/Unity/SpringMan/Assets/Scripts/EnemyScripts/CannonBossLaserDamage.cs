using UnityEngine;
using System.Collections;

public class CannonBossLaserDamage : MonoBehaviour 
{
	public float damageScaleLimit=0;
	//Script connection
	CannonBossLaser cannonBossScript;

	//GameObject Connection To Ball energy
	GameObject cannonBallCharge;

	//Script
	bool hittable;

	void Start()
	{
		hittable = true;
		cannonBossScript = transform.parent.GetComponent<CannonBossLaser>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
//		Debug.Log("Other Guy: " + other.tag);
		if(hittable && other.tag.Equals("Player") && transform.localScale.x >damageScaleLimit)
		{
			other.GetComponent<HeroController>().Vitals.TakeDamage();
			hittable = false;
		}
	}

	void Update()
	{
		if(cannonBossScript.Step == 0)
			hittable = true;
	}
}
