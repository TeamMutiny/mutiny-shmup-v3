using UnityEngine;
using System.Collections;

public class CollisionControler : MonoBehaviour {
	
	private GameObject explosion;
	// Use this for initialization
	void Start () {
		explosion = Resources.Load("Enemy explosion") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		OnTriggerEnter(collision.collider);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "Laser") {
			
			 
			Object klooni = Instantiate(explosion,transform.position,transform.rotation);
			GameObject foo = GameObject.Find("Score");
			Destroy(klooni,2);
			Destroy(gameObject);
			foo.SendMessage("tappo");
			if(Random.value > 0.98f){
				GameObject powerUp = Resources.Load("Powerup Laser") as GameObject;
				klooni = Instantiate(powerUp,transform.position, Quaternion.identity);
			}
		}

	}
}
