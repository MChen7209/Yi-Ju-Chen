using UnityEngine;
using System.Collections;

public class BossCheckpoint : MonoBehaviour {

	public camerafollowing camera;
	public GameObject Barrier;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform.parent.GetComponent<camerafollowing> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			camera.BossCamera ();
			HeroPowers.BarrierSkill = false;
			Instantiate (Barrier, new Vector3 (0.5859733f, transform.position.y + 4, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			Destroy(this.gameObject);
		}
	}
}
