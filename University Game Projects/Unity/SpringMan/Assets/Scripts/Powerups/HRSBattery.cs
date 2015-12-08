using UnityEngine;
using System.Collections;

public class HRSBattery : MonoBehaviour 
{
	public int addEnergy = 1;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "HeatResistantSuit")
			VitalsScript.CurrentEnergy += 1;

	}
}
