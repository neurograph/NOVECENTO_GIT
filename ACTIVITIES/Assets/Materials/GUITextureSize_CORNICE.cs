using UnityEngine;
using System.Collections;

public class GUITextureSize_CORNICE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.guiTexture.pixelInset = new Rect(-Screen.width/2,-Screen.height/2,Screen.width,Screen.height);
		
		
		
	
	}
}
