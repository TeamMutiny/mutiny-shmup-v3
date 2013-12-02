using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = null;
		if(GUI.Button(new Rect(20,40,80,20), "Play")) {
			// New game
		}

		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
			// Quit
		}
	}
}
