using UnityEngine;
using System.Collections;

public class HookShotUtility : Skills 
{
	private GameObject anchor;
	private HingeJoint2D joint;
	private HingeJoint2D anchorJoint;
	private LineRenderer lr;
	private bool hooked;
//	private Animator anim;
	private bool pulledHook;
	private float maxRopeLimit;

	public HookShotUtility(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name, type, skillClass, desc, float.Parse(damage), float.Parse(cooldown))
	{
	}
	
	public HookShotUtility(string name, string type, string skillClass, string desc, float damage, float cooldown) : base(name, type, skillClass, desc, damage, cooldown)
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(object.ReferenceEquals(anchor,null))
			anchor = GameObject.FindGameObjectWithTag ("Anchor").gameObject;
		
		if (hooked)
		{
			if(pulledHook && Input.GetButton ("Jump"))
			{
				Destroy (joint);
				Destroy (anchorJoint);
				//Hide line
				lr.enabled = false;
				hooked = false;
				anim.SetBool ("Hooked", hooked);
				pulledHook = false;
				atkController.SecondSkillLock = false;
				transform.rigidbody2D.velocity = new Vector2 ( transform.position.x + 10, transform.position.y +10);
			}
			if(Input.GetMouseButtonDown(0))
			{
				anchor.GetComponent<HingeJoint2D>().anchor = Vector3.zero;
				pulledHook = true;
			}
			
			if(Input.GetKey (KeyCode.W))
			{
				Debug.Log ("Should be going up hookshot");
				Vector2 tempAnchor = anchor.GetComponent<HingeJoint2D>().anchor;
				
				if(tempAnchor.x < 1 && tempAnchor.x > -1 && tempAnchor.y < 1 && tempAnchor.y > -1)
					tempAnchor = new Vector2 (0,0);
				else
				{
					if(tempAnchor.x > 0)
						tempAnchor.x = tempAnchor.x-0.5f;
					if(tempAnchor.x < 0)
						tempAnchor.x = tempAnchor.x+0.5f;
					if(tempAnchor.y > 0)
						tempAnchor.y = tempAnchor.y-0.5f;
					if(tempAnchor.y < 0)
						tempAnchor.y = tempAnchor.y+0.5f;
				}
				anchor.GetComponent<HingeJoint2D>().anchor = new Vector2 (tempAnchor.x, tempAnchor.y);
			}
			else if(Input.GetKey (KeyCode.S))
			{
				Debug.Log ("Should be going down hookshot");
				Vector2 tempAnchor = anchor.GetComponent<HingeJoint2D>().anchor;
				if(tempAnchor.x < maxRopeLimit)
					tempAnchor.x = tempAnchor.x+0.5f;
				if(tempAnchor.y < maxRopeLimit)
					tempAnchor.y = tempAnchor.y+0.5f;
				
				anchor.GetComponent<HingeJoint2D>().anchor = new Vector2 (tempAnchor.x, tempAnchor.y);
			}

			lr.SetPosition(0,transform.position);
			lr.SetPosition(1,anchor.GetComponent<HingeJoint2D>().connectedBody.position);
			lr.SetColors(Color.black,Color.black);
			lr.enabled = true;
		}
		else
		{
			anchor.transform.position = transform.transform.position;
			anchor.transform.rotation = Quaternion.identity;
		}
		
		//On left Click
		if (Input.GetMouseButtonDown (1) && anim.GetInteger("Skill").CompareTo(mySlot+1) == 0)
		{
			atkController.SecondSkillLock = true;
			//Get the Clicked Position
			Vector3 clickedPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//We don't want that Z pos because this is in 2D
			clickedPosition.z = 0;
			//Shoot a ray out towards that position
			Vector2 mousePosHS = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			Vector2 direction = mousePosHS - (Vector2)transform.position;
			RaycastHit2D hit = Physics2D.Raycast (transform.position, direction, 20f, 1<<12);
			if (hit.collider != null) 
			{
				anchor.transform.rotation = Quaternion.identity;
				joint = transform.root.gameObject.AddComponent<HingeJoint2D> ();
				joint.anchor = Vector3.zero;
				joint.connectedBody = anchor.rigidbody2D;
				anchor.transform.rotation = Quaternion.identity;//--!
				anchorJoint = anchor.AddComponent<HingeJoint2D> ();
				anchorJoint.connectedBody = hit.collider.gameObject.rigidbody2D;
				anchor.transform.rotation = Quaternion.identity; //--!
				anchorJoint.anchor = new Vector2((hit.collider.transform.position.x - transform.root.position.x), (hit.collider.transform.position.y - transform.root.position.y));
				hooked = true;
				anim.SetBool ("Hooked", hooked);
			}
			//On left Click release
		} 
		else if (Input.GetMouseButtonUp (1) && anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) 
		{
			//Destroy HingeJoints
			Destroy (joint);
			Destroy (anchorJoint);
			atkController.SecondSkillLock = false;
			//Hide line
			lr.enabled = false;
			hooked = false;
			anim.SetBool ("Hooked", hooked);
		}
	}

	protected override void doAfterInitialize ()
	{
		maxRopeLimit = 14.142f;
		lr = transform.root.GetComponent<LineRenderer> ();
		anim = transform.root.GetComponent<Animator>();
		hooked = false;
		pulledHook = false;
	}

	protected override void ButtonDown ()
	{
		throw new System.NotImplementedException ();
	}

	protected override void ButtonUp ()
	{
		throw new System.NotImplementedException ();
	}

	public override void skillActivate ()
	{

	}
}
