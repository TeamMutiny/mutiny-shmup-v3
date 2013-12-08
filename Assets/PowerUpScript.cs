using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	private float laserSpeed = 0.5f;
	public float laserDuration = 3f;
	public GameObject laser;
	private GameObject activeLaser;
	public bool laserActive = false;
	private float timeActive = 0;
	private GameObject ship;
	private string storedPowerup = null;
	
	
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
			activeLaser.transform.position =ship.transform.position + (new Vector3(0.0f,(activeLaser.transform.localScale.y+0.2f),0f));
			if(timeActive > laserDuration){
				laserActive = false;
				timeActive = 0;
				Destroy(activeLaser);
			}
		}
		
	}
	
	void PowerUp(string powerUpName){
		storedPowerup = powerUpName;
		GameObject.Find("PowerUp").guiTexture.enabled = true;
		GameObject.Find("PowerUp").guiTexture.texture = Resources.Load(powerUpName, typeof(Material)) as Texture;
		
		
	}
	
	void ActivatePowerup(){
		
		if(storedPowerup != null && storedPowerup.Equals("Laser")){
			if(laserActive){
				timeActive = 0;
			}else{
			activeLaser = (GameObject)Instantiate(laser, gameObject.transform.position, Quaternion.identity);
			laserActive = true;	
			}
		}
		
		storedPowerup = "";
		GameObject.Find("PowerUp").guiTexture.enabled = false;	
	}
}
