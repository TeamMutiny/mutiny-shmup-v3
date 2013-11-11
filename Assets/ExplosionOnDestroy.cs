using UnityEngine;
using System.Collections;

public class ExplosionOnDestroy : MonoBehaviour {
	
	public GameObject explosion;
	private bool isQuitting = false;
	
	void OnApplicationQuit()
	{
	    isQuitting = true;
	}
	
	void OnDestroy()
	{
		if(!isQuitting)
		{	
		GameObject newExplosion = Instantiate(explosion,transform.position,transform.rotation) as GameObject;
		Destroy(newExplosion,2);
		}
	}
}
