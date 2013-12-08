using UnityEngine;
using System.Collections;

public class BGStretch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect(0f,0f,Screen.width,Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	guiTexture.pixelInset = new Rect(0f,0f,Screen.width,Screen.height);
	}
}
