using UnityEngine;
using System.Collections;

public class OnMouseOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter(){
	
		transform.renderer.material.color = Color.red;
		
	}
	
	
	void OnMouseExit(){
	
		transform.renderer.material.color = Color.white;
		
	}
}
