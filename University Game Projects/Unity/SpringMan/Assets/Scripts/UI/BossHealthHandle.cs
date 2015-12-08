using UnityEngine;
using System.Collections;

public class BossHealthHandle : MonoBehaviour {
	private EnemyScript Boss;

	int OldHealth;
	public float healthLength;
	public float startPosition;

	// Use this for initialization
	void Start () {

		Boss = GetComponentInParent <EnemyScript > ();
		OldHealth = Boss.BossHealth;

		healthLength = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size .x;
		startPosition = this.gameObject.transform.localPosition .x;

	}
	
	// Update is called once per frame
	void Update () {

		if (Boss != null && OldHealth != Boss.BossHealth) 
		{
			HandleHealth ();
			OldHealth=Boss.BossHealth;
		}

						
	
	}
	void HandleHealth()
	{
		this.gameObject.GetComponent <SpriteRenderer>().material.color = Color.Lerp(Color.green, Color.red, 1 -Boss.BossHealth  * 0.2f);
		
		// Set the scale of the health bar to be proportional to the player's health.
		this.gameObject.transform.localScale = new Vector3 (Boss.BossHealth * 0.2f, 1, 1);
		this.gameObject.transform.localPosition = new Vector2 (startPosition - 0.95f * (1f - this.gameObject.transform.localScale.x) / 2, this.gameObject.transform.localPosition.y);
			

	}

}
