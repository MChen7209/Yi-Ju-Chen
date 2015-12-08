using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	LineRenderer line;
	Light light;
	public GameObject particleposition;


	//private ParticleSystem particle;
	private float lastHitTime;
	private HeroController  player;
	// Use this for initialization
	void Awake()
	{
		particleposition.SetActive (true);

	}
	void Start () {
	
		//par2 = particleposition.transform.position;

		player =  GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
		//particle = gameObject.GetComponent<ParticleSystem > ();
		light = gameObject.GetComponent<Light> ();
		line = gameObject .GetComponent<LineRenderer > ();
		line.enabled = true;
		light.enabled = true;
		/*Ray2D ray = new Ray2D (transform.position, transform.right);
		RaycastHit2D hit;
		line.SetPosition (0, ray.origin);
		line.SetPosition (1, ray.GetPoint (10));*/
	}
	
	// Update is called once per frame
	void Update () {

		if (!HeroController .GameOver ) 
		{
			line.renderer .material .mainTextureOffset = new Vector2 (-Time.time, 0);
			Ray2D ray = new Ray2D (transform.position, transform.right);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, transform.right);
			line.SetPosition (0, ray.origin);
			if (hit.collider != null) 
			{

				//gameObject.transform.FindChild("prarticleposition").transform.localPosition=new Vector2(1,0);

					particleposition.transform.position=hit.point;

				line.SetPosition (1, hit.point);
				if (hit.rigidbody) 
				{
					hit.rigidbody .AddForceAtPosition (transform.right * 50, hit.point);
				}
				if (hit.collider.name == "Hero") 
				{
					if (Time.time > lastHitTime + 1.25)
					{
						player.Vitals .TakeDamage();
						lastHitTime = Time.time;
					}
					if (player.Vitals .Dead) 
					{
											
						HeroController .GameOver=true;
					}
				}
			} 
			else
				line.SetPosition (1, ray.GetPoint (10));

			}
		//StopCoroutine ("FireLaser");
		//StartCoroutine ("FireLaser");
	}


}
