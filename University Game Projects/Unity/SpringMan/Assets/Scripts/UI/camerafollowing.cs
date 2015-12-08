using UnityEngine;
using System.Collections;

public class camerafollowing : MonoBehaviour
{
    public bool trackX = false;
    public bool trackY = true;
    public bool fallingOnly = false;
    private float lastY;

    private Transform player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastY = player.transform.position.y;
    }
	
    // Update is called once per frame
    void Update()
    {
        float x, y;
        if (trackX)
            x = player.transform.position.x;
        else
            x = transform.position.x;
        if (fallingOnly && trackY)
        {
            y = (player.transform.position.y < lastY) ? player.transform.position.y : lastY;
            lastY = y + 1;
        }
        else if (trackY)
            y = player.transform.position.y;
        else
            y = transform.position.y;

        if (!HeroController.GameOver)
            transform.position = new Vector3(x, y, transform.position.z);
        //Have camera follow Player on Y axis, but stop at walls. Skybox is brown in case of bugs.

    }

    public void StopTrack()
    {
        trackX = false;
        trackY = false;
    }
	public void BossCamera(){
		var bossCamera = GameObject.Find ("BossCameraPosition");
		float x, y;
		float smoothness = 1f;

		trackX = false;
		trackY = false;
		x = bossCamera.transform.position.x;
		y = bossCamera.transform.position.y;
		if(!HeroController .GameOver)
			transform.position = Vector3.Lerp (transform.position, new Vector3 (x, y, transform.position.z), smoothness);
	}
    void OnGUI()
    {

    }

	public void screenShake(float intensity, float duration)
	{
//		if(intensity > 0)
//		{
//			Vector3 position = transform.position;
//			transform.localPosition = Random.insideUnitCircle * intensity;
//			intensity -= Time.deltaTime * decreaseBy;
//		}
		iTween.ShakePosition(gameObject,new Vector3(intensity,intensity,0),duration);
	}
}
