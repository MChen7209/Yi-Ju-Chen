using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

    public VitalsScript vitals; //current progress
    public Vector2 pos = new Vector2(20,40);
    public Vector2 size = new Vector2(60,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
	// Use this for initialization
	void Start () {
	}
	
    void OnGUI()
    {
        if (vitals == null)
            vitals = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>().Vitals;

        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0,0, size.x * VitalsScript .CurrentEnergy, size.y));
                GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
            GUI.EndGroup();
        GUI.EndGroup();
    }
}
