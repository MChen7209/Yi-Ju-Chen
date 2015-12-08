using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    //public static Transform HeroPosition;
	public GameObject Barrier;
    public static bool CheckPointOne = false;
    public static int SavedScore = 0;
	public static int SavedMemory = 0;
    public static bool triggered = false;

    // Use this for initialization
    //void OnCollisionEnter2D(Collision2D other)
	void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.collider.tag == "Player")
		if(other.collider.tag == "Player" && !HeroController.GameOver && !triggered)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            triggered = true;
            CheckPointOne = true;
            SavedScore = Score.score;
			SavedMemory =Score.memory ;
			Instantiate (Barrier, new Vector3 (0.5859733f, transform.position.y + 10, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			//Destroy (this.gameObject);
            //HeroPosition.position=new Vector2(this.transform.position.x,this.transform.position.y+10f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !HeroController.GameOver && !triggered)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            triggered = true;
            CheckPointOne = true;
            SavedScore = Score.score;
			SavedMemory=Score.memory ;
            Instantiate (Barrier, new Vector3 (0.5859733f, transform.position.y + 10, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
        }
    }

    public static bool Check()
    {
        var check = GameObject.Find("Checkpoint");
        if (check != null && CheckPoint.CheckPointOne)
        {
            check.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = new Vector2(check.transform.position.x, check.transform.position.y + 7);
            GameObject.FindGameObjectsWithTag("Meteor")[0].transform.position = new Vector2(0, check.transform.position.y + 80);
            Score.score = SavedScore;
			Score.memory =SavedMemory ;
            triggered = true;
            return true;
        }
        return false;
    }
}
