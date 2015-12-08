using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnScript : MonoBehaviour {

	/*
	 * Each level should have an enemy spawning object with multiple enemy spawns defined. Each time the level is loaded up, 
	 * the spawning object picks a random set of predefined enemy spawns. This gives an element of randomness that can also be memorized
	 * over time.
	 * Until then, this script is used.
	 * */
	public GameObject Enemy;
	public static int totalEnemies = 0;
	public static int maxEnemies = 10;
	public int NumberToSpawn = 4;
	List<Transform> spawnPoints;

	// Use this for initialization
	void Start () {
		spawnPoints = new List<Transform>();
		FindSpawns ();
		var spawns = ChooseSet(NumberToSpawn);
		for (int i = 0; i < spawns.Length; i++)
		{
			if (EnemySpawnScript.totalEnemies < EnemySpawnScript.maxEnemies) 
			{
				Instantiate(Enemy, spawns[i].transform.position, Quaternion.identity);
			}
		}
	}

	Transform[] ChooseSet(int numRequired) {
		var result = new Transform[numRequired];
		var numToChoose = numRequired;

		for (var numLeft = spawnPoints.Count; numLeft > 0; numLeft--) {
			// Adding 0.0 is simply to cast the integers to float for the division.
			var prob = (numToChoose + 0.0) / (numLeft + 0.0);
			if (Random.value <= prob) {
				numToChoose--;
				result[numToChoose] = spawnPoints[numLeft - 1];

				if (numToChoose == 0)
					break;
			}
		}

		return result;
	}

	void FindSpawns()
	{
		foreach(GameObject point in GameObject.FindGameObjectsWithTag("Spawn_Point"))
		{
			spawnPoints.Add(point.transform);
		}
	}
}
