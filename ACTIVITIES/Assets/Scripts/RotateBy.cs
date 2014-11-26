using UnityEngine;
using System.Collections;

public class RotateBy : MonoBehaviour {
	
	public float speed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
//		if(speed < 80)
//			speed = 1;
//		
		transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
		
	
	}
}
