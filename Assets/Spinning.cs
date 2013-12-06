using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public float speed = 2.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  transform.Rotate(speed*Random.value,speed*Random.value, speed*Random.value);
	}
}
