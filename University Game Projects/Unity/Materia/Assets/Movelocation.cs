using UnityEngine;
using System.Collections;

public class Movelocation : MonoBehaviour 
{
	public string location;
	// Use this for initialization
	void Start () 
	{
		renderer.sortingLayerName = location;
	}
}
