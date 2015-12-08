using UnityEngine;
using System.Collections;

public class SpikePowerupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HeroController>().PowerUp("Spike");
            Destroy(this.gameObject);
        }
    }
}
