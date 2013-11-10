using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy") {
			GameObject.Find("HP bar").SendMessage("GotHit", 5.0f);
		}
		
		if(other.gameObject.tag == "EnemyProjectile") {
			GameObject.Find("HP bar").SendMessage("GotHit", 5.0f);
			Destroy(other.gameObject);
		}
	}
}
