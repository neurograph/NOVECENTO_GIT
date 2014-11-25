using UnityEngine;
using System.Collections;

public class AVANTI : MonoBehaviour {
	
	public Vector3 posizioneInGalleria;
	
	public int Index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		
		if(GUI.Button(new Rect (Screen.width-Screen.width/8,Screen.height/8,Screen.width/8,Screen.height/8),"CONFERMA")){
			
		print ("AVANTI");	
			
		SendMessage("Avanti");
			
		}
		
		
		if(GUI.Button(new Rect (Screen.width-Screen.width/8,2*Screen.height/8,Screen.width/8,Screen.height/8),"SALVA")){
		print ("SALVA");	
			
	   Destroy(GameObject.FindGameObjectWithTag("opera_" + Index.ToString()));
	   GameObject ATT = GameObject.FindGameObjectWithTag("A_" + Index.ToString());
			
	   GameObject opera = Instantiate(ATT,posizioneInGalleria,Quaternion.identity) as GameObject;
	   opera.tag = "opera_" + Index.ToString();
			
		}
		
	
	
	}
}
