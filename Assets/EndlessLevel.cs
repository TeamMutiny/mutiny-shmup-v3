using UnityEngine;
using System.Collections;

public class EndlessLevel: MonoBehaviour {
	
	private float time;
	public float bossTime = 2.0f;
	public GameObject bossObject;
	public float warningTime;
	private GameObject boss = null;
	private GameObject warning;
	private bool warningDone = false;
	private bool bossFight = false;
	// Use this for initialization
	void Start () {
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		GameObject.Find("background1").gameObject.renderer.material.color = newColor;
		GameObject.Find("background2").gameObject.renderer.material.color = newColor;
		time = 0;


	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//Debug.Log(time);
		if(time > bossTime && !bossFight){
			bossFight = true;
			GameObject.Find("Spawner").SendMessage("StopSpawner");
			boss = (GameObject) Instantiate(bossObject, new Vector3(0.0f,50.0f,-4.0f), Quaternion.identity);
			boss.transform.Rotate(new Vector3(0.0f,180.0f,180.0f));
			if(!warningDone){
			warning = GameObject.Find("Warning");
			warning.transform.position = new Vector3(0.5f,0.4851f,0f);
			Destroy(warning, warningTime);
			warningDone = true;
			}
		}
		if(time > bossTime && bossFight && boss == null){
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			GameObject.Find("background1").gameObject.renderer.material.color = newColor;
			GameObject.Find("background2").gameObject.renderer.material.color = newColor;
			GameObject.Find("Spawner").SendMessage("StartSpawner");
			bossFight = false;
			time = 0;

		}
		
	}
}
