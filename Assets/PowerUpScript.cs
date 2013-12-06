using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	public float laserSpeed = 0.1f;
	public GameObject laser;
	private GameObject activeLaser;
	public bool laserActive = false;
	private float timeActive = 0;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(laserActive){
			timeActive += Time.deltaTime;
			activeLaser.transform.localScale += new Vector3(0.0f,laserSpeed,0f);
			activeLaser.transform.position = (GameObject.Find("spaceship").transform.position) + (new Vector3(0.0f,-10*laserSpeed,0f));
			//
		}
		
	}
	
	void PowerUp(string powerUpName){
		
		if(powerUpName.Equals("Laser")){
			activeLaser = (GameObject)Instantiate(laser, gameObject.transform.position, Quaternion.identity);
			laserActive = true;
		}
		
	}
}
