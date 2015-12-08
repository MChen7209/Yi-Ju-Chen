using UnityEngine;
using System.Collections.Generic;

public class CogTurn : MonoBehaviour
{

    private float time = 0;
    float native_width = 1920;
    float native_height = 1080;
    VitalsScript player;
    GUITexture[] textures;


    // Use this for initialization
    void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>().Vitals;
        textures = this.gameObject.GetComponentsInChildren<GUITexture>() as GUITexture[];
	
    }

    void FixedUpdate()
    {
        time += Time.deltaTime / 4;
    }

    void OnGUI()
    {

       
       // float rx = Screen.width / native_width;
       // float ry = Screen.height / native_height;
		//Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        DrawHealth();

    }

    void DrawHealth()
    {
        if (VitalsScript .CurrentHealth >= 7 )
        {
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.35f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.35f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[6].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.35f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));  
        }
		if (VitalsScript .CurrentHealth>= 6)
        {
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.3f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.3f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[5].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.3f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));   
        }
		if (VitalsScript .CurrentHealth>= 5)
        {
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.25f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.25f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[4].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.25f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));  
        }
		if (VitalsScript .CurrentHealth >= 4 )
        {
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.2f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.2f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[3].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.2f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));   
        }
		if (VitalsScript .CurrentHealth >= 3 )
        {
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.15f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.15f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[2].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.15f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));  
        }
		if (VitalsScript .CurrentHealth>= 2)
        {
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.1f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.1f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[1].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.1f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));  
        }
		if (VitalsScript .CurrentHealth >= 1 )
        {
			GUIUtility.RotateAroundPivot(-300 * time, new Vector2(0.05f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080 ));  
			GUI.DrawTexture(new Rect(0.05f*1920*Screen.width/1920-52f*Screen.width/1920, 0.135f*1080*Screen.height /1080-52f*Screen.height /1080, 104f*Screen.width/1920, 104f*Screen.height /1080), textures[0].texture, ScaleMode.ScaleToFit);
			GUIUtility.RotateAroundPivot(300 * time, new Vector2(0.05f*1920*Screen.width/1920 , 0.135f*1080*Screen.height /1080));  
        }

    }
}
