using UnityEngine;
using System.Collections;

public class BossShootInDirection : MonoBehaviour {
	
	public GameObject bullet;
	private float time;
	
	void Start(){
		time = 0.0f;
		
	}
	void Update(){
		time += Time.deltaTime;
		if(time > 0.1f){
			shootAtPlayer();
			time = 0.0f;
		}
		
	}
	
	void shootInDirection(Vector3 direction) {
		GameObject newbullet = (GameObject)Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		newbullet.SendMessage("setDirection", direction);
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



