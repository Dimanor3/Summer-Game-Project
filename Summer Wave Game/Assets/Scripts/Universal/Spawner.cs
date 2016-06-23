using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	// Color of the gizmo
	public Color gizmoColor = Color.red;

	public GameObject Enemy;

	// Enemies and how many have been created and how many are to be created
	public int totalEnemy = 10;
	private int numEnemy = 0;
	//private int spawnedEnemy = 0;

	// The ID of the spawner
	private int SpawnID;

	private bool waveSpawn = false;
	public bool Spawn = true;

	//Wave controls
	public int totalWaves = 5;
	private int numWaves = 0;


	// Use this for initialization
	void Start () {
		// sets a random number for the id of the spawner
		SpawnID = Random.Range(1, 500);


	}

	// Draws a cube to show where the spawn point is... Useful if you don't have a object that show the spawn point
	void OnDrawGizmos()
	{
		// Sets the color to red
		Gizmos.color = gizmoColor;
		//draws a small cube at the location of the gam object that the script is attached to
		Gizmos.DrawCube (transform.position, new Vector3 (0.5f, 0.5f, 0.5f));
	}


	
	// Update is called once per frame
	void Update () {
		if(Spawn){
			if(numWaves < totalWaves + 1)
			{
				if (waveSpawn)
				{
					//spawns an enemy
					spawnEnemy();
				}
				if (numEnemy == 0)
				{
					// enables the wave spawner
					waveSpawn = true;
					//increase the number of waves
					numWaves++;
				}
				if(numEnemy == totalEnemy)
				{
					// disables the wave spawner
					waveSpawn = false;
				}
			}
		}
	}

	// spawns an enemy based on the enemy level that you selected
	private void spawnEnemy()
	{
		int spawnPointX = Random.Range (20, 70);
		int spawnPointZ = Random.Range (40, 60);
		Vector3 spawnPosition = new Vector3 (spawnPointX, 0.05f, spawnPointZ);

		Instantiate(Enemy, spawnPosition, Quaternion.identity);
		Enemy.SendMessage("setName", SpawnID);
		// Increase the total number of enemies spawned and the number of spawned enemies
		numEnemy++;
		//spawnedEnemy++;
	}

	public void killEnemy(){
		numEnemy--;
	}

	// Call this function from the enemy when it "dies" to remove an enemy count
	/*public void killEnemy(int sID)
	{
		// if the enemy's spawnId is equal to this spawnersID then remove an enemy count
		if (SpawnID == sID)
		{
			numEnemy--;
		}
	}
	//enable the spawner based on spawnerID
	public void enableSpawner(int sID)
	{
		if (SpawnID == sID)
		{
			Spawn = true;
		}
	}
	//disable the spawner based on spawnerID
	public void disableSpawner(int sID)
	{
		if(SpawnID == sID)
		{
			Spawn = false;
		}
	}*/
}
