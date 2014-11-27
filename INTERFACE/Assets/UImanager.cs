using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
	public GameObject[] gg;
	int actualPage = 1;
	float xx;
	float timeTrans = 0.5f;
	public GameObject selfie;
	Texture2D _tex;
	Texture2D selfieBox;
	WebCamTexture webcamTexture; 
	Sprite sprite;
	string frontName;
	string backName;
	public Language activeLang = Language.Italian;




	// Use this for initialization
	void Start(){
		selfie = GameObject.Find("selfie");
		WebCamDevice[] devices = WebCamTexture.devices;
		//detect the front camera to use for selfie
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log(devices[i].name);
			
			if (devices[i].isFrontFacing) {
				
				frontName = devices[i].name;
				
			} else {
				
				backName = devices[i].name;
				
			}
			
		}
	}


	void OnGUI(){
		//each effect create a texture that is converted to sprite for the header
		if (GUI.Button(new Rect(Screen.width-200, 22, 200, 22), "Grayscale"))
		{ 	 _tex = ImageProcess.SetGrayscale(selfieBox);
			sprite = Sprite.Create(ImageProcess.SetGrayscale(selfieBox), new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex ;
		}

		if (GUI.Button(new Rect(Screen.width-200, 44, 200, 22), "Negative"))
		{
			_tex = ImageProcess.SetNegative(selfieBox);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
			
		}
		if (GUI.Button(new Rect(Screen.width-200, 66, 200, 22), "Pixelate"))
		{
			_tex =ImageProcess.SetPixelate(selfieBox, 10);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
		}
		if (GUI.Button(new Rect(Screen.width-200, 88, 200, 22), "Sepia"))
		{
			_tex = ImageProcess.SetSepia(selfieBox);
			sprite = Sprite.Create(_tex, new Rect(0,0,_tex.width,_tex.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex;
		}
		if (GUI.Button(new Rect(Screen.width-200, 110, 200, 22), "Normal")){
			sprite = Sprite.Create(selfieBox, new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = selfieBox;
		}
		


	}

	void Awake () {
		//move pages out of the view
		gg = GameObject.FindGameObjectsWithTag("outPage");
		xx = (float)Screen.width;
		foreach (GameObject page in gg)
		{

			Debug.Log(page.GetComponent<RectTransform>().localPosition);
			RectTransform rt = page.GetComponent<RectTransform>();
			//becuase pivot of the panels is in the middle
			rt.localPosition = new Vector3(xx+xx/2, rt.localPosition.y, rt.localPosition.z);
		}



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectLanguage(string lang){
		//receive language from button click
		Debug.Log(lang);
		switch(lang){
		case "it":{
			activeLang = Language.Italian;
			break;

		}
		case "en":{
			activeLang = Language.English;
			break;
			
		}
		case "fr":{
			activeLang = Language.French;
			break;
			
		}
		default:break;


		}
		//load file of the language
		LanguageManager.LoadLanguageFile(activeLang);

		GameObject[] labels = GameObject.FindGameObjectsWithTag("label");
		foreach (GameObject ll in labels)
		{
			//each label receive text from a variable called like it's name
			ll.GetComponent<Text>().text = LanguageManager.GetText(ll.name);	

		
		}


		changePage("language", "identity");


	}

	public void showHeader(){
		//header need to be separate from the pages and it's called once
		GameObject header = GameObject.Find("header");
		GameObject.Find("nameUser").GetComponent<Text>().text = GameObject.Find("nameValue").GetComponent<Text>().text;
		RectTransform rt = header.GetComponent<RectTransform>();
		Hashtable args = new Hashtable();
		args.Add("position",new Vector3(0, rt.localPosition.y, rt.localPosition.z));
		args.Add("time",timeTrans);
		args.Add("islocal", true);
		args.Add("oncompletetarget", transform.gameObject);
		args.Add ("oncomplete", "startCamera");
		iTween.MoveTo(rt.gameObject, args);
		changePage("page1", "page2");



	}

	public void startCamera(){
		//start capture - SELFIE
		//object like selfie,selfieBox,userimg are scaled in negative because webcamtexture is flipped!!
		webcamTexture = new WebCamTexture();
		//to keep the frontcamera i'll insert a line like this 
		//-------> webcamTexture.deviceName = frontName;
		//frontName is setted in the start looping through devices
		webcamTexture.Play();
		selfie.GetComponent<RawImage>().texture = webcamTexture;
	
		

	}

	public void gotUser(){
		//after selfie
		changePage("page2","page3");

	}

	public void capture (){

		selfieBox = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
		selfieBox.SetPixels((selfie.GetComponent<RawImage>().texture as WebCamTexture).GetPixels());
		selfieBox.Apply(); 
		sprite = Sprite.Create(selfieBox, new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
		GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
		GameObject.Find("userimg").GetComponent<Image>().overrideSprite = sprite;
		changePage("page2", "page3");
		//selfie.GetComponent<RawImage>().enabled = false;

	} 
	
	

	public void changePage(string prev, string next){

		GameObject exitPage = GameObject.Find(prev);
		GameObject enterPage = GameObject.Find(next);
		RectTransform rt = exitPage.GetComponent<RectTransform>();
		Hashtable args = new Hashtable();
		args.Add("position",new Vector3(-(xx+xx/2), rt.localPosition.y, rt.localPosition.z));
		args.Add("time",timeTrans);
		args.Add("islocal", true);
		iTween.MoveTo(rt.gameObject, args);
		//args.Remove("position");
		args["position"] = new Vector3(0, rt.localPosition.y, rt.localPosition.z);
		iTween.MoveTo(enterPage, args);


	}
}
