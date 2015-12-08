using UnityEngine;
using System.Collections;

public class HeroSpawn : MonoBehaviour {

	public GameObject Hero;
	// Use this for initialization
	void Start () {
		if(!HeroController .GameOver)
		Instantiate(Hero, this.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
