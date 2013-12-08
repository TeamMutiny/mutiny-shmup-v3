using UnityEngine;
using System.Collections;

public class HPbar : MonoBehaviour {
	
	private GameObject explosion;
	public float hp = 100;
	GameObject bar;
	Color HPcolor;
	GameObject text;
	private GameObject gameOverText;
	private GameObject anyKey;
	private bool playerDead = false;
	// Use this for initialization
	void Start () {
		bar = GameObject.Find("HPBar_HP");
		explosion = Resources.Load("Enemy explosion") as GameObject;
		text = GameObject.Find("HPBar_text");
		gameOverText = Resources.Load("GameOverText") as GameObject;
		anyKey = Resources.Load("pressAnyKey") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		bar.guiTexture.pixelInset = new Rect(bar.guiTexture.pixelInset.x,bar.guiTexture.pixelInset.y,hp*1.28f,bar.guiTexture.pixelInset.height);
		text.guiText.text = ""+hp;
		
		if(playerDead && Input.anyKeyDown){
			Application.LoadLevel(0);
			
		}
	}	
	

	void GameOverMan(){
		GameObject score = GameObject.Find("Score");
		score.guiText.transform.position = new Vector3(0.5f,0.5f,1f);
		score.guiText.fontSize = 50;
		score.guiText.anchor = TextAnchor.MiddleCenter;
		
		Object gameOverClone = Instantiate(gameOverText,new Vector3(0.5f,0.7f,0.5f),transform.rotation);
		Object anyKeyClone = Instantiate(anyKey,new Vector3(0.5f,0.2f,0.5f),transform.rotation);
		Invoke("playerDied",1);
	//	Destroy(gameOver,3f);
		
	}
	
	void GotHit(float damage){	
		
		hp -= damage;
		if(hp <= 0){
			Object klooni = Instantiate(explosion,GameObject.Find("spaceship").transform.position,GameObject.Find("spaceship").transform.rotation);
			Destroy(GameObject.Find("spaceship"));		
			Destroy(klooni,2);
			GameOverMan();
			
		}
		
	}
	
	void gotDead(){
		hp = 0;
		
	}
	void playerDied(){
		playerDead = true;
	}
	

	
}
