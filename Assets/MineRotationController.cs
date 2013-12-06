using UnityEngine;
using System.Collections;

public class MineRotationController : MonoBehaviour {

	public float speed = 15.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0.0f,0.0f,1.0f) * Time.deltaTime * speed);
	}
}
