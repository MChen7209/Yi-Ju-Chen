using UnityEngine;
using System.Collections;

public class MemoryChips : MonoBehaviour {
	public GameObject[] Chips;
	private bool[] alreadyRed;
	private bool allRed;
	public AudioSource chipssound;
	public AudioSource chipfinish;
	private bool inGroup;
	public GameObject Points;
	private GameObject player;
	private int lastchip;
	private int truenumber;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		allRed = false;
		lastchip = -1;
		inGroup = false;
		truenumber = Chips.Length;
		if(Chips!=null)
			alreadyRed=new bool[Chips.Length ];

	}
	
	// Update is called once per frame
	void Update () {
		if (Chips != null && !allRed && !HeroController .GameOver ) 
		{
			for (int i=0; i<Chips.Length; i++) 
			{

				if (Chips [i].GetComponent<MemoryPickUp> ().color.GetComponent<SpriteRenderer > ().color == Color.red&&!alreadyRed[i]) 
				{
					alreadyRed [i] = true;
					truenumber--;
					chipssound.Play ();
					inGroup=true;

				}
				if(inGroup&&Chips [i].GetComponent<MemoryPickUp> ().color.GetComponent<SpriteRenderer > ().color != Color.red)
				{
					Chips [i].GetComponent<MemoryPickUp> ().color.GetComponent<SpriteRenderer > ().color =Color.blue;
					iTween.ShakePosition(Chips[i],new Vector3(0.3f,0.3f,0),1.5f);
					if(truenumber==1)
						lastchip=i;

				}

			}
			
			for(int i=0;i<Chips.Length;i++)
			{
				if(i==0)
					allRed =true&&alreadyRed [i];
				else
					allRed=allRed&&alreadyRed[i];


			}
	
		}
		if (allRed&&Chips!=null&&!HeroController .GameOver ) 
		{
			chipfinish .Play ();


			if(Chips.Length >1)
			{
				Instantiate (Points,new Vector3(Chips[lastchip].transform.position.x,Chips[lastchip].transform.position.y+2f,Chips[lastchip].transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));


				Score.memory +=5;
			}
			for(int i=0;i<Chips.Length;i++)
			{
				Destroy(Chips[i]);
				
			}
			Chips=null;

		}
	}

}
