using UnityEngine;
using System.Collections;

public class HRSTimeShift : MonoBehaviour 
{
	public int timeShiftAmount;
	public bool destructable = true;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "HeatResistantSuit")
		{
			GameObject.FindGameObjectWithTag("HeatResistantSuit").GetComponent<HeatResistantSuit>().changeTime(timeShiftAmount);
			if(destructable)
				Destroy(gameObject);
		}
	}
}
