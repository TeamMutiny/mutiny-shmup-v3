using UnityEngine;
using System.Collections;

public class Powerup_collider : MonoBehaviour {

void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			GameObject.Find("spaceship").SendMessage("PowerUp","Laser");
			Destroy(gameObject);
		}
		
	}
}
