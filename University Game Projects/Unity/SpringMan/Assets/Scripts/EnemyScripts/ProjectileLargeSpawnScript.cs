using UnityEngine;
using System.Collections;

public class ProjectileLargeSpawnScript: MonoBehaviour
{
	public float spawnTime ;		// The amount of time between each spawn.
	public float spawnDelay ;		// The amount of time before spawning starts.
	public GameObject ProjectileLarge;		// Array of enemy prefabs.
	
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}
	
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, ParachuteProjectileEnemy.Length);
		Instantiate(ProjectileLarge, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		
		
	}
}
