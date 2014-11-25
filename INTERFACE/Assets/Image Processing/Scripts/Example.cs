using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Example : MonoBehaviour {
    public Texture2D tex;
    public GameObject cube;
	
    void Update () {
        cube.transform.Rotate(Vector3.up);
    }

    void OnGUI()
    {
		if (GUI.Button(new Rect(2, 2, 200, 22), "Grayscale"))
			cube.renderer.material.mainTexture = ImageProcess.SetGrayscale(tex) as Texture;	
		if (GUI.Button(new Rect(2, 24, 200, 22), "Negative"))
			cube.renderer.material.mainTexture = ImageProcess.SetNegative(tex) as Texture;	
		if (GUI.Button(new Rect(2, 46, 200, 22), "Pixelate"))
			cube.renderer.material.mainTexture = ImageProcess.SetPixelate(tex, 10) as Texture;			
		if (GUI.Button(new Rect(2, 68, 200, 22), "Sepia"))
			cube.renderer.material.mainTexture = ImageProcess.SetSepia(tex) as Texture;	

    }
}