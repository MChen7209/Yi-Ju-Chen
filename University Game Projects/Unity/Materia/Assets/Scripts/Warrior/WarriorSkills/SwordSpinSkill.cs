using UnityEngine;
using System.Collections;

public class SwordSpinSkill : Skills {

	private float spinDuration;
	private bool movedUp;
	private Vector3 oldPosition;
	private Vector3 newPos;
	private GameObject sword;

	public SwordSpinSkill(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name, type, skillClass, desc, float.Parse(damage), float.Parse(cooldown))
	{

	}
	
	public SwordSpinSkill(string name, string type, string skillClass, string desc, float damage, float cooldown) : base(name, type, skillClass, desc, damage, cooldown)
	{

	}

	// Use this for initialization
	void Start () {
		sword = GameObject.Find ("sword1");
		sword.transform.collider2D.enabled = false;
		oldPosition = transform.position;
		newPos = new Vector3(transform.position.x, transform.position.y , 0);
	}
	
	// Update is called once per frame
	void Update () {
		oldPosition = transform.position;
		newPos = new Vector3(transform.position.x, transform.position.y , 0);
		if(anim == null)
			anim = transform.root.GetComponent<Animator>();
		
		if (Input.GetKey ("mouse 0") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) && !atkController.SecondSkillLock)
			ButtonDown ();
		if (Input.GetButtonUp ("Fire1") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) && !atkController.SecondSkillLock)
			ButtonUp ();
	}

	public override void skillActivate()
	{
		
	}
	
	protected override void doAfterInitialize ()
	{
	}

	protected override void ButtonDown()
	{
		sword.transform.collider2D.enabled = true;
		if(movedUp){
			anim.SetBool("Spinning", true);
			spinDuration-=Time.deltaTime;
		}
		else{
			transform.parent.gameObject.transform.position = newPos;
			movedUp = true;
			transform.parent.rigidbody2D.isKinematic = true;
		}
	}
	
	protected override void ButtonUp()
	{
		sword.transform.collider2D.enabled = false;
		movedUp = false;
		transform.parent.rigidbody2D.isKinematic = false;
		anim.SetBool ("Spinning", false);
		StartCoroutine (simulateCooldown ());
	}

}
