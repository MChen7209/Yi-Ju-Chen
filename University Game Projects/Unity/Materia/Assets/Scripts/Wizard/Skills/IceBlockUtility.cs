using UnityEngine;
using System.Collections;

public class IceBlockUtility : Skills 
{
	public int iceBlawkDuration = 10;
//	private IceBlawkOpaque iceBlawkLinkScript;
//	private GameObject IceBlawk;
	private GameObject IceRadius;
	private GameObject iceBlawkOpaqueTarget;
	private int iceBlockLimit;

	public IceBlockUtility(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name,type,skillClass,desc,float.Parse(damage),float.Parse (cooldown))
	{
		setSkillProjectile("IceBlockUtility");
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(object.ReferenceEquals(skillProjectile, null))
			setSkillProjectile("IceBlockUtility");
		if(anim == null)
			anim = transform.root.GetComponent<Animator>();

//		Debug.Log("I AM ALIVE?");
		if (Input.GetButton ("Fire2") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0))
		{
			IceRadius.SetActive (true);
			atkController.SecondSkillLock = true;
			Camera myCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
			Vector2 mousePosHS = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			Vector2 direction = mousePosHS - (Vector2)transform.parent.position;
			RaycastHit2D hsHit = Physics2D.Raycast (transform.parent.position, direction, 100f, 1<<14);
			if (hsHit && (Vector2.Distance (new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y), IceRadius.transform.position) > 17f))
			{
				iceBlawkOpaqueTarget.transform.position = hsHit.point;
				if (Input.GetKeyDown ("mouse 0"))
				{
					GameObject realIceBlawk = Instantiate (skillProjectile, iceBlawkOpaqueTarget.transform.position, iceBlawkOpaqueTarget.transform.rotation) as GameObject;
					Destroy (realIceBlawk, 10);
				}
			}

			else
			{
				iceBlawkOpaqueTarget.transform.position = new Vector3 (myCam.ScreenToWorldPoint (Input.mousePosition).x, myCam.ScreenToWorldPoint (Input.mousePosition).y, myCam.ScreenToWorldPoint (Input.mousePosition).z + 10);
				if (Input.GetKeyDown ("mouse 0"))
				{
					Debug.Log(skillProjectile.tag);
					GameObject realIceBlawk = Instantiate (skillProjectile, iceBlawkOpaqueTarget.transform.position, iceBlawkOpaqueTarget.transform.rotation) as GameObject;
					Destroy (realIceBlawk, 10);
				}
			}
		}
		if (Input.GetButtonUp ("Fire2") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) )
		{
			atkController.SecondSkillLock = false;
			IceRadius.SetActive (false);
		}
	}

	protected override void doAfterInitialize ()
	{
		IceRadius = Instantiate(Resources.Load("skills/IceRadius"), transform.root.position, Quaternion.identity) as GameObject;
		IceRadius.transform.parent = GameObject.FindGameObjectWithTag(skillClass).transform;
//		IceRadius = transform.parent.transform.FindChild("IceRadius").gameObject;
		iceBlawkOpaqueTarget = IceRadius.transform.FindChild ("IceBlock").gameObject;
		transform.root.FindChild("IceRadius(Clone)").gameObject.SetActive (false);
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
		throw new System.NotImplementedException ();
	}
}
