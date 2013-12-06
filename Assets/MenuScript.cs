using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public int x = 20;
	public int y = 40;
	public int width = 80;
	public int height = 20;
	public int spacing = 50;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = null;
		if(GUI.Button(new Rect(x,y+spacing*0,width,height), "Play")) {
			Application.LoadLevel(1);
			// New game
		}
		if(GUI.Button(new Rect(x,y+spacing*1,width,height), "Endless")) {
			Application.LoadLevel(2);
			// Quit
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(x,y+spacing*2,width,height), "Quit")) {
			Application.Quit();
			// Quit
		}
	}
}
