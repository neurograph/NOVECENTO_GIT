using UnityEngine;
using System.Collections;

public class Puppeteer : MonoBehaviour
{
	public Transform character;
	public Transform arrow; 
	
	public bool selezionato;
	
	Hashtable ht = new Hashtable();
	
	private GameObject[] pezzetti;

	
	void Start(){
		//Screen.showCursor=false;
		
		pezzetti = GameObject.FindGameObjectsWithTag("pezzi");
	}
	
	void Update (){
	
	
		
		
	if(selezionato){
	
	PlaceArrow();	
	
	if(Input.GetMouseButton(0)){
	
	iTween.MoveTo(gameObject,new Vector3(arrow.position.x,arrow.position.y,arrow.position.z),1);
	
	ht.Clear();
	ht.Add("position",arrow.transform.position);
	ht.Add("time",1);
	ht.Add("oncomplete","riparti");
	ht.Add("oncompletetarget",gameObject);
				
	 iTween.MoveTo(character.gameObject,ht);
				
				
	}
			
	}
		
		else
			
			
	Seleziona();
			
	}
	
	void PlaceArrow(){
		
		arrow.GetComponentInChildren<Renderer>().enabled = true;
		
		RaycastHit hit = new RaycastHit();
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		
		
		if (Physics.Raycast (cameraRay.origin,cameraRay.direction,out hit, 100)) {
			
			
			
			iTween.MoveUpdate(arrow.gameObject,hit.point,.9f);
			
			arrow.transform.LookAt(Camera.main.transform.position);
		
		}	
	}
	
	void Seleziona(){
		
		arrow.GetComponentInChildren<Renderer>().enabled = false;
		
		
		if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
               
				if (hit.collider != null && hit.transform.tag == "pezzi"){
					//hit.transform.renderer.material.color = Color.blue;
			
			        character = GameObject.Instantiate(hit.transform) as Transform;
				    character.tag = "messo";
				    character.transform.localScale = new Vector3(1,1,1);
				    character.transform.localEulerAngles = new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
				    character.transform.position = Camera.main.transform.position;
				    StartCoroutine(riseleziona());
			
			
			foreach(GameObject pezzo in pezzetti){
		      pezzo.layer = 2;
		    }
			
			 
			}
			
		}
	}
	
	
	public IEnumerator riseleziona(){
		
		yield return new WaitForSeconds(1);
		
		selezionato = true;
	}
                
                
            
       
			
				
	
	
			
	
	
	public void riparti(){
		
		print ("fatto");
		character = null;
		
		foreach(GameObject pezzo in pezzetti){
		
			pezzo.layer = 0;
		}
		
		selezionato = false;
		
	}
}

