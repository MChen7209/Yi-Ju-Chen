using UnityEngine;
using System.Collections;

public class MemoryPickUp : MonoBehaviour {

	public GameObject color;
	public GameObject Points;


	

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"&&!HeroController .GameOver) 
		{
			if(color.GetComponent<SpriteRenderer>().color==Color.red)
				return;
			color.GetComponent<SpriteRenderer>().color=Color.red;
			Score.memory+=1;

			Instantiate (Points,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));


		}
	}
}