using UnityEngine;
using System.Collections;

public class selettore2 : MonoBehaviour {
	
	public MonoBehaviour Altro;
	public GameObject selezione;
	private Vector3 initial;
	public Vector3 DIMtavolozza;
	sceneManager sceneManager;
	
	private GameObject[] pezziFisici;
	
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
				gameObject.GetComponent<sparaRAY2>().preso = selezione;
				gameObject.GetComponent<sparaRAY2>().enabled = true;	
				gameObject.GetComponent<selettore2>().enabled = false;	
			}
}
	}
	
	
	public void Avanti(){
		
		GameObject clone = Instantiate(selezione,initial,Quaternion.identity) as GameObject;
		clone.transform.localScale = DIMtavolozza;
		clone.transform.parent = GameObject.Find(sceneManager.rootName).transform;
		clone.transform.tag = "pezzi";

		if(selezione.transform.rigidbody != null){
		GameObject attacco = gameObject.GetComponent<sparaRAY2>().HT;
		selezione.transform.rigidbody.useGravity = true;
		Mesh mesh = selezione.GetComponent<MeshFilter>().mesh;
		if(attacco.GetComponent<MeshFilter>() == null)
		attacco.AddComponent<MeshFilter>();
		attacco.GetComponent<MeshFilter>().mesh = mesh;
		attacco.renderer.material = selezione.renderer.material;
		attacco.transform.localEulerAngles = selezione.transform.localEulerAngles;
		Destroy (selezione);
		}
		
		if(selezione != null){

			selezione.tag = "base";
			selezione = null;
		}
		gameObject.GetComponent<sparaRAY2>().enabled = false;	
		gameObject.GetComponent<selettore2>().enabled = true;	
		
	}

	public void Salva(){

			selezione = GameObject.Find("accrocchio");

		selezione.transform.parent = GameObject.Find("result").transform;
		selezione.transform.localPosition = new Vector3(0,0,0);
	}
}
