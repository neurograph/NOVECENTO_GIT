﻿using UnityEngine;
using System.Collections;

public class ruotaCapsula : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(100*Time.deltaTime,0,0);
	
	}
}
