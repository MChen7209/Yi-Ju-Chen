using UnityEngine;
using System.Collections;

public class CannonBossLife : MonoBehaviour 
{
	public int bossLifeNodes;
	public int step;
	public int scoreRelease;
	private bool CannonBossDead=false;
	private GameObject player;
	public GameObject point;

	private bool stepLock;
	// Use this for initialization
	void Start () 
	{
		step = 0;
		stepLock = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bossLifeNodes <= 0&&!CannonBossDead)
		{
			//Debug.Log("Boss Destroyed.");
			this.gameObject.GetComponentInChildren<CannonBossLaser>().enabled=false;
//			if(step == 0)
//			{
//				Debug.Log ("Play node explosion.");
//				addToStep(2);
//			}
//			else if(step == 1)
//			{
//				//Play destruction of boss life nodes
//				Destroy(GameObject.FindGameObjectWithTag ("CannonBossLifeNodes").transform.root.gameObject);
//				addToStep(2);
//			}
//			else if(step == 2)
//			{
//				//boss loses kinomatic
//				GameObject.FindGameObjectWithTag("Boss").rigidbody2D.isKinematic = false;
//				addToStep(2);
//
//			}
//			else if(step == 3)
//			{
//				Destroy(GameObject.FindGameObjectWithTag("Boss").gameObject);
//			}
			if(GameObject.FindGameObjectWithTag ("CannonBossRail")!=null)
				Destroy(GameObject.FindGameObjectWithTag ("CannonBossRail").gameObject);
			GameObject.FindGameObjectWithTag("Boss").rigidbody2D.isKinematic = false;
			BossDead();
		}
	}

	void addToStep(float waitTime)
	{
		StartCoroutine(wait(waitTime));
	}

	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
		step++;
	}
	 void  BossDead()
	{
		CannonBossDead = true;
		if(player.transform.position.y-this.gameObject.transform.position.y>100f)
			Destroy (GameObject.FindGameObjectWithTag ("Boss").gameObject);
		Score.score += scoreRelease;
		HeroPowers .BarrierSkill = true;
		Instantiate (point,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

	}
}
