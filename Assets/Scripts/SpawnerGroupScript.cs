﻿using UnityEngine;
using System.Collections;

public class SpawnerGroupScript : MonoBehaviour {

	public float spawnInterval = 5f;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void StopSpawner(){
		BroadcastMessage("StopSpawn");
		
	}
	
	 void StartSpawner(){
		BroadcastMessage("StartSpawn");
		
	}
	
}
