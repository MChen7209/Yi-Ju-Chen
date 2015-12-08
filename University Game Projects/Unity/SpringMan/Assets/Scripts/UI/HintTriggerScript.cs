using UnityEngine;
using System.Collections;

public class HintTriggerScript : MonoBehaviour {

    public string Text;
    public int HintNum;
    private bool activated = false;

    GameHintScript HintWindow;
	// Use this for initialization
	void Start () 
    {
	    HintWindow = GameObject.Find("Menu").GetComponent<GameHintScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Activate(other.tag);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Activate(other.collider.tag);
    }

    void Activate(string tag)
    {
        if (tag == "Player" && !activated) //Fix Hints showing up on Death (Check if player is dead before open)
        {
            HintWindow.DisplayHint(HintNum);
           //HintWindow.SetText(Text);
            //HintWindow.Open();
            activated = true;
        }
    }
}
