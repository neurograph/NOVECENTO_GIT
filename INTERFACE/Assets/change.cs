using UnityEngine;
using System.Collections;
//using UnityEditor;


public class change : MonoBehaviour {
	Object prefab;
	GameObject clone;
	public GameObject master;
	public GameObject root ;
	GameObject resultScene;

	void OnLevelWasLoaded(int level){
		Debug.Log("----");


	}

	void Awake(){

	
		/*Debug.Log("Awake");
		master = GameObject.Find("master");
		GameObject exist = GameObject.Find("risultato2");
		resultScene = GameObject.Find("result");
		root = GameObject.Find("scena2");
		if(exist){
		
		}
		else{

		}*/

	}

	// Use this for initialization
	void Start () {
		master = GameObject.Find("master");
		resultScene = GameObject.Find("result");
		//Debug.Log(master.GetComponent<loadlevel>().scenes.GetValue("ogg"));
		//prefab = AssetDatabase.LoadAssetAtPath("Assets/PREFABS/prefab1.prefab", typeof(GameObject));
		root = GameObject.Find("scena2");
		//Debug.Log(master.GetComponent<loadlevel>().scenes.GetValue("ogg"));
		//prefab = AssetDatabase.LoadAssetAtPath("Assets/PREFABS/prefab1.prefab", typeof(GameObject));
		//var test = master.GetComponent<loadlevel>().scenes.GetObject("ogg");
		//Debug.Log(test.GetValue("prefab").ToString());
		/*if(master.GetComponent<loadlevel>().scenes.GetValue("ogg") != null){
			JSONObject stringa = master.GetComponent<loadlevel>().scenes.GetObject("ogg");
			string _str = stringa.GetValue("prefab").ToString();
			Debug.Log(_str);
			prefab = AssetDatabase.LoadAssetAtPath("Assets/PREFABS/prefab1.prefab", typeof(GameObject));
			clone =	Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
			clone.transform.parent = root.transform;
			
		}
		else{

		}*/
	
	}


	void  OnGUI(){

		if (GUI.Button(new Rect(10, 170, 50, 30), "Create")){
			clone =	Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
			clone.transform.parent = resultScene.transform;
		}
		if (GUI.Button(new Rect(10, 230, 50, 30), "Move")){
			clone.transform.position = new Vector3(3,transform.position.y, transform.position.z);}
		if (GUI.Button(new Rect(10, 270, 50, 30), "Save")){
			GameObject[] allObjects = GameObject.FindGameObjectsWithTag("prefab1");
			/*foreach(GameObject go in allObjects){
				oggetto = new JSONObject();
				oggetto.Add("prefab", go.tag);
				master.GetComponent<loadlevel>().scenes.Add("ogg", oggetto);

			}*/

			GameObject scene2 = Instantiate(resultScene, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			scene2.name = "risultato2";
			scene2.transform.parent = GameObject.Find("gallery").transform;
				//jsonscene.Add("ogg",oggetto);
		}
		if (GUI.Button(new Rect(10, 280, 50, 30), "BACK")){
			Destroy(root);}
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
