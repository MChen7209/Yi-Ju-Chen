using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

	private EnemyScript boss;
	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag  ("Boss").GetComponent<EnemyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (boss == null)
						return;
		if (boss.dead && boss != null) openBarrier ();
	}

	void openBarrier(){
		Destroy (this.gameObject);
		boss = null;
	}
}
