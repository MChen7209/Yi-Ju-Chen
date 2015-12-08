using UnityEngine;
using System.Collections;

public class DashSkill : Skills {

	private float dashDuration;
	private GameObject sword;

	public DashSkill(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name, type, skillClass, desc, float.Parse(damage), float.Parse(cooldown))
	{
	}
	
	public DashSkill(string name, string type, string skillClass, string desc, float damage, float cooldown) : base(name, type, skillClass, desc, damage, cooldown)
	{
	}

	void Awake(){
		sword = GameObject.Find ("sword1");
		sword.transform.collider2D.enabled = false;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(anim == null)
			anim = transform.root.GetComponent<Animator>();
		
		if (Input.GetKey ("mouse 0") && (anim.GetInteger ("Skill").CompareTo (mySlot + 1) == 0) && !atkController.SecondSkillLock)
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
		//sword.transform.collider2D.enabled = true;
		anim.SetBool("Dashing", true);
		dashDuration -= Time.deltaTime;
		transform.parent.rigidbody2D.AddForce(transform.parent.right * 500);
	}
	
	protected override void ButtonUp()
	{
		sword.transform.collider2D.enabled = false;
		anim.SetBool("Dashing", false);
		StartCoroutine (simulateCooldown ());
	}

}
