using UnityEngine;
using System.Collections;

public class trapcontrol : MonoBehaviour {
	public bool trapOn=true;
	public GameObject[] trap;
	public AudioSource Switch;

	// Use this for initialization
	void Start () 
	{
		foreach (GameObject l in trap)
		{
			l.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (trapOn) {
		
		} else 
		{
			foreach (GameObject l in trap)
			{
				if(l.tag=="trap")
				{
					if(l.GetComponent<platformMove>()!=null)
						l.GetComponent<platformMove>().enabled=true;
					if(l.GetComponent<LaserMove>()!=null)
						l.GetComponent<LaserMove>().enabled=true;
					if(l.GetComponent<magnet>()!= null){
						l.GetComponent<magnet>().enabled=true;
						l.transform.FindChild("Magnetic Waves").GetComponent<SpriteRenderer>().enabled = true;
					}
				}
				else 
					l.SetActive (false);
				
			}
	
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			trapOn=false;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && trapOn) 
        {
            trapOn=false;
            FlipLever(false);
        }
    }

    void FlipLever(bool state)
    {
		Switch.Play ();
        if (state)
        {
        }
        else
        {
            transform.Find("leverred").GetComponent<SpriteRenderer>().enabled = false;
            transform.Find("levergreen").GetComponent<SpriteRenderer>().enabled = true;

        }
    }

}
