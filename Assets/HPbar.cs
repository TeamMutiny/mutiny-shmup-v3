using UnityEngine;
using System.Collections;

public class HPbar : MonoBehaviour {
	
	private GameObject explosion;
	public float hp = 100;
	GameObject bar;
	Color HPcolor;
	GameObject text;
	// Use this for initialization
	void Start () {
		bar = GameObject.Find("HPBar_HP");
		explosion = Resources.Load("Enemy explosion") as GameObject;
		text = GameObject.Find("HPBar_text");
	}
	
	// Update is called once per frame
	void Update () {
		bar.guiTexture.pixelInset = new Rect(bar.guiTexture.pixelInset.x,bar.guiTexture.pixelInset.y,hp*1.28f,bar.guiTexture.pixelInset.height);
		text.guiText.text = ""+hp;
	}	
	
	void GotHit(float damage){		
		hp -= damage;
		if(hp <= 0){
			Object klooni = Instantiate(explosion,GameObject.Find("spaceship").transform.position,GameObject.Find("spaceship").transform.rotation);
			Destroy(GameObject.Find("spaceship"));		
			Destroy(klooni,2);
		}
	}
	
	
}
