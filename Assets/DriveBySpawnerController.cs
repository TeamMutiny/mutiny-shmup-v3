using UnityEngine;
using System.Collections;

public class DriveBySpawnerController : MonoBehaviour {

		
	public GameObject basic_enemy;
	public GameObject anim_wrapper;
	public float spawnDelay = 0;
	private float spawnInterval;
	private float seqTime = 20f;
	private float seqInterval = 3.0f;
	
	private float timer = 0.0f;
	
	private int spawnAmount = 4;
	private int spawned = 0;
	
	private Quaternion enemy_rotation = Quaternion.identity;
	
	private enum State {
		SPAWNING,
		STOPPED,
		SEQ_INTERVAL
	}
	
	private State state;
	
	// Use this for initialization
	void Start () {
		GameObject groupped =  GameObject.Find("Spawner");
		SpawnerGroupScript scripta = groupped.GetComponent<SpawnerGroupScript>();
		spawnInterval = scripta.driveByInterval;
		state = State.SEQ_INTERVAL;
		timer -= spawnDelay;
		timer += Random.value*10;
		// set enemyrotation through script
		enemy_rotation.eulerAngles  = new Vector3(gameObject.transform.rotation.x +0f,gameObject.transform.rotation.y + 0.0f,90.0f);
	}
	
	void StopSpawn(){
		state = State.STOPPED;
		
	}
	
	void StartSpawn(){
		state = State.SPAWNING;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log(spawnDelay+seqTime - timer);
		switch(state) {
		
		case State.STOPPED:
			
		break;
			
		case State.SEQ_INTERVAL:
			
			if(timer > seqTime) {
				state = State.SPAWNING;
				timer = 0.0f;
			}
		break;
			
		case State.SPAWNING:
		
			if (timer >  (spawnInterval)/10) 
			{
				
				timer = 0.0f;
				// location_wrapper moves the animation to correct position 
				GameObject animation_wrapper = (GameObject) Instantiate(anim_wrapper, new Vector3(0.0f, 0.0f,0.0f), Quaternion.identity);
				
				
				GameObject newenemy = (GameObject) Instantiate(basic_enemy, gameObject.transform.position, enemy_rotation);
				
				newenemy.transform.parent = animation_wrapper.transform;
				
				if(gameObject.transform.parent.name.Equals("LeftDriveBySpawner")){
					newenemy.transform.parent.animation.Play("LeftDriveByShooting");
					newenemy.transform.rotation = Quaternion.Euler( new Vector3(transform.rotation.x +0f,gameObject.transform.rotation.y + 0.0f,-90.0f));
				}else{
					newenemy.transform.parent.animation.Play("RightDriveByShooting");
				}
				spawned++;
				
				
				if(spawned >= spawnAmount) {
					state = State.SEQ_INTERVAL;
					timer = 0.0f;
					spawned = 0;
					
				}
			}
			
		break;
		}
				
		timer += Time.deltaTime;
	}
	
}
