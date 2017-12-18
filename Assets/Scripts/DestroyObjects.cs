using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects: MonoBehaviour {

	void OnTriggerEnter(Collider other){

		//Destroys the Pipes
		if(other.tag=="DeathAreaPipes"){
			Destroy(other.gameObject);
		}

		//Destroys the platform
		if(other.tag=="Kill"){
			Destroy(other.transform.parent.gameObject);
		}
	}
}
