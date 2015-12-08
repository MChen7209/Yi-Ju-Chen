using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelChangeScript : MonoBehaviour {

    public static int currentLevel;
	public static List<string> levels;
	// Use this for initialization
	void Start () 
	{
		levels = new List<string>(){"Level_0-1","Level_1-1", "Level_1-2", "Level_1-3", "Level_1-4","Level_1-5","Level_1-6","Level_1-7","Level_1Boss","Level_2-1","Level_2-2","Level_2-3","Level_2-4","Level_2-5","Level_2-6","Level_2Boss","Level_3-1","Level_3-2","Level_3-3","Level_3-4","Level_3-5","Level_3-6","Level_3Boss"};
	}

    void OnCollisionEnter2D(Collision2D other)
    {
		if (Application.loadedLevelName=="MainMenu") 
		{
			Application.LoadLevel (1);
			//Debug.Log (Application.loadedLevelName);
			return;
		}
        if (other.collider.tag == ("Player") && !HeroController.GameOver)
        {
            LoadShop();
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !HeroController.GameOver)
		{
           //Instantiate();
			//Score.score=100;
			if (Application.loadedLevelName != "MainMenu") 
            	 GameObject.Find("Camera").GetComponent<camerafollowing>().StopTrack();
	

		}

	}

	public static void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

    public static void LoadShop()
    {
        currentLevel = Application.loadedLevel;
        Application.LoadLevel("Level_Shop");
    }

    public static void NextLevel()
    {

        if (currentLevel < levels.Count)
        {
            Application.LoadLevel(currentLevel + 1);
			CheckPoint.CheckPointOne = false;
            CheckPoint.triggered = false;
        }

		if (currentLevel > 3)
			Meteor.fallSpeed = .1f;
		else
			Meteor.fallSpeed = .25f;
    }
}
