using UnityEngine;
using System.Collections;

public class AVANTI : MonoBehaviour {
	
	public Vector3 posizioneInGalleria;
	
	public int Index;
	public GameObject root;
	sceneManager sceneManager;
	void Awake(){
		sceneManager = GameObject.Find("sceneManager").GetComponent<sceneManager>();
		sceneManager.Check(Index);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		
			if(GUI.Button(new Rect (Screen.width-Screen.width/8,Screen.height/8,Screen.width/8,Screen.height/8),"CONFERMA")){
			
		print ("AVANTI");	
			
			SendMessage("Avanti");
			
		}

		if(GUI.Button(new Rect (Screen.width-Screen.width/8,3*Screen.height/8,Screen.width/8,Screen.height/8),"back")){
			
			print ("BACK");	
			sceneManager.Back();
			

			
		}
		
		
		if(GUI.Button(new Rect (Screen.width-Screen.width/8,2*Screen.height/8,Screen.width/8,Screen.height/8),"SALVA")){
		    print ("SALVA");	
			SendMessage("Salva",SendMessageOptions.DontRequireReceiver);
			sceneManager.Save(Index,posizioneInGalleria);	
	   //Destroy(GameObject.FindGameObjectWithTag("opera_" + Index.ToString()));
	   
			
		}
		
	
	
	}
}
