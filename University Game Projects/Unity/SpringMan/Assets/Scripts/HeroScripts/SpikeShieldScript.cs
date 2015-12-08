using UnityEngine;
using System.Collections;

public class SpikeShieldScript : MonoBehaviour {

    GameObject SpikeShield;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Shield should do a set amount of damage to the bosses.
	 * */
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "Weapon")
		{

			if (other.GetComponent<EnemyScript>() != null)
				other.GetComponent<EnemyScript>().Kill();
		}
		else if (other.tag == "Boss")
		{

			//Do damage here?
		}
	}

    public void Drop()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        var colls = GetComponents<Collider2D>();
        foreach (var col in colls)
		{
            col.enabled = false;
		}
    }

    public void PickUp()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        var colls = GetComponents<Collider2D>();
        foreach (var col in colls)
		{
            col.enabled = true;
			col.isTrigger = true;
		}
    }
}
