using UnityEngine;
using System.Collections;

public class DamageHRS : MonoBehaviour {
	public int damageRate = 10;

	private GameObject heatSuit;
	private GameObject player;
	private HeatResistantSuit suitScript;


	private bool causeDamage = false;

	// Use this for initialization
	void Start () {
		heatSuit = GameObject.FindGameObjectWithTag ("HeatResistantSuit");
		player = GameObject.FindGameObjectWithTag ("Player");
		suitScript = heatSuit.GetComponent<HeatResistantSuit> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if(causeDamage)

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
			InvokeRepeating("DamageSuit",1,1.25f);
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player")
			CancelInvoke ("DamageSuit");
	}

	void DamageSuit(){
		suitScript.currentTime -= damageRate;
	}
}
