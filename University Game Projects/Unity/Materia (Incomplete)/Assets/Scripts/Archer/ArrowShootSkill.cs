using UnityEngine;
using System.Collections;

public class ArrowShootSkill : Skills 
{
	public ArrowShootSkill(string name, string type, string skillClass, string desc, string damage, string cooldown) : base(name, type, skillClass, desc, float.Parse(damage), float.Parse(cooldown))
	{
		setSkillProjectile("ArrowShootSkill");
	}
	
	public ArrowShootSkill(string name, string type, string skillClass, string desc, float damage, float cooldown) : base(name, type, skillClass, desc, damage, cooldown)
	{
		setSkillProjectile("ArrowShootSkill");
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log("At least in the update?");
		if(object.ReferenceEquals(skillProjectile, null))
			setSkillProjectile("ArrowShootSkill");
		if(anim == null)
			anim = transform.root.GetComponent<Animator>();

		if (Input.GetKey ("mouse 0") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) && !atkController.SecondSkillLock)
			ButtonDown ();
		if (Input.GetButtonUp ("Fire1") && (anim.GetInteger("Skill").CompareTo(mySlot+1) == 0) && !atkController.SecondSkillLock)
			ButtonUp ();
	}

	protected override void ButtonDown ()
	{
//		Debug.Log("Holding down Archer");
		anim.SetBool ("Holding", true);
		if (power <= 100) {
			power += Time.deltaTime * 70;
		}
	}

	protected override void ButtonUp ()
	{
		anim.SetBool("Preparing", false);
		anim.SetBool("Holding", false);
		if (!isSkillCooldown) 
		{
//			bow.animation.Play("Take 001");
			isSkillCooldown = true;
			GameObject crateClone = Instantiate (skillProjectile, transform.position, transform.rotation) as GameObject;
			crateClone.rigidbody2D.velocity = transform.TransformDirection (new Vector3 (20 +power, 0, 0));
//			Debug.Log (power);
			Destroy(crateClone, 5); 
			StartCoroutine(simulateCooldown());
		}//end if Fireball logic
		
		power = 0;
	}
	
	protected override void doAfterInitialize ()
	{
		skillProjectile.renderer.sortingLayerName = "CastleFront";

	}

	public override void skillActivate ()
	{

	}
}
