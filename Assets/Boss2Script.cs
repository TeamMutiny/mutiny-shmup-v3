using UnityEngine;
using System.Collections;

public class Boss2Script : MonoBehaviour {
	
	public GameObject mine_wrap;
	public GameObject mineSpawn;
	public float mineSpawnInterval = 20f;
	private float rotationTime;
	private float rotationTimer;
	private float mineSpawnTime;
	private Vector3[] mineSpawnLocations = {new Vector3(-35f,20f,0f),new Vector3(35f,20f,0f),new Vector3(-25f,-15f,0f),new Vector3(-25f,-15f,0f)};
	// Use this for initialization
	void Start () {
		time = 0.0f;
		rotationTimer = Random.value*20;
	}

	//mine spawn points +-35,20   +-25 -15
	// Update is called once per frame
	void Update () {
		rotationTime += Time.deltaTime;
		mineSpawnTime += Time.deltaTime;
		BroadcastMessage("StartShooting");
		if(rotationTime > rotationTimer){
			rotationTimer = Random.value*20;
			GameObject.Find("BOSS2").SendMessage("Reverse");
			time = 0;
		}
		
		if(mineSpawnTime > mineSpawnInterval){
			GameObject player = GameObject.Find("spaceship");
			distance = Mathf.Infinity;
			Vector3 SpawnPoint;
			foreach(Vector3 location in mineSpawnLocations){
				Vector3 diff = location.transform.position - player.transform.position;
				if (curDistance < distance) {
                    SpawnPoint = location;
                    distance = curDistance;
                }
			}
			GameObject.Find("minespawn").transform.position = SpawnPoint;
		mineSpawnTime = 0;
		}
		Debug.Log(rotationTimer - time);
		

	}
	
	
}