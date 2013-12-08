using UnityEngine;
using System.Collections;

public class BullerCollider : MonoBehaviour {

	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Laser"){
			Destroy(gameObject);
		}
	}
}
