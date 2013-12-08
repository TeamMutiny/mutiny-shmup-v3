using UnityEngine;
using System.Collections;

public class EndlessLevel: MonoBehaviour {
	
	private float time;
	public float bossTime = 2.0f;
	public GameObject Boss1;
	public GameObject Boss2;
	public float warningTime;
	private GameObject boss = null;
	private GameObject warning;
	private bool warningDone = false;
	private bool bossFight = false;
	private int nextBoss = 2;
	// Use this for initialization
	void Start () {
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		GameObject.Find("background1").gameObject.renderer.material.color = newColor;
		GameObject.Find("background2").gameObject.renderer.material.color = newColor;
		warning = Resources.Load("Warning") as GameObject;
		time = 0;


	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//Debug.Log(time);
		if(time > bossTime && !bossFight){
			bossFight = true;
			GameObject.Find("Spawner").SendMessage("StopSpawner");
			if(nextBoss == 1){
			boss = (GameObject) Instantiate(Boss1, new Vector3(0.0f,50.0f,-4.0f), Quaternion.identity);
				nextBoss = 2;
				boss.transform.Rotate(new Vector3(0.0f,180.0f,180.0f));
			}
			else{
			boss = (GameObject) Instantiate(Boss2, new Vector3(0.0f,50.0f,-4.0f), Quaternion.identity);	
				nextBoss = 1;
				
			}
			
			if(!warningDone){
			Object warningClone = Instantiate(warning,new Vector3(0.5f,0.5f,0.5f),transform.rotation);
			Destroy(warningClone, warningTime);
			warningDone = true;
			}
		}
		if(time > bossTime && bossFight && boss == null){
			warningDone = false;
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			GameObject.Find("background1").gameObject.renderer.material.color = newColor;
			GameObject.Find("background2").gameObject.renderer.material.color = newColor;
			GameObject.Find("Spawner").SendMessage("StartSpawner");
			bossFight = false;
			time = 0;

		}
		
	}
}
