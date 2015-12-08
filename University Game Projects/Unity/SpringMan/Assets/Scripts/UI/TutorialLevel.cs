using UnityEngine;
using System.Collections;

public class TutorialLevel : MonoBehaviour {
	private bool ShowChargeSkillInfo=false;
	private bool ShowDrillSkillInfo=false;
	private bool ShowBarrierSkillInfo=false;
	private bool ShowKillEnemyInfo=false;
	private bool ShowChipsInfo=false;
	private bool ShowLostPowersInfo = false;
	private bool HelloWords=true;
	private GameObject meteor;
	private bool barriercalled;
	public GameObject wall;

	// Use this for initialization
	void Start () {
		meteor = GameObject.FindGameObjectWithTag ("Meteor");
		barriercalled=false;
		Invoke ("DisableHelloWords", 1f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (meteor.transform.position.y < -25f&&barriercalled) 
		{
			meteor.GetComponent<Meteor >().enabled=false;
			Destroy (wall);
			//HeroPowers .BarrierSkill =false;
		}
		if (GameObject.FindGameObjectWithTag ("Barrier"))
						barriercalled = true;

		if (barriercalled)
						HeroPowers.BarrierSkill = false;
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "EnemyKill") 
		{
			ShowKillEnemyInfo =true;
			HelloWords =false;
		}
		if (other.name == "ChargeSkill") 
		{
			ShowChargeSkillInfo =true;
		}
		if (other.name == "DrillSkill") 
		{
			ShowDrillSkillInfo =true;
		}
		if (other.name == "BarrierSkill") 
		{
			ShowBarrierSkillInfo =true;
			meteor.GetComponent<Meteor >().enabled=true;
			HeroPowers .BarrierSkill =true;
		}
		if (other.name == "EatChips") 
		{
			ShowChipsInfo=true;
		}
		if (other.name == "EndPowers") 
		{
			ShowLostPowersInfo = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "EnemyKill") 
		{
			ShowKillEnemyInfo =false;
		}
		if (other.gameObject.name == "ChargeSkill") 
		{
			ShowChargeSkillInfo =false ;
		}
		if (other.name == "DrillSkill") 
		{
			ShowDrillSkillInfo =false ;
		}
		if (other.name == "BarrierSkill") 
		{
			ShowBarrierSkillInfo =false ;
			HeroPowers.BarrierSkill =false;
		}
		if (other.name == "EatChips") 
		{
			ShowChipsInfo=false;
		}
		if (other.name == "EndPowers") 
		{
			ShowLostPowersInfo = true;
		}
	}
	void OnGUI()
	{
		Shop.BeginUIResizing ();
		GUI.skin.label.fontSize = 32;
		if (HelloWords)
		{
			GUI.BeginGroup (new Rect (1920 / 2 - 200, 1080 / 2 - 300, 500, 200));
			GUI.Box (new Rect (0, 0, 500, 200), "");
		
			GUI.Label (new Rect (50, 50, 400, 150), "WELCOME TO SPRINGMAN'S WORLD");
			GUI.EndGroup ();
		}
		//Invoke ("DisableHelloWords", 1f);
		ShowInfo ();
		Shop.EndUIResizing ();
	}
	void ShowInfo()
	{
		if (ShowKillEnemyInfo) 
		{
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			
			GUI.Label(new Rect(50, 50, 400, 150), "JUMP ON AN ENEMY'S HEAD TO KILL IT");
			GUI.EndGroup ();
		}
		else if (ShowChargeSkillInfo) 
		{
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'ALT' TO USE THE CHARGE SKILL TO KILL ENEMIES");
			GUI.EndGroup ();
		}
		else if (ShowDrillSkillInfo) 
		{
			
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'SHIFT' TO DRILL THROUGH PLATFORMS");
			GUI.EndGroup ();
		}
		else if (ShowChipsInfo) 
		{
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "EACH MEMORY CHIP WILL GIVE YOU 1MB. GRAB THEM ALL FOR A BONUS");
			GUI.EndGroup ();
		}
		else if (ShowBarrierSkillInfo)
		{
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'CTRL' TO USE THE BARRIER WHICH CAN STOP THE METEOR FOR A WHILE");
			GUI.EndGroup ();
		}
		else if (ShowLostPowersInfo)
		{
			//GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "ERROR: ALL SKILLS HAVE BEEN LOST!");
			GUI.EndGroup ();
		}
	}
	void DisableHelloWords()
	{
		CancelInvoke ();
		HelloWords = false;
	}

}
