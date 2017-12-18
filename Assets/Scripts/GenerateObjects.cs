using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {

	public GameObject currentPlatform;
	public GameObject NextPlatformPrefab;
	public GameObject obstacles;

	//z1 is used for first fifteen objects
	//z2 is used for every other object
	private float z1 = -90f;
	private float z2 = 0;

	// Y value. Used to make the game easier for testing
	private float testY = 20f;

	//random Y value for position
	float randomY(){
		return Random.Range (15, 22);
	}

	//Function for spawning the platform
	public void SpawnPlatform(){
		currentPlatform = (GameObject)Instantiate 
			(NextPlatformPrefab, currentPlatform.transform.GetChild (0).transform.GetChild (1).position, Quaternion.identity);
	}

	//this spawns the first 15 objects
	void Start(){
		for (int i = 0; i < 15; i++) {
			Vector3 pos = new Vector3 (0,randomY(), z1);
			GameObject FirstTwenty = Instantiate (obstacles, pos, Quaternion.identity);	
			z1 += 6f;
		}

	}
		
	//This spawns both objects: Pipes and Platforms.
	//Spawns Pipes after the first fifteen.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="SpawnObject")
		{
			for (int i = 0;i < 15; i++)
			{
				Vector3 pos = new Vector3 (0, randomY(), z2);
				GameObject Pipes = Instantiate(obstacles,pos,Quaternion.identity);	
				z2+= 6f;
			}
			SpawnPlatform ();
		}
	}

}
