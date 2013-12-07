using UnityEngine;
using System.Collections;

public class BossShootInDirection : MonoBehaviour {
	
	public GameObject bullet;
	private float shotInterval;
	private float time;
	private bool shooting = false;
	private GameObject bossType;
	void Start(){
		bossType = gameObject.transform.parent.gameObject;
		if(bossType.name.Equals("BOSS")){
			shotInterval = 0.5f;
		}
		if(bossType.name.Equals("BOSS2")){
			shotInterval = 0.3f;
		}
		time = 0.0f;
		
	}
	void Update(){
		time += Time.deltaTime;
		if(time > shotInterval && shooting){
			if(bossType.name.Equals("BOSS")){
			shootAtPlayer();
			}
			if(bossType.name.Equals("BOSS2")){
				Vector3 direction = new Vector3(bossType.transform.position.x -  gameObject.transform.position.x,bossType.transform.position.y- gameObject.transform.position.y,0f);
				shootInDirection(-2*direction);
				
			}
			time = 0.0f;
		}
		
	}
	
	
	void StartShooting(){
		shooting = true;
		
	}
	
	void shootInDirection(Vector3 direction) {
		GameObject newbullet = (GameObject)Instantiate(bullet, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0f), Quaternion.identity);
		newbullet.transform.LookAt(direction);
		//newbullet.SendMessage("setDirection", direction);
	}
	
	void shootAtPlayer() {
		GameObject newbullet = (GameObject)Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if(player != null) {
			newbullet.transform.LookAt(player.transform.position);
		}
	}
	
	void shootAtPoint(Vector3 point) {
	
		GameObject newbullet = (GameObject)Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		
		GameObject t_point = new GameObject();
		
		t_point.transform.position = point;
		
		newbullet.transform.LookAt(t_point.transform);
	}
}



