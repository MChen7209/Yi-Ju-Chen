using UnityEngine;
using System.Collections.Generic ;

public class ArrowPosition : MonoBehaviour {


	public int EnemyNum;
	private GameObject[] Arrow;
	private GameObject[] Enemy;
	private bool[] EnemyMarked;



	// Use this for initialization
	void Start () {

		Enemy=GameObject.FindGameObjectsWithTag ("Enemy");
		EnemyMarked = new bool[Enemy.Length ];
		Arrow = GameObject.FindGameObjectsWithTag ("Arrow");


		for (int i=0; i<Enemy.Length; i++)
		{
			for (int j=0; j<Arrow.Length; j++)
			{
				if(Arrow[j].GetComponent<ArrowPosition>().EnemyNum ==i)
				{
					EnemyMarked[i]=true;
				 }
			}
			if (Enemy [i] != null&&!EnemyMarked[i])//&&!//EnemyMarked[i])
			{

				if (this.gameObject.transform.position.y - Enemy [i].transform.position.y < 20f && Mathf.Abs (this.gameObject.transform.position.x - Enemy [i].transform.position.x) == 0f) 
				{
					EnemyNum = i;

					//EnemyMarked[i]=true;

			    }
		    }
		}
	
	}



	
	// Update is called once per frame
	void Update () {

		if (Enemy [EnemyNum] != null) 
		{
			this.gameObject.transform.position = new Vector2 (Enemy [EnemyNum].transform.position.x, GameObject.Find ("ArrowProduce").GetComponent<Transform> ().position.y);
			if(this.gameObject.transform.position.y - Enemy [EnemyNum].transform.position.y <= 3f)
				Destroy (this.gameObject);
		}



		
	}

}
