using UnityEngine;
using System.Collections;

public class selettore : MonoBehaviour {
	
	public MonoBehaviour Altro;
	public GameObject selezione;
	private Vector3 initial;
	public Vector3 DIMtavolozza;
	sceneManager sceneManager;
	// Use this for initialization
	void Start () {
		sceneManager = GameObject.Find("sceneManager").GetComponent<sceneManager>();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000)  ){
		if(hit.transform.tag != "base"){
        Debug.DrawLine(ray.origin, hit.point);
		selezione = hit.transform.gameObject;
		initial = hit.transform.position;
			
		
			}else if (selezione != null){

				gameObject.GetComponent<sparaRAY>().preso = selezione;
				gameObject.GetComponent<sparaRAY>().enabled = true;	
				gameObject.GetComponent<selettore>().enabled = false;

			}
}
	}
	
	
	public void Avanti(){
		
		GameObject clone = Instantiate(selezione,initial,Quaternion.identity) as GameObject;
		clone.transform.localScale = DIMtavolozza;
		clone.transform.parent = GameObject.Find(sceneManager.rootName).transform;
		clone.transform.tag = "pezzi";

		selezione.transform.parent = GameObject.Find("result").transform;
		selezione.tag = "base";
		selezione = null;

		gameObject.GetComponent<sparaRAY>().enabled = false;	
		gameObject.GetComponent<selettore>().enabled = true;	
		
	}
}
