using UnityEngine;
using System.Collections;

public class LineDispenser : MonoBehaviour {

	public GameObject primo;
	public GameObject secondo;
	public Color COLOR;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		
		int x = Input.mousePosition.x;
		int y = Input.mousePosition.y;
		COLOR = GetPixel(x, y);
		
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "chiodoUP"){
			primo = hit.transform.gameObject;
			primo.renderer.material.color = Color.red;
			print(primo.name);


			
		} else if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "chiodoDWN"){
			secondo = hit.transform.gameObject;
			secondo.renderer.material.color = Color.red;
			print(secondo.name);
			if(primo != null){
				primo.GetComponent<LineRenderer>().SetPosition(0, primo.transform.position);
				primo.GetComponent<LineRenderer>().SetPosition(1, secondo.transform.position);

			}

			
		}
		
	}	

		
	
}
