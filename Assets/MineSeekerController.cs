using UnityEngine;
using System.Collections;

public class MineSeekerController : MonoBehaviour {
	
	public GameObject light_halo;
	public GameObject light_glow;
	public GameObject player;
	public float heat_seek_distance = 70.0f;
	private bool heat_seeking = false;
	private Vector3 move;
	
	// Use this for initialization
	void Start () {
		light_glow.light.enabled = false;
		light_halo.light.enabled = false;
		move = new Vector3(0.0f,-3.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(heat_seeking) {
			gameObject.rigidbody.AddForce(player.transform.position-gameObject.transform.position);
		}
		else {
			// Just move forward if not heat seeking
			gameObject.rigidbody.AddForce(move);
			
			if((gameObject.transform.position - player.transform.position).sqrMagnitude < heat_seek_distance) {
				heat_seeking = true;
				light_glow.light.enabled = true;
				light_halo.light.enabled = true;
			}	
		}
		
	}
}
