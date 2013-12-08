using UnityEngine;
using System.Collections;

public class BossMineSpawner : MonoBehaviour {
	
	public GameObject mineObject;
	private bool closed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!GameObject.Find("Wrap").animation.IsPlaying("portal_open") && !closed){
			GameObject.Find("Wrap").animation.Play("portal_close");
			closed = true;
			
		}
			

		}
	
	void SpawnMine(){
		closed = false;
		GameObject.Find("Wrap").animation.Play("portal_open");
		Invoke("DelayedSpawn",1f);

	}
	
	void DelayedSpawn(){
		GameObject newenemy = (GameObject) Instantiate(mineObject, transform.position, Quaternion.identity);
		newenemy.SendMessage("setBossMineMode");
	}
	
	
	
	void PortalReady(){
		closed = false;
		
	}
}
