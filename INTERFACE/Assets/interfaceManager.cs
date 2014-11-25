using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interfaceManager : MonoBehaviour {
	public GameObject selfie;
	Texture2D _tex;
	Texture2D selfieBox;
	WebCamTexture webcamTexture; 
	Sprite sprite;

	void OnGUI(){
		/*
		if (GUI.Button(new Rect(2, 2, 200, 22), "CAMERA")){
			startCamera();
		}

		if (GUI.Button(new Rect(2, 32, 200, 22), "SCATTA")){
			//webcamTexture.Stop();
			//var pixels1 = webcamTexture.GetPixels(0, 0, webcamTexture.width, webcamTexture.height);
			//selfieBox.SetPixels(pixels1);
			//_tex = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
			selfieBox = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
			selfieBox.SetPixels((selfie.renderer.material.mainTexture as WebCamTexture).GetPixels());
			selfieBox.Apply(); 
			//GameObject.Find("selfieBox").renderer.material.mainTexture =  selfieBox;
			sprite = Sprite.Create(selfieBox, new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().sprite = sprite;
			
		}*/

		if (GUI.Button(new Rect(Screen.width-200, 2, 200, 22), "Grayscale"))
		{ 	 _tex = ImageProcess.SetGrayscale(selfieBox);
			sprite = Sprite.Create(ImageProcess.SetGrayscale(selfieBox), new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex ;
		}
			//sprite = ImageProcess.SetGrayscale(selfieBox);
		if (GUI.Button(new Rect(Screen.width-200, 24, 200, 22), "Negative"))
		{
			_tex = ImageProcess.SetNegative(selfieBox);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
			
		}
		if (GUI.Button(new Rect(Screen.width-200, 46, 200, 22), "Pixelate"))
		{
			_tex =ImageProcess.SetPixelate(selfieBox, 10);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
		}
		if (GUI.Button(new Rect(Screen.width-200, 68, 200, 22), "Sepia"))
		{
			_tex = ImageProcess.SetSepia(selfieBox);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
		}
		if (GUI.Button(new Rect(Screen.width-200, 90, 200, 22), "Normal")){
			sprite = Sprite.Create(selfieBox, new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = selfieBox;
		}

	}


	public void startCamera(){

		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
		selfie.renderer.material.mainTexture = webcamTexture;
		//GameObject.Find("_raw").GetComponent<SpriteRenderer> ().material.mainTexture = webcamTexture;

		//selfie.GetComponent<SpriteRenderer>().renderer.material.mainTexture = webcamTexture;
		//selfie.GetComponent<Image>().renderer.material.mainTexture = webcamTexture;

	}



	// Use this for initialization
	void Start () {

		selfie = GameObject.Find("selfie");
		//selfie = GameObject.Find("_webcam");
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
