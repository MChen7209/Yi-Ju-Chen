using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hospital : MonoBehaviour {

	private string currentword;
	public List<Color> primaryColors;
	public List<Color> secondaryColors;
	public List <Texture2D> skillsTextures;
	private bool hasUpdatedGui = false;
	private GUIText scorecolor;
	private int ColorRepeat;
	private int buttonHeight=40;
	private int scoreCost=0;
	private bool sendSuccess=false;
	private string word;
	public AudioSource ButtonSound;
	public AudioSource TypeSound;
	public Texture2D shopBackground;
	private bool selectHealth;
	private bool selectEnergy;
	private HeroController player;
	private VitalsScript vital;

	// Use this for initialization
	void Start () {

		//Score.memory = 110;
		Score.score = 100;
		vital = new VitalsScript ();

		
		ColorRepeat = 3;
		scorecolor = GameObject.Find ("Score").GetComponent<GUIText> ();
	}

	
	// Update is called once per frame
	void Update () {
	
		if (player != null)
						player.enabled = false;
	}
	void OnGUI()
	{
		Shop.BeginUIResizing ();
		if (!hasUpdatedGui)
		{
			ColoredGUISkin.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
			hasUpdatedGui = true;
		}
		GUI.skin = ColoredGUISkin.Skin;
		GUI.skin.button.fontSize=64;
		
		GUI.DrawTexture (new Rect (-50, 0, 2100, 1500), shopBackground);
		
		
		//GUI.enabled = false;
		GUI.BeginGroup(new Rect(1920 /9-50, 1080/ 2 - 245,800, 1000));
		
		GUI.Box(new Rect(0, 0, 600, 330), "");
		
		
		GUI.skin.label.fontSize = 64;
		if (currentword!=null ) 
		{
			
			GUI.Label (new Rect (35, 35, 600-35, 300 ), currentword);
			if(currentword.IndexOf ("\r")==currentword.Length-1)
			{
				
				if(GUI.Button (new Rect(130,240,220,75),"SEND"))
				{
					ButtonSound .Play();
					Debug.Log (scoreCost );
					
					if(Score.memory-scoreCost>=0)
					{


						sendSuccess=true;

						currentword=null;
						if(selectHealth&&VitalsScript .CurrentHealth <VitalsScript .MaxHealth )
						{
							Score.memory-=scoreCost;
							VitalsScript .CurrentHealth ++;
							scoreCost =0;
							selectHealth=false;
						}
						if(selectHealth&&VitalsScript .CurrentHealth==VitalsScript .MaxHealth)
						{
							StopAllCoroutines ();
							StartCoroutine (TypeWritter ("CURRENT HEALTH IS FULL\n\r"));
							
							ButtonSound .Play();
						}

						 if(selectEnergy&&VitalsScript .CurrentEnergy <VitalsScript .MaxEnergy )
						{
							Score.memory-=scoreCost;
							selectEnergy =false;
							scoreCost =0;
							VitalsScript .CurrentEnergy ++;
						}
						if(selectEnergy&&VitalsScript.CurrentEnergy ==VitalsScript.MaxEnergy) 
						{
							StopAllCoroutines ();
							StartCoroutine (TypeWritter ("CURRENT ENERGY IS FULL\n\r"));

							ButtonSound .Play();
						}
					}
					else
						NoScore();


				}
				sendSuccess =false;
					
					

				if(GUI.Button (new Rect(360,240,220,75),"CANCEL"))
				{
					ButtonSound .Play();
					selectHealth =false;
					selectEnergy=false;
					currentword=null;
					
					
				}
			}
		}	
		GUI.EndGroup();
		
		
		GUI.Window (0,new Rect(1920 / 2+300 , 1080 / 2 - 250,600,415),DoMyWindow,"SUPPLIES");
		GUI.skin.window.fontSize=64;
		if (GUI.Button(new Rect(1920*2 / 3+100 , 1080 - 200+Shop.offset.y/Shop.guiScaleFactor,400 , 150), "CONTINUE"))
		{
			ButtonSound .Play();
			System.Threading .Thread.Sleep (300);
			LevelChangeScript.NextLevel();
			
		}
		vital.HandleEnergy ();
		Shop.EndUIResizing ();
		if (Score.score != 0) 
		{
			StartCoroutine(ScoreToMemory());
		}

	}
	IEnumerator  ScoreToMemory()
	{
		float time = 1f;
		while (Score.score!=0) 
		{
			Score.score--;
			Score.memory +=10;
			yield return new WaitForSeconds (time);

		}

	}
	void DoMyWindow(int windowID)
	{
		GUI.skin.button.fontSize = 64;
		if (windowID == 0) 
		{
			if(!selectHealth)
			{
				if (GUI.Button (new Rect (10, 60, 580, 75), "HEALTH+1") && currentword == null) 
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("CURRENT HEALTH+1 COST: 10MB\n\r"));
					selectHealth= true;
					scoreCost = 10;
					ButtonSound .Play();
				}
			}
			if(selectHealth&&!sendSuccess )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"HEALTH+1");
				GUI.enabled=true;
			}
			if(!selectEnergy )
			{
				if (GUI.Button (new Rect (10, 140, 580, 75), "ENERGY+1") && currentword == null) 
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("CURRENT ENERGY+1 COST: 10MB\n\r"));
					selectEnergy= true;
					scoreCost = 10;
					ButtonSound .Play();
				}
			}
			if(selectEnergy&&!sendSuccess )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY+1");
				GUI.enabled=true;
			}
		}
	}
	void NoScore()
	{
		
		scorecolor.color = Color.red;
		
		InvokeRepeating ("ChangeColor", 0.1f,0.3f);
		
	}
	void ChangeColor()
	{
		if (ColorRepeat % 2 == 0)
			scorecolor .color = Color.white;
		else
			scorecolor .color = Color.red;
		
		if (ColorRepeat == 0) 
		{
			CancelInvoke ();
			ColorRepeat =4;
		}
		ColorRepeat--;
	}

	IEnumerator  TypeWritter(string text)
	{
		
		currentword = "";
		float time=0.1f;
		TypeSound.Play ();
		foreach (var letter in text.ToCharArray ())
		{
			//TypeSound.Play();
			currentword +=letter;
			
			if(Input.GetMouseButton(0) )
			{
				time=0.01f;
			}				
			yield return new WaitForSeconds (time);
		}
		TypeSound .Stop ();
	}


}

