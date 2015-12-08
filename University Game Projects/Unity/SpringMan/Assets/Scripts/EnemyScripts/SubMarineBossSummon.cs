using UnityEngine;
using System.Collections;

public class SubMarineBossSummon : MonoBehaviour {
	public float spawnTime ;		// The amount of time between each spawn.
	public float spawnDelay ;		// The amount of time before spawning starts.
	public GameObject[] Enemy;		// Array of enemy prefabs.
	private bool StartSummon;
	private SubMarineBoss Boss;
	private float RepeatNum;
	// Use this for initialization
	void Start () {
		Boss = this.gameObject.GetComponentInParent<SubMarineBoss> ();
		StartSummon = false;
		RepeatNum = 0;

	}
	void FixedUpdate()
	{
		if (Boss.SummonPhase && !StartSummon)
						PerpareSummon ();
		if (!this.gameObject.GetComponentInParent <SubMarineBoss > ().SummonPhase)
		   this.gameObject.SetActive (false);
		if (RepeatNum >= 4) 
		{
			CancelInvoke ();
			StartSummon=false;
			RepeatNum=0;
			Boss.Charge();
		}
	}
	// Update is called once per frame
	void Spawn () {
		int EnemyIndex = Random.Range (0, Enemy.Length);
		Instantiate(Enemy[EnemyIndex], this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		RepeatNum++;
	}
	void PerpareSummon()
	{
		Invoke ("BeginSummon", 4f);
	}
	void BeginSummon()
	{
		CancelInvoke ();
		StartSummon = true;
		InvokeRepeating ("Spawn", spawnTime, spawnDelay);
	}
}
