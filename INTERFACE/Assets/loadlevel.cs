using UnityEngine;
using System.Collections;

public class loadlevel : MonoBehaviour {



	void Awake(){
		DontDestroyOnLoad(transform.gameObject);


	}

	// Use this for initialization
	void Start () {
	
	}


	void  OnGUI(){
		if (GUI.Button(new Rect(10, 70, 50, 30), "level"))
			Application.LoadLevelAdditive(2);


	}
	// Update is called once per frame
	void Update () {

	}
}
