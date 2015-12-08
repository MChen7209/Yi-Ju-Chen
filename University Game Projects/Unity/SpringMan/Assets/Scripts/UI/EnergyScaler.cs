using UnityEngine;
using System.Collections;

public class EnergyScaler : MonoBehaviour {

	GUITexture[] textures;
	VitalsScript player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>().Vitals;
		textures = GetComponentsInChildren<GUITexture>();
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		//Shop.BeginUIResizing ();
		if (player == null)
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>().Vitals;
		DrawEnergy ();
		//Shop.EndUIResizing ();
	}
	void DrawEnergy()
	{
		if (VitalsScript .MaxEnergy >= 7 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(0.3f * Screen.width - 32f, Screen.height * 0.1f - 32f, 64f, 64f), textures[6].texture, ScaleMode.ScaleToFit);

		}
		if (VitalsScript .MaxEnergy >= 6 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(0.3f * Screen.width - 32f, Screen.height * 0.1f - 32f, 64f, 64f), textures[5].texture, ScaleMode.ScaleToFit);
			 
		}
		if (VitalsScript .MaxEnergy >= 5 && !player.Dead)
		{ 
			GUI.DrawTexture(new Rect(0.25f * Screen.width - 32f, Screen.height * 0.1f - 32f, 64f, 64f), textures[4].texture, ScaleMode.ScaleToFit);

		}
		if (VitalsScript .MaxEnergy >= 4 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(0.2f * Screen.width - 32f, Screen.height * 0.1f - 32f, 64f, 64f), textures[3].texture, ScaleMode.ScaleToFit);
		
		}
		if (VitalsScript .MaxEnergy >= 3 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(288f - 32f, 108f - 32f, 64f, 64f), textures[2].texture, ScaleMode.ScaleToFit);

		}
		if (VitalsScript .MaxEnergy >= 2 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(192f - 32f, 108f - 32f, 64f, 64f), textures[1].texture, ScaleMode.ScaleToFit);

		}
		if (VitalsScript .MaxEnergy >= 1 && !player.Dead)
		{

			GUI.DrawTexture(new Rect(96f -32, 200f , 64f, 64f), textures[0].texture  , ScaleMode.ScaleToFit);

		}
	
	}
}
