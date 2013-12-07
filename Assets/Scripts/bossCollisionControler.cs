using UnityEngine;
using System.Collections;

public class bossCollisionControler : MonoBehaviour {
	public int hp;
	private GameObject explosion;
	private GameObject bulletHit;
	private bool laserHitCooldown = false;
	// Use this for initialization
	void Start () {
		explosion = Resources.Load("Enemy explosion") as GameObject;
		bulletHit = Resources.Load("Projectile hit") as GameObject;
		explosion.transform.localScale = new Vector3(30f,30f,30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ActivateLaser() {
		laserHitCooldown = false;
		
	}
	
	void OnTriggerStay(Collider other) {
		
		if(other.gameObject.tag == "Laser" && !laserHitCooldown){
			Vector3 hitLocation = other.ClosestPointOnBounds(gameObject.transform.position);
			Debug.Log(hp);
			hp--;
			Object bulletExpl = Instantiate(bulletHit,hitLocation,other.transform.rotation);
			Destroy(bulletExpl,2);
			Invoke("ActivateLaser", 0.01f);
			laserHitCooldown = true;
		}
		
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.tag == "bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "EnemyMine") {

			hp--;
			Object bulletExpl = Instantiate(bulletHit,other.gameObject.transform.position,other.gameObject.transform.rotation);
			Destroy(bulletExpl,2);
			Destroy(other.gameObject);
			if(other.gameObject.tag == "Player"){
			GameObject.Find("HP bar").SendMessage("gotDead");
			}
			//Debug.Log(hp);
			
			
		}
		

		
		if(hp < 0){
				Object klooni = Instantiate(explosion,transform.position,transform.rotation);
			    Destroy(klooni,2);
				Destroy(gameObject);
				GameObject foo = GameObject.Find("Score");
				foo.SendMessage("bossitappo");
			}
	}
}
