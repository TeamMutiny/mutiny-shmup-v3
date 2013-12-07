using UnityEngine;
using System.Collections;

public class BossMineSpawner : MonoBehaviour {
	
	public GameObject light_halo;
	public GameObject light_glow;
	public float heat_seek_force = 1.2f;
	private GameObject player;
	public float heat_seek_distance = 70.0f;
	private bool heat_seeking = false;
	private Vector3 move;
	
	// Use this for initialization
	void Start () {
		light_glow.light.enabled = true;
		light_halo.light.enabled = true;
		move = new Vector3(0.0f,-3.0f,0.0f);
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

			gameObject.rigidbody.AddForce(player.transform.position-heat_seek_force*gameObject.transform.position);
		
		
	}
}
