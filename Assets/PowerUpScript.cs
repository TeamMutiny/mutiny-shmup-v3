using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	private float laserSpeed = 0.2f;
	public float laserDuration = 3f;
	public GameObject laser;
	private GameObject activeLaser;
	public bool laserActive = false;
	private float timeActive = 0;
	private GameObject ship;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ship  = (GameObject.Find("spaceship"));
		if(laserActive){
			timeActive += Time.deltaTime;
			if(activeLaser.transform.localScale.y < 12f){
			activeLaser.transform.localScale += new Vector3(0.0f,laserSpeed,0f);
			}
			activeLaser.transform.position =ship.transform.position + (new Vector3(0.0f,(activeLaser.transform.localScale.y+0.1f),0f));
			if(timeActive > laserDuration){
				laserActive = false;
				timeActive = 0;
				Destroy(activeLaser);
			}
		}
		
	}
	
	void PowerUp(string powerUpName){
		
		if(powerUpName.Equals("Laser")){
			if(laserActive){
				timeActive = 0;
			}else{
			activeLaser = (GameObject)Instantiate(laser, gameObject.transform.position, Quaternion.identity);
			laserActive = true;	
			}
		}
		
	}
}
