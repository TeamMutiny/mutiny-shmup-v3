using UnityEngine;
using System.Collections;

public class Boss2Script : MonoBehaviour {
	
	
	private float time;
	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
			BroadcastMessage("StartShooting");

	}
	
	
}
