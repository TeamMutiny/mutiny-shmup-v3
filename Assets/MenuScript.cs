﻿using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public int x = 50;
	public int y = 220;
	public int width = 120;
	public int height = 30;
	public int spacing = 35;
	private bool paused = false;
	private GameObject hpBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if(GameObject.Find("spaceship") != null){
			GUI.skin = null;
			if(GUI.Button(new Rect(x,y+spacing*0,width,height), "Continue")) {
				GameObject.Find("spaceship").SendMessage("ResumeGame");
				// New game
			}
			if(GUI.Button(new Rect(x,y+spacing*1,width,height), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale = 1f;
				// Quit
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(x,y+spacing*2,width,height), "Quit")) {
				Application.Quit();
				// Quit
			}
		}
		else {
			if(GUI.Button(new Rect(x,y+spacing*0,width,height), "Play")) {
				Application.LoadLevel(1);
				// New game
			}
			if(GUI.Button(new Rect(x,y+spacing*1,width,height), "Quit")) {
				Application.Quit();
				// Quit
			}
			
		}
	}
	
	
}
