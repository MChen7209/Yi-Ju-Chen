using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	public GameObject barrier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void CallBarrier()
	{
		Instantiate (barrier, new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.Euler (new Vector3 (0, 0, 0)));
	}
}
