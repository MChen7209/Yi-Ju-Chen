using UnityEngine;
using System.Collections;

public class ShowEnemyPosition : MonoBehaviour {

	public GameObject Arrow;
	public GameObject[] Enemy;



	// Use this for initialization
	void Start () {
		Enemy = GameObject.FindGameObjectsWithTag ("Enemy");
	

	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector2 (this.gameObject.transform.position.x, Camera.main.transform.position.y - 10f);
		for (int i=0;i<Enemy.Length ;i++) 
		{
			if(Enemy[i]!=null)
			{
				if ((this.gameObject.transform.position.y - Enemy[i].transform.position.y < 10f)&&(this.gameObject.transform.position.y - Enemy[i].transform.position.y > 0f)&&!Enemy[i].gameObject.GetComponent<EnemyScript>().dead)
				{
					Instantiate (Arrow, new Vector3 (Enemy[i].transform.position.x, this.gameObject.transform.position.y, 1f), Quaternion.Euler (new Vector3 (0, 0,270)));
				
					Enemy[i]=null;
				}
			}

		}
	}
}
