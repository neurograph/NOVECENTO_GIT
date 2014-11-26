using UnityEngine;
using System.Collections;

public class sparaRAY2 : MonoBehaviour {
	
	private Vector3 final;
	public GameObject preso;
	public MonoBehaviour altro;
	public bool primoContatto = true;
	
	public GameObject HT;
	// Use this for initialization
	void Start () {
		
		
	}
	
	void Update(){
		
		if(primoContatto && preso != null){
			final = preso.transform.position;
		}
		
		  
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "base"){
		primoContatto = false;
        Debug.DrawLine(ray.origin, hit.point);
	    
		HT = hit.transform.gameObject;
		final = hit.point;
		
		}
		if(final != null && preso != null){
		preso.transform.localScale = new Vector3(1,1,1);
		iTween.MoveUpdate(preso,final,.9f);
		}
			
		
		
    }
	
	void Avanti(){
	
		
		//final = null;
		preso = null;
		primoContatto = true;
		
	}
}
