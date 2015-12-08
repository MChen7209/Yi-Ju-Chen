using UnityEngine; 
using System.Collections; 
public class GUITextureScaler : MonoBehaviour 
{ 
	float screenWidth = Screen.width;
	float screenHeight = Screen.height;
	float OriginalScaledX;
	float OriginalScaledY;
	float OriginalScaledWidth;
	float OriginalScaledHeight;
	// Use this for initialization 
	void Awake()
	{
		OriginalScaledX = gameObject.guiTexture.pixelInset.x;
		OriginalScaledY = gameObject.guiTexture.pixelInset.y;
		OriginalScaledWidth = gameObject.guiTexture.pixelInset.width;
		OriginalScaledHeight = gameObject.guiTexture.pixelInset.height;
	}
	void  Start() 
	{ 
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		GlobalDefine.init(); 

		if(gameObject. guiTexture) 
		{ 
			//Debug.Log(GlobalDefine.screenScale.x); 
			float scaledX = OriginalScaledX *GlobalDefine.screenScale.x; 
			float scaledY =  OriginalScaledY* GlobalDefine.screenScale.y; 
			float scaledWidth =  OriginalScaledWidth  * GlobalDefine.screenScale.x; 
			float scaledHeight =  OriginalScaledHeight *GlobalDefine.screenScale.y; 
			
			gameObject.guiTexture.pixelInset = new Rect(scaledX, scaledY, scaledWidth, scaledHeight); 
		} 


	} 
	void Update()
	{
		if (screenWidth != Screen.width || screenHeight != Screen.height)
						Resize ();

	}
	void Resize()
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		GlobalDefine.init(); 
		
		if(gameObject. guiTexture) 
		{ 
			//Debug.Log(GlobalDefine.screenScale.x); 
			float scaledX = OriginalScaledX *GlobalDefine.screenScale.x; 
			float scaledY =  OriginalScaledY* GlobalDefine.screenScale.y; 
			float scaledWidth =  OriginalScaledWidth  * GlobalDefine.screenScale.x; 
			float scaledHeight =  OriginalScaledHeight *GlobalDefine.screenScale.y; 
			
			gameObject.guiTexture.pixelInset = new Rect(scaledX, scaledY, scaledWidth, scaledHeight); 
		} 
	}

	
} 


public class GlobalDefine 
{ 
	public  const float STANDARD_SCREEN_WIDTH = 1920f; 
	public  const float STANDARD_SCREEN_HEIGHT = 1080f;
	public static Vector2 screenScale; 
	
	public static void init() 
	{ 
		screenScale.x = Screen.width / STANDARD_SCREEN_WIDTH; 
		screenScale.y = Screen.height / STANDARD_SCREEN_HEIGHT; 
	} 
} 