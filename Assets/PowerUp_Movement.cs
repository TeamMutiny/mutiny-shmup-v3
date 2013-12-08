using UnityEngine;
using System.Collections;

public class PowerUp_Movement : MonoBehaviour {
	public float speed = 1.0f;
	private Vector3 direction;
	
	// Use this for initialization
	void Start () {
	direction = new Vector3(0.0f,1*speed,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate((Vector3.down/100)*speed*Time.timeScale);
		
	}
	
	
}
