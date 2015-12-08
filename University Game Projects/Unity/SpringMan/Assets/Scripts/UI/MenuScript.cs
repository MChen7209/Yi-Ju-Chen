
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {

	public List<Color> primaryColors;
	public List<Color> secondaryColors;
	public List <Texture2D> skillsTextures;
	public static float Volume = .3f;
    public static bool Hints = true;
	private HeroController player;
	private Shop s;
	private Hospital H;
	public AudioSource ButtonSound;
	private camerafollowing cameracontrol;
	private static string[] str=new string[]{"EMPTY SLOT","EMPTY SLOT","EMPTY SLOT","EMPTY SLOT"};
	private static bool setStr0=false;
	private static bool setStr1 = false;
	private static bool setStr2 = false;
	private static bool setStr3=false;
	private static bool select1 = false;
	private static bool select2=false;
	private static bool select3=false;
	private static bool select4=false;

	public bool IsLevel;
	private bool showCredits = false;
	private bool IsOpen = false;
	private bool AskIfDelete= false;
	private bool Delete1=false;
	private bool Delete2=false;
	private bool Delete3=false;
	private bool Delete4=false;

	private bool hasUpdatedGui = false;
	private int currentColor;

   // bool chapterSelect = false;
	bool startgameselected=false;
	bool typenameWindow=false;

	bool settings = false;
	bool confirmQuit = false;
    float native_width = 1920;
    float native_height = 1080;
    public static float gameSpeed = 1.25f;
	private float t=0;

	void Start () {
		//Debug.Log (Application.loadedLevelName);

		if(Application.loadedLevelName!="Level_Shop")
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController> ();
		cameracontrol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <camerafollowing > ();
		if (player != null&&!IsLevel )
						player.enabled = false;
		if (!IsLevel && cameracontrol != null) 
		{
			cameracontrol.enabled=false;
		}
		if(Application.loadedLevelName =="Level_Shop")
			s = GameObject.Find ("Shop").GetComponent<Shop> ();
		if (Application.loadedLevelName == "Level_Hospital")
			H = GameObject.Find ("Shop").GetComponent<Hospital > ();
		AudioListener.volume = .3f;
		MenuScript.Volume = AudioListener.volume;
		if (!IsLevel)
			IsOpen = true;
		if (IsLevel) 
		{
			if(Application.loadedLevelName!="Level_Shop"&&select1)
				Save (1);
			else if(Application.loadedLevelName!="Level_Shop"&&select2)
				Save (2);
			else if(Application.loadedLevelName!="Level_Shop"&&select3)
				Save (3);
			else if(Application.loadedLevelName!="Level_Shop"&&select4)
				Save (4);

		}
        Time.timeScale = gameSpeed;
	}
    void OnGUI(){
		Shop.BeginUIResizing ();
		if (!hasUpdatedGui) {
			ColoredGUISkin.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
			hasUpdatedGui = true;
		}
		GUI.skin = ColoredGUISkin.Skin;
		GUI.skin.button.fontSize = 64;
		GUI.skin.label .fontSize = 64;
        float rx = 1920 / native_width;
        float ry = 1080 / native_height;
    //    GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
		if (!IsLevel)
			MainMenu();
		else
			GameMenu();
		Shop.EndUIResizing ();

    } 

	private void  MainMenu()
	{
		int boxHeight, boxWidth;
		boxWidth = 1000;
	
		/*if (chapterSelect)
		{
			boxHeight = 600;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			if (GUI.Button(new Rect(35, 30, 250, 90), "BACK"))
			{
				ButtonSound.Play();

				chapterSelect = false;
            }
			if (GUI.Button(new Rect(100, 180, 400, 90), "LEVEL 1-1"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(100, 330, 400, 90), "LEVEL 1-2"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(2);
			}
			if (GUI.Button(new Rect(100, 480, 400, 90), "LEVEL 1-3"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(3);
			}
            if (GUI.Button(new Rect(500, 180, 400, 90), "LEVEL 2-1"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(4);
            }
            if (GUI.Button(new Rect(500, 330, 400, 90), "LEVEL 2-2"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(5);
            }
            if (GUI.Button(new Rect(500, 480, 400, 90), "LEVEL 2-3"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(6);
            }

		}*/
		 if (settings)
		{
			SettingsMenu ();
		}
		else if (showCredits)
		{
			boxHeight = 600;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 299, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			GUI.Label (new Rect(100,20,600,600),"PROGRAMMER-AOBO\r\nPROGRAMMER-YIJU\r\nARTIST-JINGKAI\r\nARTIST-ORLANDO");
			if(GUI.Button(new Rect(500,450,250,90),"BACK"))
			{
				ButtonSound .Play ();
				showCredits =false;
				
			}
		}
		else if(AskIfDelete )
		{
			GUI.skin.label .fontSize = 64;
			boxHeight = 320;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
			GUI.Box (new Rect (0,0,boxWidth,boxHeight), "");
			
			GUI.Label(new Rect(50, 50, 800, 200), "ARE YOU SURE YOU WANT TO DELETE ALL DATA?");
			
			if (GUI.Button(new Rect(200, boxHeight - 120, 250, 90), "YES"))
			{
				ButtonSound .Play ();
				if(Delete1)
				{
					PlayerPrefs.DeleteKey ("UserName1");
					PlayerPrefs.DeleteKey ("BarrierSend1");
					PlayerPrefs.DeleteKey("BarrierLv4Send1");
					PlayerPrefs .DeleteKey ("BarrierLv3Send1");
					PlayerPrefs.DeleteKey ("BarrierLv2Send1");
					PlayerPrefs.DeleteKey ("BarrierLv1Send1");
					PlayerPrefs.DeleteKey ("EnergyLv4Send1");
					PlayerPrefs.DeleteKey ("EnergyLv3Send1");
					PlayerPrefs.DeleteKey ("EnergyLv2Send1");
					PlayerPrefs.DeleteKey ("EnergyLv1Send1");
					PlayerPrefs .DeleteKey ("HealthLv4Send1");
					PlayerPrefs .DeleteKey ("HealthLv3Send1");
					PlayerPrefs .DeleteKey ("HealthLv2Send1");
					PlayerPrefs .DeleteKey ("HealthLv1Send1");
					PlayerPrefs.DeleteKey("DrillSkillSend1");
					PlayerPrefs.DeleteKey ("ChargeSkillSend1");
					PlayerPrefs.DeleteKey ("MaxEnergy1");
					PlayerPrefs.DeleteKey ("MaxHealth1");
					PlayerPrefs.DeleteKey ("MemoryChips1");
					PlayerPrefs.DeleteKey ("CurrentLevel1");
					setStr0 =false;
					str[0]="EMPTY SLOT";
					Delete1=false;
					AskIfDelete =false;
				}
				if(Delete2)
				{
					PlayerPrefs.DeleteKey ("UserName2");
					PlayerPrefs.DeleteKey ("BarrierSend2");
					PlayerPrefs.DeleteKey("BarrierLv4Send2");
					PlayerPrefs .DeleteKey ("BarrierLv3Send2");
					PlayerPrefs.DeleteKey ("BarrierLv2Send2");
					PlayerPrefs.DeleteKey ("BarrierLv1Send2");
					PlayerPrefs.DeleteKey ("EnergyLv4Send2");
					PlayerPrefs.DeleteKey ("EnergyLv3Send2");
					PlayerPrefs.DeleteKey ("EnergyLv2Send2");
					PlayerPrefs.DeleteKey ("EnergyLv1Send2");
					PlayerPrefs .DeleteKey ("HealthLv4Send2");
					PlayerPrefs .DeleteKey ("HealthLv3Send2");
					PlayerPrefs .DeleteKey ("HealthLv2Send2");
					PlayerPrefs .DeleteKey ("HealthLv1Send2");
					PlayerPrefs.DeleteKey("DrillSkillSend2");
					PlayerPrefs.DeleteKey ("ChargeSkillSend2");
					PlayerPrefs.DeleteKey ("MaxEnergy2");
					PlayerPrefs.DeleteKey ("MaxHealth2");
					PlayerPrefs.DeleteKey ("MemoryChips2");
					PlayerPrefs.DeleteKey ("CurrentLevel2");
					setStr1 =false;
					str[1]="EMPTY SLOT";
					Delete2=false;
					AskIfDelete =false;
				}
				if(Delete3)
				{
					PlayerPrefs.DeleteKey ("UserName3");
					PlayerPrefs.DeleteKey ("BarrierSend3");
					PlayerPrefs.DeleteKey("BarrierLv4Send3");
					PlayerPrefs .DeleteKey ("BarrierLv3Send3");
					PlayerPrefs.DeleteKey ("BarrierLv2Send3");
					PlayerPrefs.DeleteKey ("BarrierLv1Send3");
					PlayerPrefs.DeleteKey ("EnergyLv4Send3");
					PlayerPrefs.DeleteKey ("EnergyLv3Send3");
					PlayerPrefs.DeleteKey ("EnergyLv2Send3");
					PlayerPrefs.DeleteKey ("EnergyLv1Send3");
					PlayerPrefs .DeleteKey ("HealthLv4Send3");
					PlayerPrefs .DeleteKey ("HealthLv3Send3");
					PlayerPrefs .DeleteKey ("HealthLv2Send3");
					PlayerPrefs .DeleteKey ("HealthLv1Send3");
					PlayerPrefs.DeleteKey("DrillSkillSend3");
					PlayerPrefs.DeleteKey ("ChargeSkillSend3");
					PlayerPrefs.DeleteKey ("MaxEnergy3");
					PlayerPrefs.DeleteKey ("MaxHealth3");
					PlayerPrefs.DeleteKey ("MemoryChips3");
					PlayerPrefs.DeleteKey ("CurrentLevel3");
					setStr2 =false;
					str[2]="EMPTY SLOT";
					Delete3=false;
					AskIfDelete =false;
				}
				if(Delete4)
				{
					PlayerPrefs.DeleteKey ("UserName4");
					PlayerPrefs.DeleteKey ("BarrierSend4");
					PlayerPrefs.DeleteKey("BarrierLv4Send4");
					PlayerPrefs .DeleteKey ("BarrierLv3Send4");
					PlayerPrefs.DeleteKey ("BarrierLv2Send4");
					PlayerPrefs.DeleteKey ("BarrierLv1Send4");
					PlayerPrefs.DeleteKey ("EnergyLv4Send4");
					PlayerPrefs.DeleteKey ("EnergyLv3Send4");
					PlayerPrefs.DeleteKey ("EnergyLv2Send4");
					PlayerPrefs.DeleteKey ("EnergyLv1Send4");
					PlayerPrefs .DeleteKey ("HealthLv4Send4");
					PlayerPrefs .DeleteKey ("HealthLv3Send4");
					PlayerPrefs .DeleteKey ("HealthLv2Send4");
					PlayerPrefs .DeleteKey ("HealthLv1Send4");
					PlayerPrefs.DeleteKey("DrillSkillSend4");
					PlayerPrefs.DeleteKey ("ChargeSkillSend4");
					PlayerPrefs.DeleteKey ("MaxEnergy4");
					PlayerPrefs.DeleteKey ("MaxHealth4");
					PlayerPrefs.DeleteKey ("MemoryChips4");
					PlayerPrefs.DeleteKey ("CurrentLevel4");
					setStr3 =false;
					str[3]="EMPTY SLOT";
					Delete4=false;
					AskIfDelete =false;
				}
			}
			if (GUI.Button(new Rect(500, boxHeight - 120, 250, 90), "NO"))
			{
				ButtonSound.Play();
				AskIfDelete  = false;
			}
		}
		else if (typenameWindow) 
		{
			//GUI.skin.textField .fontSize =32;
			boxHeight = 400;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 299, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			GUI.Label (new Rect(100,20,600,120),"TYPE NAME: ");
			if(select1 )
			{
				str[0]=GUI.TextField (new Rect(100,150,800,100),str[0],10);
				if(GUI.Button(new Rect(600,260,250,90),"BACK"))
				{
					ButtonSound .Play ();
					typenameWindow =false;
					str[0]="EMPTY SLOT";
					setStr0=false;
				}
				if(GUI.Button (new Rect(230,260,250,90),"ENTER"))
				{
					ButtonSound.Play ();
					setStr0=true;
					System.Threading .Thread.Sleep (300);
					Application.LoadLevel(1);
				}
			}
			else if(select2)
			{
				str[1]=GUI.TextField (new Rect(100,150,800,100),str[1],10);
				if(GUI.Button(new Rect(600,260,250,90),"BACK"))
				{
					ButtonSound .Play ();
					typenameWindow =false;
					str[1]="EMPTY SLOT";
					setStr1=false;

				}
				if(GUI.Button (new Rect(230,260,250,90),"ENTER"))
				{
					ButtonSound.Play ();
					setStr1=true;

					System.Threading .Thread.Sleep (300);
					Application.LoadLevel(1);
				}
			}
			else if(select3)
			{
				str[2]=GUI.TextField (new Rect(100,150,800,100),str[2],10);
				if(GUI.Button(new Rect(600,260,250,90),"BACK"))
				{
					ButtonSound .Play ();
					typenameWindow =false;
					str[2]="EMPTY SLOT";
					setStr2=false;
					
				}
				if(GUI.Button (new Rect(230,260,250,90),"ENTER"))
				{
					ButtonSound.Play ();
					setStr2=true;
					
					System.Threading .Thread.Sleep (300);
					Application.LoadLevel(1);
				}
			}
			else if(select4)
			{
				str[3]=GUI.TextField (new Rect(100,150,800,100),str[3],10);
				if(GUI.Button(new Rect(600,260,250,90),"BACK"))
				{
					ButtonSound .Play ();
					typenameWindow =false;
					str[3]="EMPTY SLOT";
					setStr3=false;
					
				}
				if(GUI.Button (new Rect(230,260,250,90),"ENTER"))
				{
					ButtonSound.Play ();
					setStr3=true;
					
					System.Threading .Thread.Sleep (300);
					Application.LoadLevel(1);
				}
			}

			//else if(setStr1)



		}
		else if (startgameselected) 
		{
			boxHeight = 700;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 299, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");

			if(!setStr0)
			{
				if(GUI.Button(new Rect(100, 55, 800, 90), str[0]))
				{
					ButtonSound.Play();
					SetToBegin();
					typenameWindow =true;
					select1 =true;
					select2=false;
					select3=false;
					select4=false;
					setStr0=true;
				}
			}
			else
			{

				if(GUI.Button(new Rect(100, 55, 540, 90), str[0]+" - "+PlayerPrefs.GetInt ("CurrentLevel1")*100/(LevelChangeScript.levels.Count-1)+"%"))
				{
					ButtonSound.Play();
					Load (1);
					select1=true;
					select2=false;
					Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel1"));
				}
				if(GUI.Button (new Rect(650,55,250,90),"DELETE") )
				{
					ButtonSound .Play ();
					AskIfDelete=true;
					Delete1=true;
				}
			}

			if(!setStr1)
			{
				if(GUI.Button(new Rect(100, 188, 800, 90), str[1]))
				{
					ButtonSound.Play();
					SetToBegin();
					select2=true;
					select1=false;
					select3=false;
					select4=false;
					typenameWindow =true;
					setStr1=true;
				}
			}
			else
			{

				if(GUI.Button(new Rect(100, 188, 540, 90), str[1]+" - "+PlayerPrefs.GetInt ("CurrentLevel2")*100/(LevelChangeScript.levels.Count-1)+"%"))
				{
					ButtonSound.Play();
					Load (2);
					select1=false;
					select2=true;
					select3=false;
					select4=false;
					Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel2"));
				}
				if(GUI.Button (new Rect(650,188,250,90),"DELETE"))
				{
					ButtonSound .Play ();
					AskIfDelete=true;
					Delete2=true;
				}
			}
			if(!setStr2)
			{
				if(GUI.Button(new Rect(100, 321, 800, 90), str[2]))
				{
					ButtonSound.Play();
					SetToBegin();
					select3=true;
					select1=false;
					select2=false;
					select4=false;
					typenameWindow =true;
					setStr2=true;
				}
			}
			else
			{
				
				if(GUI.Button(new Rect(100, 321, 540, 90), str[2]+" - "+PlayerPrefs.GetInt ("CurrentLevel3")*100/(LevelChangeScript.levels.Count-1)+"%"))
				{
					ButtonSound.Play();
					Load (3);
					select1=false;
					select3=true;
					select2=false;
					select4=false;
					Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel3"));
				}
				if(GUI.Button (new Rect(650,321,250,90),"DELETE"))
				{
					ButtonSound .Play ();
					AskIfDelete=true;
					Delete3=true;
				}
			}
			if(!setStr3)
			{
				if(GUI.Button(new Rect(100, 455, 800, 90), str[3]))
				{
					ButtonSound.Play();
					SetToBegin();
					select4=true;
					select1=false;
					select2=false;
					select3=false;
					typenameWindow =true;
					setStr3=true;
				}
			}
			else
			{
				
				if(GUI.Button(new Rect(100, 455, 540, 90), str[3]+" - "+PlayerPrefs.GetInt ("CurrentLevel4")*100/(LevelChangeScript.levels.Count-1)+"%"))
				{
					ButtonSound.Play();
					Load (4);
					select1=false;
					select4=true;
					select2=false;
					select3=false;
					Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel4"));
				}
				if(GUI.Button (new Rect(650,455,250,90),"DELETE"))
				{
					ButtonSound .Play ();
					AskIfDelete=true;
					Delete4=true;
				}
			}

			if(GUI.Button (new Rect(500,555,250,90),"BACK"))
			{
				ButtonSound .Play ();
				startgameselected =false;
			}
			//GUI.EndGroup() ;
		}

		else if (confirmQuit)
		{
			GUI.skin.label .fontSize = 64;
			boxHeight = 320;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
			GUI.Box (new Rect (0,0,boxWidth,boxHeight), "");

			GUI.Label(new Rect(50, 50, 800, 200), "ARE YOU SURE YOU WANT TO QUIT?");
			
			if (GUI.Button(new Rect(200, boxHeight - 120, 250, 90), "YES"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Shop.healthlv1Selected =false;
				Shop.healthlv2Selected =false;
				Shop.healthlv3Selected =false;
				Shop.healthlv4Selected =false;
				//Shop.sendHealthlv1 =false;
				//Shop.sendHealthlv2 =false;
				//Shop.sendHealthlv3 =false;
				//Shop.sendHealthlv4 =false;
				Shop.energylv1Selected =false;
				Shop.energylv2Selected =false;
				Shop.energylv3Selected =false;
				Shop.energylv4Selected =false;
				//Shop.sendEnergylv1 =false;
				//Shop.sendEnergylv2 =false;
				//Shop.sendEnergylv3 =false;
				//Shop.sendEnergylv4 =false;
				Shop.barrierlv1Selected =false;
				Shop.barrierlv2Selected =false;
				Shop.barrierlv3Selected =false;
				Shop.barrierlv4Selected =false;
				//Shop.sendBarrierlv1 =false;
				//Shop.sendBarrierlv2 =false;
				//Shop.sendBarrierlv3 =false;
				//Shop.sendBarrierlv4 =false;
				Shop.barrierSelected =false;
				//Shop.sendBarrier =false;
				Shop.drillSelected =false;
				//Shop.sendDrill =false;
				Shop.chargeSelected =false;
				Shop.sendCharge =false;
				//HeroPowers.ChargeSkill =false;
				//HeroPowers.DrillSkill =false;
				//Score.score =0;
				//Score.memory =0;
				//VitalsScript .MaxEnergy =3;
				//VitalsScript .MaxHealth =3;
				//Save(1);
				Application.Quit();
			}
			if (GUI.Button(new Rect(500, boxHeight - 120, 250, 90), "NO"))
			{
				ButtonSound.Play();
				confirmQuit = false;
			}
		}
		else
		{

			GUI.Label(new Rect(25, 25, 600, 200), "Spring Man: \nA Robot's Life");
			boxHeight = 600;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 299, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			if (GUI.Button(new Rect(100, 55, 800, 90), "START GAME"))
			{

				ButtonSound.Play();
				//PlayerPrefs .DeleteAll ();
				//System.Threading .Thread.Sleep (300);
				CheckPoint.CheckPointOne =false;
				CheckPoint.triggered =false;
				//Application.LoadLevel(1);

				if (Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend1"))) 
				{
					setStr0 =true;
					//Load(1);
					str[0]=PlayerPrefs.GetString ("UserName1");
				}
				else
				{
					setStr0=false;
					str[0]="EMPTY SLOT";
				}
				if(Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend2")))
				{
					setStr1=true;
					//Load (2);
					str[1]=PlayerPrefs.GetString ("UserName2");
				}
				else
				{
					setStr1=false;
					str[1]="EMPTY SLOT";
				}
				if(Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend3")))
				{
					setStr2=true;
					//Load (2);
					str[2]=PlayerPrefs.GetString ("UserName3");
				}
				else
				{
					setStr2=false;
					str[2]="EMPTY SLOT";
				}
				if(Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend4")))
				{
					setStr3=true;
					//Load (2);
					str[3]=PlayerPrefs.GetString ("UserName4");
				}
				else
				{
					setStr3=false;
					str[3]="EMPTY SLOT";
				}
				startgameselected =true;
				//cameracontrol .enabled=true;
				//iTween.MoveTo (GameObject.FindGameObjectWithTag ("MainCamera"), iTween.Hash ("x",GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>().position.x,"y",GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>().position.y,"time",1.8));
				//Invoke ("track",2f);
				//IsLevel=true;
				//IsOpen=false;
			}
			/*if(!Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend")))
			{
				GUI.enabled=false;
				GUI.Button (new Rect(100,188,800,90),"LOAD");
				GUI.enabled=true;
			}
			if(Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend")))
			{
				if (GUI.Button(new Rect(100, 188, 800, 90), "LOAD"))
				{

					ButtonSound.Play();
				//if(PlayerPrefs.GetString("saved")!=null)
				//{
					Score.score =0;
					Score.memory=PlayerPrefs.GetInt ("MemoryChips");
					VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth");
					VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy");
					Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend"));
					Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend"));
					Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send"));
					Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send"));
					Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send"));
					Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send"));
					Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send"));
					Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send"));
					Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send"));
					Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send"));
					Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send"));
					Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send"));
					Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send"));
					Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send"));
					Shop.sendBarrier=Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend"));
					Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel"));
				//}
				}
			}*/
			if (GUI.Button(new Rect(100,188 ,800, 90), "SETTINGS"))
			{
				ButtonSound.Play();
				settings = true;
			}
			if(GUI.Button (new Rect(100,321,800,90),"CREDITS"))
			{
				ButtonSound .Play ();
				showCredits=true;
			}
			if (GUI.Button(new Rect(100, 455, 800, 90), "QUIT GAME"))
			{
				ButtonSound.Play();
			

					confirmQuit = true;
			}
		}
		GUI.EndGroup ();
	}
	/*void track()
	{

		cameracontrol.trackX = true;
		cameracontrol.trackY = true;
		if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ().position.x == GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().position.x) 
		{
			player.enabled = true;
			player.GetComponentInChildren <HeroPowers >().enabled=false;
		}
	}*/

	private void GameMenu()
	{
			if(Application.loadedLevelName =="Level_Shop")
			{
				if(select1)
				{
					Save (1);
					PlayerPrefs.SetInt ("CurrentLevel1",LevelChangeScript.currentLevel +1);
				}
				if(select2)
				{
					Save (2);
					PlayerPrefs.SetInt ("CurrentLevel2",LevelChangeScript.currentLevel +1);
				}
				if(select3)
				{
					Save (3);
					PlayerPrefs.SetInt ("CurrentLevel3",LevelChangeScript.currentLevel +1);
				}
				if(select4)
				{
					Save (4);
					PlayerPrefs.SetInt ("CurrentLevel4",LevelChangeScript.currentLevel +1);
				}
				
			}

		if (Application.loadedLevelName != "Level_Shop"&&Application.loadedLevelName!="Level_0-1") 
		{
			GUI.Label (new Rect (1920 - 600, 50, 600, 700),Application.loadedLevelName+"\r"+ "\nENEMY KILLED: " + Score.score + "\r" + "\nMEMORY: " + Score.memory + " MB");
		}
		else 
			GUI.Label (new Rect (1920 - 600, 100, 600, 700), "ENEMY KILLED: " + Score.score + "\r" + "\nMEMORY: " + Score.memory + " MB");
		if (IsOpen)
		{
			if(Application.loadedLevelName =="Level_Shop")
			{

				s.enabled=false;
				//s.PowerUp =false;
				//s.SkillUp =false;
			}
			if(Application.loadedLevelName=="Level_Hospital")
			{
				H .enabled=false;
				//GameObject.Find ("EntireUI").gameObject .SetActive (false);
			}
			Time.timeScale = 0;
			int boxHeight, boxWidth;
			boxWidth =1000;
			if (settings)
			{
				SettingsMenu();
			}
			else if (confirmQuit)
			{
				boxHeight = 320;
				GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
				GUI.Box (new Rect (0,0,boxWidth,boxHeight), "");
				GUI.Label(new Rect(50, 50,800, 200), "ARE YOU SURE YOU WANT TO QUIT?");

				if (GUI.Button(new Rect(200, boxHeight - 120, 250, 90), "YES"))
				{
					ButtonSound.Play();
					System.Threading .Thread.Sleep (300);
					Shop.healthlv1Selected =false;
					Shop.healthlv2Selected =false;
					Shop.healthlv3Selected =false;
					Shop.healthlv4Selected =false;
					//Shop.sendHealthlv1 =false;
					//Shop.sendHealthlv2 =false;
					//Shop.sendHealthlv3 =false;
					//Shop.sendHealthlv4 =false;
					Shop.energylv1Selected =false;
					Shop.energylv2Selected =false;
					Shop.energylv3Selected =false;
					Shop.energylv4Selected =false;
					//Shop.sendEnergylv1 =false;
					//Shop.sendEnergylv2 =false;
					//Shop.sendEnergylv3 =false;
					//Shop.sendEnergylv4 =false;
					Shop.barrierlv1Selected =false;
					Shop.barrierlv2Selected =false;
					Shop.barrierlv3Selected =false;
					Shop.barrierlv4Selected =false;
					//Shop.sendBarrierlv1 =false;
					//Shop.sendBarrierlv2 =false;
					//Shop.sendBarrierlv3 =false;
					//Shop.sendBarrierlv4 =false;
					//Shop.sendBarrier =false;
					Shop.barrierSelected =false;
					Shop.drillSelected =false;
					//Shop.sendDrill =false;
					Shop.chargeSelected =false;
					//Shop.sendCharge =false;
					//HeroPowers.ChargeSkill =false;
					//HeroPowers.DrillSkill =false;
					//Score.score =0;
					//Score.memory =0;
					//VitalsScript .MaxEnergy =3;
					//VitalsScript .MaxHealth =3;
					if(Application.loadedLevelName!="Level_Shop"&&select1)
						Save (1);
					else if(Application.loadedLevelName!="Level_Shop"&&select2)
						Save (2);
					else if(Application.loadedLevelName!="Level_Shop"&&select3)
						Save (3);
					else if(Application.loadedLevelName!="Level_Shop"&&select4)
						Save (4);
					if(Application.loadedLevelName =="Level_Shop")
					{
						if(select1)
						{
							Save (1);

							PlayerPrefs.SetInt ("CurrentLevel1",LevelChangeScript.currentLevel +1);
						}
						if(select2)
						{
							Save (2);
							PlayerPrefs.SetInt ("CurrentLevel2",LevelChangeScript.currentLevel +1);
						}
						if(select3)
						{
							Save (3);
							PlayerPrefs.SetInt ("CurrentLevel3",LevelChangeScript.currentLevel +1);
						}
						if(select4)
						{
							Save (4);
							PlayerPrefs.SetInt ("CurrentLevel4",LevelChangeScript.currentLevel +1);
						}

					}
					Application.LoadLevel(0);
				}
				if (GUI.Button(new Rect(500, boxHeight - 120, 250, 90), "NO"))
				{
					ButtonSound.Play();

						confirmQuit = false;
				}
			}
			else
			{
				boxHeight = 600;
				GUI.BeginGroup (new Rect (1920 / 2 - 500,1080/ 2 - 299, 1000, boxHeight));
				GUI.Box (new Rect (0,0,1000,boxHeight), "");
				if(Application.loadedLevelName !="Level_Shop")
					GUI.Label (new Rect(100, 55, 800, 90),"COMPLETION"+"-"+Application.loadedLevel*100/(LevelChangeScript.levels.Count-1)+"%");
				if(Application.loadedLevelName=="Level_Shop")
					GUI.Label (new Rect(100, 55, 800, 90),"COMPLETION"+"-"+(LevelChangeScript.currentLevel+1)*100/(LevelChangeScript.levels.Count-1)+"%");
				if (GUI.Button(new Rect(100, 188, 800, 90), "RESUME"))
				{
					ButtonSound.Play();
					IsOpen = false;
                    Time.timeScale = gameSpeed;
					if(Application.loadedLevelName =="Level_Shop")
					{
						s.enabled=true;
						//s.PowerUp=true;
						//s.SkillUp =true;
					}
				}
				/*if(Application.loadedLevelName!="Level_Shop"&&Application.loadedLevelName!="Level_0-1")
				{
					if(GUI.Button(new Rect(100,188,800,90),"SAVE"))
			    	{
						ButtonSound.Play ();
						PlayerPrefs.SetInt ("CurrentLevel",Application.loadedLevel );
						//PlayerPrefs.SetInt ("Score",Score.score );
						PlayerPrefs.SetInt ("MemoryChips",player.GetLocalMemory ());
						PlayerPrefs.SetInt ("MaxHealth",VitalsScript .MaxHealth);
						PlayerPrefs.SetInt ("MaxEnergy",VitalsScript .MaxEnergy);
						PlayerPrefs.SetInt ("ChargeSkillSend",Convert.ToInt32(Shop.sendCharge));
						PlayerPrefs.SetInt ("DrillSkillSend",Convert.ToInt32 (Shop.sendDrill));
						PlayerPrefs.SetInt ("HealthLv1Send",Convert.ToInt32 (Shop.sendHealthlv1 ));
						PlayerPrefs.SetInt ("HealthLv2Send",Convert.ToInt32 (Shop.sendHealthlv2 ));
						PlayerPrefs.SetInt ("HealthLv3Send",Convert.ToInt32 (Shop.sendHealthlv3 ));
						PlayerPrefs.SetInt ("HealthLv4Send",Convert.ToInt32 (Shop.sendHealthlv4 ));
						PlayerPrefs.SetInt ("EnergyLv1Send",Convert.ToInt32 (Shop.sendEnergylv1 ));
						PlayerPrefs.SetInt ("EnergyLv2Send",Convert.ToInt32 (Shop.sendEnergylv2 ));
						PlayerPrefs.SetInt ("EnergyLv3Send",Convert.ToInt32 (Shop.sendEnergylv3 ));
						PlayerPrefs.SetInt ("EnergyLv4Send",Convert.ToInt32 (Shop.sendEnergylv4 ));
						PlayerPrefs.SetInt ("BarrierLv1Send",Convert.ToInt32 (Shop.sendBarrierlv1 ));
						PlayerPrefs.SetInt ("BarrierLv2Send",Convert.ToInt32 (Shop.sendBarrierlv2 ));
						PlayerPrefs.SetInt ("BarrierLv3Send",Convert.ToInt32 (Shop.sendBarrierlv3 ));
						PlayerPrefs.SetInt ("BarrierLv4Send",Convert.ToInt32 (Shop.sendBarrierlv4 ));
						PlayerPrefs.SetInt ("BarrierSend",Convert.ToInt32 (Shop.sendBarrier));
						PlayerPrefs.SetString ("saved", "AllReadySaved");
					}
				}
				if(Application.loadedLevelName =="Level_Shop"||Application.loadedLevelName=="Level_0-1")
				{

						GUI.enabled=false;
						GUI.Button (new Rect(100,188,800,90),"SAVE");
						GUI.enabled=true;

				}*/
				if (GUI.Button(new Rect(100, 321, 800,90), "SETTINGS"))
				{
					ButtonSound.Play();
					settings = true;
				}
				if (GUI.Button(new Rect(100,455, 800, 90), "QUIT TO MAIN MENU"))
				{
					ButtonSound.Play();

						confirmQuit = true;
				}
			}
			GUI.EndGroup ();
		}
		else
		{
			if (GUI.Button(new Rect(20-Shop.offset.x/Shop.guiScaleFactor   , 5-Shop.offset.y/Shop.guiScaleFactor  , 250, 90), "MENU"))
			{
				ButtonSound.Play();
				IsOpen = true;
			}
		}

	}

	private void SettingsMenu()
	{
		int boxHeight, boxWidth;
		if (!IsLevel)
			boxHeight = 600;
		else
			boxHeight = 600;
		boxWidth = 1000;
		GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 299, boxWidth, boxHeight));
		GUI.Box (new Rect (0, 0, boxWidth, boxHeight), "");
		if (GUI.Button(new Rect(35, 35, 250, 90), "BACK"))
		{
			ButtonSound.Play();
			settings = false;
		}
		AudioListener.volume = MenuScript.Volume;
		GUI.Label(new Rect(100, 260, 250, 90), "VOLUME: ");
		MenuScript.Volume = GUI.HorizontalSlider(new Rect (boxWidth - 400, 300, 250, 60), MenuScript.Volume, 0.0f, 1.0f);
    }
	void Save(int count)
	{
		if (count == 1) 
		{
			PlayerPrefs.SetInt ("CurrentLevel1",Application.loadedLevel );
			//PlayerPrefs.SetInt ("Score",Score.score );
			if(Application.loadedLevelName !="Level_Shop")
				PlayerPrefs.SetInt ("MemoryChips1",player.GetLocalMemory ());
			else 
				PlayerPrefs.SetInt ("MemoryChips1",Score.memory );
			PlayerPrefs.SetInt ("MaxHealth1",VitalsScript .MaxHealth);
			PlayerPrefs.SetInt ("MaxEnergy1",VitalsScript .MaxEnergy);
			PlayerPrefs.SetInt ("ChargeSkillSend1",Convert.ToInt32(Shop.sendCharge));
			PlayerPrefs.SetInt ("DrillSkillSend1",Convert.ToInt32 (Shop.sendDrill));
			PlayerPrefs.SetInt ("HealthLv1Send1",Convert.ToInt32 (Shop.sendHealthlv1 ));
			PlayerPrefs.SetInt ("HealthLv2Send1",Convert.ToInt32 (Shop.sendHealthlv2 ));
			PlayerPrefs.SetInt ("HealthLv3Send1",Convert.ToInt32 (Shop.sendHealthlv3 ));
			PlayerPrefs.SetInt ("HealthLv4Send1",Convert.ToInt32 (Shop.sendHealthlv4 ));
			PlayerPrefs.SetInt ("EnergyLv1Send1",Convert.ToInt32 (Shop.sendEnergylv1 ));
			PlayerPrefs.SetInt ("EnergyLv2Send1",Convert.ToInt32 (Shop.sendEnergylv2 ));
			PlayerPrefs.SetInt ("EnergyLv3Send1",Convert.ToInt32 (Shop.sendEnergylv3 ));
			PlayerPrefs.SetInt ("EnergyLv4Send1",Convert.ToInt32 (Shop.sendEnergylv4 ));
			PlayerPrefs.SetInt ("BarrierLv1Send1",Convert.ToInt32 (Shop.sendBarrierlv1 ));
			PlayerPrefs.SetInt ("BarrierLv2Send1",Convert.ToInt32 (Shop.sendBarrierlv2 ));
			PlayerPrefs.SetInt ("BarrierLv3Send1",Convert.ToInt32 (Shop.sendBarrierlv3 ));
			PlayerPrefs.SetInt ("BarrierLv4Send1",Convert.ToInt32 (Shop.sendBarrierlv4 ));
			PlayerPrefs.SetInt ("BarrierSend1",Convert.ToInt32 (Shop.sendBarrier));
			PlayerPrefs.SetString ("UserName1",str[0]);

		}
		if (count == 2) 
		{
			PlayerPrefs.SetInt ("CurrentLevel2",Application.loadedLevel );
			//PlayerPrefs.SetInt ("Score",Score.score );
			if(Application.loadedLevelName !="Level_Shop")
				PlayerPrefs.SetInt ("MemoryChips2",player.GetLocalMemory ());
			else 
				PlayerPrefs.SetInt ("MemoryChips2",Score.memory );
			PlayerPrefs.SetInt ("MaxHealth2",VitalsScript .MaxHealth);
			PlayerPrefs.SetInt ("MaxEnergy2",VitalsScript .MaxEnergy);
			PlayerPrefs.SetInt ("ChargeSkillSend2",Convert.ToInt32(Shop.sendCharge));
			PlayerPrefs.SetInt ("DrillSkillSend2",Convert.ToInt32 (Shop.sendDrill));
			PlayerPrefs.SetInt ("HealthLv1Send2",Convert.ToInt32 (Shop.sendHealthlv1 ));
			PlayerPrefs.SetInt ("HealthLv2Send2",Convert.ToInt32 (Shop.sendHealthlv2 ));
			PlayerPrefs.SetInt ("HealthLv3Send2",Convert.ToInt32 (Shop.sendHealthlv3 ));
			PlayerPrefs.SetInt ("HealthLv4Send2",Convert.ToInt32 (Shop.sendHealthlv4 ));
			PlayerPrefs.SetInt ("EnergyLv1Send2",Convert.ToInt32 (Shop.sendEnergylv1 ));
			PlayerPrefs.SetInt ("EnergyLv2Send2",Convert.ToInt32 (Shop.sendEnergylv2 ));
			PlayerPrefs.SetInt ("EnergyLv3Send2",Convert.ToInt32 (Shop.sendEnergylv3 ));
			PlayerPrefs.SetInt ("EnergyLv4Send2",Convert.ToInt32 (Shop.sendEnergylv4 ));
			PlayerPrefs.SetInt ("BarrierLv1Send2",Convert.ToInt32 (Shop.sendBarrierlv1 ));
			PlayerPrefs.SetInt ("BarrierLv2Send2",Convert.ToInt32 (Shop.sendBarrierlv2 ));
			PlayerPrefs.SetInt ("BarrierLv3Send2",Convert.ToInt32 (Shop.sendBarrierlv3 ));
			PlayerPrefs.SetInt ("BarrierLv4Send2",Convert.ToInt32 (Shop.sendBarrierlv4 ));
			PlayerPrefs.SetInt ("BarrierSend2",Convert.ToInt32 (Shop.sendBarrier));
			PlayerPrefs.SetString ("UserName2",str[1]);
		}
		if (count == 3) 
		{
			PlayerPrefs.SetInt ("CurrentLevel3",Application.loadedLevel );
			//PlayerPrefs.SetInt ("Score",Score.score );
			if(Application.loadedLevelName !="Level_Shop")
				PlayerPrefs.SetInt ("MemoryChips3",player.GetLocalMemory ());
			else 
				PlayerPrefs.SetInt ("MemoryChips3",Score.memory );
			PlayerPrefs.SetInt ("MaxHealth3",VitalsScript .MaxHealth);
			PlayerPrefs.SetInt ("MaxEnergy3",VitalsScript .MaxEnergy);
			PlayerPrefs.SetInt ("ChargeSkillSend3",Convert.ToInt32(Shop.sendCharge));
			PlayerPrefs.SetInt ("DrillSkillSend3",Convert.ToInt32 (Shop.sendDrill));
			PlayerPrefs.SetInt ("HealthLv1Send3",Convert.ToInt32 (Shop.sendHealthlv1 ));
			PlayerPrefs.SetInt ("HealthLv2Send3",Convert.ToInt32 (Shop.sendHealthlv2 ));
			PlayerPrefs.SetInt ("HealthLv3Send3",Convert.ToInt32 (Shop.sendHealthlv3 ));
			PlayerPrefs.SetInt ("HealthLv4Send3",Convert.ToInt32 (Shop.sendHealthlv4 ));
			PlayerPrefs.SetInt ("EnergyLv1Send3",Convert.ToInt32 (Shop.sendEnergylv1 ));
			PlayerPrefs.SetInt ("EnergyLv2Send3",Convert.ToInt32 (Shop.sendEnergylv2 ));
			PlayerPrefs.SetInt ("EnergyLv3Send3",Convert.ToInt32 (Shop.sendEnergylv3 ));
			PlayerPrefs.SetInt ("EnergyLv4Send3",Convert.ToInt32 (Shop.sendEnergylv4 ));
			PlayerPrefs.SetInt ("BarrierLv1Send3",Convert.ToInt32 (Shop.sendBarrierlv1 ));
			PlayerPrefs.SetInt ("BarrierLv2Send3",Convert.ToInt32 (Shop.sendBarrierlv2 ));
			PlayerPrefs.SetInt ("BarrierLv3Send3",Convert.ToInt32 (Shop.sendBarrierlv3 ));
			PlayerPrefs.SetInt ("BarrierLv4Send3",Convert.ToInt32 (Shop.sendBarrierlv4 ));
			PlayerPrefs.SetInt ("BarrierSend3",Convert.ToInt32 (Shop.sendBarrier));
			PlayerPrefs.SetString ("UserName3",str[2]);
		}
		if (count == 4) 
		{
			PlayerPrefs.SetInt ("CurrentLevel4",Application.loadedLevel );
			//PlayerPrefs.SetInt ("Score",Score.score );
			if(Application.loadedLevelName !="Level_Shop")
				PlayerPrefs.SetInt ("MemoryChips4",player.GetLocalMemory ());
			else 
				PlayerPrefs.SetInt ("MemoryChips4",Score.memory );
			PlayerPrefs.SetInt ("MaxHealth4",VitalsScript .MaxHealth);
			PlayerPrefs.SetInt ("MaxEnergy4",VitalsScript .MaxEnergy);
			PlayerPrefs.SetInt ("ChargeSkillSend4",Convert.ToInt32(Shop.sendCharge));
			PlayerPrefs.SetInt ("DrillSkillSend4",Convert.ToInt32 (Shop.sendDrill));
			PlayerPrefs.SetInt ("HealthLv1Send4",Convert.ToInt32 (Shop.sendHealthlv1 ));
			PlayerPrefs.SetInt ("HealthLv2Send4",Convert.ToInt32 (Shop.sendHealthlv2 ));
			PlayerPrefs.SetInt ("HealthLv3Send4",Convert.ToInt32 (Shop.sendHealthlv3 ));
			PlayerPrefs.SetInt ("HealthLv4Send4",Convert.ToInt32 (Shop.sendHealthlv4 ));
			PlayerPrefs.SetInt ("EnergyLv1Send4",Convert.ToInt32 (Shop.sendEnergylv1 ));
			PlayerPrefs.SetInt ("EnergyLv2Send4",Convert.ToInt32 (Shop.sendEnergylv2 ));
			PlayerPrefs.SetInt ("EnergyLv3Send4",Convert.ToInt32 (Shop.sendEnergylv3 ));
			PlayerPrefs.SetInt ("EnergyLv4Send4",Convert.ToInt32 (Shop.sendEnergylv4 ));
			PlayerPrefs.SetInt ("BarrierLv1Send4",Convert.ToInt32 (Shop.sendBarrierlv1 ));
			PlayerPrefs.SetInt ("BarrierLv2Send4",Convert.ToInt32 (Shop.sendBarrierlv2 ));
			PlayerPrefs.SetInt ("BarrierLv3Send4",Convert.ToInt32 (Shop.sendBarrierlv3 ));
			PlayerPrefs.SetInt ("BarrierLv4Send4",Convert.ToInt32 (Shop.sendBarrierlv4 ));
			PlayerPrefs.SetInt ("BarrierSend4",Convert.ToInt32 (Shop.sendBarrier));
			PlayerPrefs.SetString ("UserName4",str[3]);
		}
	}
	void Load(int count)
	{
		if (count == 1) 
		{
			Score.score =0;
			Score.memory=PlayerPrefs.GetInt ("MemoryChips1");
			VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth1");
			VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy1");
			Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend1"));
			Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend1"));
			Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send1"));
			Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send1"));
			Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send1"));
			Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send1"));
			Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send1"));
			Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send1"));
			Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send1"));
			Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send1"));
			Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send1"));
			Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send1"));
			Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send1"));
			Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send1"));
			Shop.sendBarrier=Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend1"));
			str[0]=PlayerPrefs.GetString ("UserName1");
			HeroPowers .BarrierSkill =Shop.sendBarrier ;
			HeroPowers.ChargeSkill =Shop.sendCharge ;
			HeroPowers.DrillSkill =Shop.sendDrill ;
			//Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel1"));
		}
		if (count == 2) 
		{
			Score.score =0;
			Score.memory=PlayerPrefs.GetInt ("MemoryChips2");
			VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth2");
			VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy2");
			Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend2"));
			Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend2"));
			Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send2"));
			Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send2"));
			Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send2"));
			Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send2"));
			Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send2"));
			Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send2"));
			Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send2"));
			Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send2"));
			Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send2"));
			Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send2"));
			Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send2"));
			Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send2"));
			Shop.sendBarrier=Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend2"));
			str[1]=PlayerPrefs.GetString ("UserName2");
			HeroPowers .BarrierSkill =Shop.sendBarrier ;
			HeroPowers.ChargeSkill =Shop.sendCharge ;
			HeroPowers.DrillSkill =Shop.sendDrill ;
		}
		if (count == 3) 
		{
			Score.score =0;
			Score.memory=PlayerPrefs.GetInt ("MemoryChips3");
			VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth3");
			VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy3");
			Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend3"));
			Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend3"));
			Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send3"));
			Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send3"));
			Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send3"));
			Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send3"));
			Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send3"));
			Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send3"));
			Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send3"));
			Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send3"));
			Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send3"));
			Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send3"));
			Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send3"));
			Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send3"));
			Shop.sendBarrier=Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend3"));
			str[2]=PlayerPrefs.GetString ("UserName3");
			HeroPowers .BarrierSkill =Shop.sendBarrier ;
			HeroPowers.ChargeSkill =Shop.sendCharge ;
			HeroPowers.DrillSkill =Shop.sendDrill ;
		}
		if (count == 4) 
		{
			Score.score =0;
			Score.memory=PlayerPrefs.GetInt ("MemoryChips4");
			VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth4");
			VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy4");
			Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend4"));
			Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend4"));
			Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send4"));
			Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send4"));
			Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send4"));
			Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send4"));
			Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send4"));
			Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send4"));
			Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send4"));
			Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send4"));
			Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send4"));
			Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send4"));
			Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send4"));
			Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send4"));
			Shop.sendBarrier=Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierSend4"));
			str[3]=PlayerPrefs.GetString ("UserName4");
			HeroPowers .BarrierSkill =Shop.sendBarrier ;
			HeroPowers.ChargeSkill =Shop.sendCharge ;
			HeroPowers.DrillSkill =Shop.sendDrill ;
		}
	}
	void SetToBegin()
	{
		Shop.healthlv1Selected =false;
		Shop.healthlv2Selected =false;
		Shop.healthlv3Selected =false;
		Shop.healthlv4Selected =false;
		Shop.sendHealthlv1 =false;
		Shop.sendHealthlv2 =false;
		Shop.sendHealthlv3 =false;
		Shop.sendHealthlv4 =false;
		Shop.energylv1Selected =false;
		Shop.energylv2Selected =false;
		Shop.energylv3Selected =false;
		Shop.energylv4Selected =false;
		Shop.sendEnergylv1 =false;
		Shop.sendEnergylv2 =false;
		Shop.sendEnergylv3 =false;
		Shop.sendEnergylv4 =false;
		Shop.barrierlv1Selected =false;
		Shop.barrierlv2Selected =false;
		Shop.barrierlv3Selected =false;
		Shop.barrierlv4Selected =false;
		Shop.sendBarrierlv1 =false;
		Shop.sendBarrierlv2 =false;
		Shop.sendBarrierlv3 =false;
		Shop.sendBarrierlv4 =false;
		Shop.barrierSelected =false;
		Shop.sendBarrier =false;
		Shop.drillSelected =false;
		Shop.sendDrill =false;
		Shop.chargeSelected =false;
		Shop.sendCharge =false;
		HeroPowers.ChargeSkill =false;
		HeroPowers.DrillSkill =false;
		HeroPowers.BarrierSkill = false;
		Score.score =0;
		Score.memory =0;
		VitalsScript .MaxEnergy =3;
		VitalsScript .MaxHealth =3;
	}


}

