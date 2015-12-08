using UnityEngine;
using System.Collections;

public class LightingControl : MonoBehaviour {
	private int increaseNum;

	// Use this for initialization
	void Start () {
		increaseNum=0;

		this.gameObject.light.intensity = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Invoke ("lightingIncrease", 1.5f);
//	
	}
	void lightingIncrease()
	{
		CancelInvoke ();
		increaseNum++;
		this.gameObject.light.intensity += 0.01f;
		if (increaseNum < 40)
						Invoke ("lightingIncrease", 0.01f);
				else
						Invoke ("lightingDecrease", 0.5f);

	}
	void lightingDecrease()
	{
		CancelInvoke ();

		this.gameObject.light.intensity -= 0.01f;
		if (this.gameObject.light.intensity > 0)
						Invoke ("lightingDecrease", 0.01f);
		else
		{
						increaseNum=0;
						Invoke ("lightingIncrease", 1.5f);
		}

	}
}
