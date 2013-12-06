using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
	// Wrap collisions here also
	void OnCollisionEnter(Collision collision) {
		OnTriggerEnter(collision.collider);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy") {
			GameObject.Find("Hp bar").SendMessage("GotHit", 5.0f);
		}
		
		if(other.gameObject.tag == "EnemyProjectile") {
			GameObject.Find("Hp bar").SendMessage("GotHit", 5.0f);
			Destroy(other.gameObject);
		}
		
		if(other.gameObject.tag == "EnemyMine") {
			GameObject.Find("Hp bar").SendMessage("GotHit", 10.0f);
		}
	}
}
