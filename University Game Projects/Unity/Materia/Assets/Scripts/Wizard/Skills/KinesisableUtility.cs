using UnityEngine;
using System.Collections;

public class KinesisableUtility : Skills 
{
	private bool linked;
	private GameObject kinesisConnection;
	//public GameObject kinesisConnector;

	public KinesisableUtility(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name,type,skillClass,desc,float.Parse(damage),float.Parse (cooldown))
	{
		setSkillProjectile("KinesisableUtility");
	}

	// Use this for initialization
	void Awake () 
	{
		linked = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(object.ReferenceEquals(skillProjectile,null))
		   setSkillProjectile("KinesisableUtility");
		if(anim == null)
			anim = transform.root.GetComponent<Animator>();


		if (Input.GetButton ("Fire2") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0))
		{
			Camera myCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
			
			Debug.Log("Linked before if Statement: " + linked);
			if (linked)
				kinesisConnection.transform.position = new Vector3 (myCam.ScreenToWorldPoint (Input.mousePosition).x, myCam.ScreenToWorldPoint (Input.mousePosition).y, myCam.ScreenToWorldPoint (Input.mousePosition).z + 10);
			else
			{
				atkController.SecondSkillLock = true;
				if (Physics2D.OverlapCircle (myCam.ScreenToWorldPoint (Input.mousePosition), 1f).gameObject.tag == "Kinesisable")
				{
					float testLocation = 10;
					kinesisConnection = Physics2D.OverlapCircle (myCam.ScreenToWorldPoint (Input.mousePosition), 1f).gameObject;
					GameObject kinesisConnectoring = Instantiate(skillProjectile, Vector3.zero, Quaternion.identity) as GameObject;
					kinesisConnectoring.transform.parent = kinesisConnection.transform;
					kinesisConnectoring.transform.localPosition = Vector3.zero;
					kinesisConnection.transform.position = myCam.ScreenToWorldPoint (Input.mousePosition);
					kinesisConnection.transform.Translate (0, 0, 10);
					linked = true;
				}
			}
		}
		if (Input.GetButtonUp ("Fire2") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0))
		{
			//May have a bug if person changes skills without releasing key up
			atkController.SecondSkillLock = false;
			Debug.Log ("linked: " + linked);
			Destroy(kinesisConnection.transform.FindChild ("KinesisableUtility(Clone)").gameObject);
			linked = false;
			Debug.Log (" changed into linked: " + linked);
		}
	
	}

	public override void skillActivate ()
	{
		throw new System.NotImplementedException ();
	}

	protected override void ButtonDown ()
	{
		throw new System.NotImplementedException ();
	}

	protected override void ButtonUp ()
	{
		throw new System.NotImplementedException ();
	}

	protected override void doAfterInitialize ()
	{

	}
}
