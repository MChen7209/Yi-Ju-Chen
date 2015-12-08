using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {
	float meteorDistance;
    float playerDistance;
    float startDistance;
	Transform player;
	Transform meteor;
    Transform door;
	GUITexture tinyMeteor;
    GUITexture tinyCog;
	GUITexture bar;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		meteor = GameObject.FindGameObjectWithTag("Meteor").transform;
        door = GameObject.FindGameObjectWithTag("Doorway").transform;
		tinyMeteor = GameObject.Find("tinymeteor").GetComponent<GUITexture>();
        tinyCog = GameObject.Find("tinycog").GetComponent<GUITexture>();
		bar = GameObject.Find("bar").GetComponent<GUITexture>();
        startDistance = player.position.y - door.position.y;
	}

	// Update is called once per frame
	void Update () {
        if (!HeroController.GameOver)
        {
            meteorDistance = meteor.position.y - door.position.y - 30;
            playerDistance = player.position.y - door.position.y;
        }
        if (meteorDistance > startDistance)
            tinyMeteor.enabled = false;
        else
            tinyMeteor.enabled = true;
        tinyMeteor.transform.position = new Vector2(tinyMeteor.transform.position.x, GetDistance(meteorDistance));
        tinyCog.transform.position = new Vector2(tinyCog.transform.position.x, GetDistance(playerDistance));
	}

    //Gets the normalized distance between the door and the object to display it on the bar.
    float GetDistance(float pos)
    {
        return pos / startDistance / 2 + .2f;
    }
}
