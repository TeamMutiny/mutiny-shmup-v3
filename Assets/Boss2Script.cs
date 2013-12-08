using UnityEngine;
using System.Collections;

public class Boss2Script : MonoBehaviour {
	
	public GameObject mine_wrap;
	public GameObject mineTeleport;
	private float mineSpawnInterval = 5f;
	private float rotationTime = 0f;
	private float rotationTimer;
	private float mineSpawnTime = 0f;
	private GameObject activeSpawner = null;
	private Vector3[] mineSpawnLocations = {new Vector3(-35f,20f,0f),new Vector3(35f,20f,0f),new Vector3(25f,-15f,0f),new Vector3(-25f,-15f,0f)};
	// Use this for initialization
	void Start () {
		rotationTimer =RandomTime();
		
	}

	//mine spawn points +-35,20   +-25,-15
	// Update is called once per frame
	void Update () {
		
		if(!this.gameObject.animation.isPlaying){
			rotationTime += Time.deltaTime;
			mineSpawnTime += Time.deltaTime;
			BroadcastMessage("StartShooting");
			if(rotationTime > rotationTimer){
				rotationTimer = RandomTime();
				GameObject.FindWithTag("BOSS2").SendMessage("Reverse");
				rotationTime = 0;
			}
			if( mineSpawnTime > mineSpawnInterval){
				GameObject player = GameObject.Find("spaceship");
				float distance = Mathf.Infinity;
				Vector3 SpawnPoint = new Vector3(5f,0f,0f);
				foreach(Vector3 location in mineSpawnLocations){
					Debug.Log("WAS");
					Vector3 diff = location - player.transform.position;
					float curDistance = diff.sqrMagnitude;
					if (curDistance < distance) {
	                    SpawnPoint = location;
	                    distance = curDistance;
	                }
				}
				
				if(activeSpawner == null){
					activeSpawner = (GameObject)Instantiate(mineTeleport, SpawnPoint, Quaternion.identity);
				}
				activeSpawner.transform.position = SpawnPoint;
				activeSpawner.SendMessage("SpawnMine");
				
			mineSpawnTime = 0;
			}
		}

	}
	
	void DebugTimer(){
		Debug.Log(mineSpawnInterval - mineSpawnTime);
	}
	
	float RandomTime(){
		float temp =  Random.value*20;
		if(temp > 5f){
			return temp;
		}
		return 5f;
		
		
	}
	
}