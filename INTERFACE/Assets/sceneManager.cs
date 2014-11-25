using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour {

	public string rootName = "activity";

	void Awake(){


	}

	// Use this for initialization
	void Start () {
	
	}

	public void Save(int index, Vector3 position){

		GameObject result = GameObject.Find("result");
		GameObject exist = GameObject.Find("result_"+index);
		if(exist!=null){
			Destroy(exist);
		}
		GameObject resultCopy = Instantiate(result,position,Quaternion.identity) as GameObject;
		resultCopy.name = "result_"+index;
		resultCopy.transform.parent = GameObject.Find("gallery").transform;


	}

	public void Check(int index){
		GameObject exist = GameObject.Find("result_"+index);
		if(exist!=null){
			Destroy(GameObject.Find("result"));
			Vector3 position = new Vector3(0,0,0);
			GameObject inGallery = Instantiate(exist,position,Quaternion.identity) as GameObject;
			inGallery.name = "result";
			inGallery.transform.parent = GameObject.Find(rootName).transform;


		}
		else{

			Debug.Log("notexist");
		}
		
		
		
	}

	public void Back(){

		Destroy(GameObject.Find(rootName));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
