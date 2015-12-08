using UnityEngine;
using System.Collections.Generic;
using System.Linq;

	public class backgroundrolling : MonoBehaviour
	{
	public Vector3 movement;
		/// <summary>
		/// Scrolling speed
		/// </summary>
	public Vector2 speed = new Vector2(2, 2);
		
		/// <summary>
		/// Moving direction
		/// </summary>
		public Vector2 direction = new Vector2(0, -1);
		
		/// <summary>
		/// Movement should be applied to camera
		/// </summary>
		public bool isLinkedToCamera = false;
	public bool isLooping=false;
	private List<Transform> backgroundPart;
		
	void Start()
	{
		if (isLooping) 
		{
			backgroundPart=new List<Transform>();
			for(int i=0;i<transform.childCount;i++)
			{
				Transform child=transform.GetChild (i);
				if(child.renderer!=null)
				{
					backgroundPart.Add(child);
				}
			}
			backgroundPart=backgroundPart.OrderBy(t=>t.position.y).ToList();
		}
	}
		void Update()
		{
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity==new Vector2(0,0))
			movement=new Vector3(0,0,0);
		else{
			// Movement
			 movement = new Vector3(
				speed.x * direction.x,
				GameObject.FindGameObjectWithTag("Player").GetComponent<FallingdownSpeed>().fallingdownspeed * direction.y,
				0);
		}
			movement *= Time.deltaTime;
			transform.Translate(movement);
			
			// Move the camera
			if (isLinkedToCamera)
			{
				Camera.main.transform.Translate(movement);
			}
			if (isLooping)
			{
			Transform firstChild=backgroundPart.FirstOrDefault();
			if(firstChild!=null)
			{
				if(firstChild.position.y<Camera.main.transform.position.y)
				{
					if(firstChild.renderer.IsVisibleFrom (Camera.main)==false)
					{
						Transform lastChild=backgroundPart.LastOrDefault();
						Vector3 lastPosition=lastChild.transform.position;
						Vector3 lastSize=(lastChild.renderer.bounds.max-lastChild.renderer.bounds.min);
						firstChild.position=new Vector3(firstChild.position.x,lastPosition.y+lastSize.y,firstChild.position.z);
						backgroundPart.Remove (firstChild);
						backgroundPart.Add (firstChild);
					}
				}
			}
			}
		}
	}

