using UnityEngine;
using System.Collections;

public class bossScript : MonoBehaviour {
	
	
	private float time;
	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.gameObject.animation.isPlaying){
			this.gameObject.animation.Play("LeftToRight");
			
		}
	}
	
	
}
