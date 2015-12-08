using UnityEngine;
using System.Collections;

public class backgroundrepeat : MonoBehaviour {
	public Transform cameraTransform;
	public float spriteWidth;
	//Vector3 oldPos;
	// Use this for initialization
	void Start () {
		cameraTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.y;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (((-transform.position.y + spriteWidth) < -cameraTransform.position.y)&&GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y<0) {
			//Vector3 oldPos=transform.position;
			Vector3 newPos = transform.position;
			newPos.y += -2.0f * spriteWidth;
			transform.position = newPos;
		}
		if (((-transform.position.y - spriteWidth)> -cameraTransform.position.y)&&GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y > 0) 
		{
			Vector3 newPos=transform.position;
			newPos.y-=-2.0f*spriteWidth;
			transform.position=newPos;
		}

}
}