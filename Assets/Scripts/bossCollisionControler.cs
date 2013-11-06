using UnityEngine;
using System.Collections;

public class bossCollisionControler : MonoBehaviour {
	public int hp;
	private GameObject explosion;
	// Use this for initialization
	void Start () {
		explosion = Resources.Load("Enemy explosion") as GameObject;
		explosion.transform.localScale = new Vector3(3f,3f,3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "bullet" || other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
			hp--;
			//Debug.Log(hp);
			if(hp < 0){
				Object klooni = Instantiate(explosion,transform.position,transform.rotation);
				Destroy(klooni,2);
				Destroy(gameObject);
				GameObject foo = GameObject.Find("Score");
				foo.SendMessage("bossitappo");
			}
			
		}
	}
}
