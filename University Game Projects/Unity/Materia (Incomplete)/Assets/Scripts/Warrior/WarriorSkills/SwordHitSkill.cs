using UnityEngine;
using System.Collections;

public class SwordHitSkill : Skills {

	private GameObject sword;

	public SwordHitSkill(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name, type, skillClass, desc, float.Parse(damage), float.Parse(cooldown))
	{
	}
	
	public SwordHitSkill(string name, string type, string skillClass, string desc, float damage, float cooldown) : base(name, type, skillClass, desc, damage, cooldown)
	{
	}


	// Use this for initialization
	void Start () {
		sword = GameObject.Find ("sword1");
		//sword.transform.collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(anim == null)
			anim = transform.root.GetComponent<Animator>();

		if (Input.GetKey ("mouse 0") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) && !atkController.SecondSkillLock)
			ButtonDown ();

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
		anim.Play("Forward Slash");
		StartCoroutine(simulateCooldown());
	}

	protected override void ButtonUp()
	{
		sword.transform.collider2D.enabled = false;
	}

}
