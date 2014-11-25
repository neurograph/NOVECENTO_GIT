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
	public Language activeLang = Language.Italian;


	// Use this for initialization
	void Start(){
		selfie = GameObject.Find("selfie");
		WebCamDevice[] devices = WebCamTexture.devices;
		//detect the front camera to use for selfie
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log(devices[i].name);
			
			if (devices[i].isFrontFacing) {
				
				//frontCamName = devices[i].name;
				
			} else {
				
				//backCamName = devices[i].name;
				
			}
			
		}
	}


	void OnGUI(){

		if (GUI.Button(new Rect(Screen.width-200, 22, 200, 22), "Grayscale"))
		{ 	 _tex = ImageProcess.SetGrayscale(selfieBox);
			sprite = Sprite.Create(ImageProcess.SetGrayscale(selfieBox), new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
			GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
			//GameObject.Find("_selfieBox").renderer.material.mainTexture = _tex ;
		}
		//sprite = ImageProcess.SetGrayscale(selfieBox);
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

		gg = GameObject.FindGameObjectsWithTag("outPage");
		xx = (float)Screen.width;
		foreach (GameObject page in gg)
		{

			Debug.Log(page.GetComponent<RectTransform>().localPosition);
			RectTransform rt = page.GetComponent<RectTransform>();
			rt.localPosition = new Vector3(xx, rt.localPosition.y, rt.localPosition.z);
		}

		selfie = GameObject.Find("selfie");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectLanguage(string lang){

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

		LanguageManager.LoadLanguageFile(activeLang);

		GameObject[] labels = GameObject.FindGameObjectsWithTag("label");
		foreach (GameObject ll in labels)
		{
			ll.GetComponent<Text>().text = LanguageManager.GetText(ll.name);	

		
		}


		changePage("language", "identity");


		              //new Vector3(-xx, rt.localPosition.y, rt.localPosition.z), 2f
		//rt.localPosition = new Vector3(-xx, rt.localPosition.y, rt.localPosition.z);

	}

	public void showHeader(){
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
		selfie.renderer.enabled = true;
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
		GameObject.Find("guitexture").GetComponent<GUITexture>().texture = webcamTexture;
		selfie.renderer.material.mainTexture = webcamTexture;
		

	}

	public void gotUser(){

		changePage("page2","page3");

	}

	public void capture (){
		//selfie.renderer.enabled = false;
		selfieBox = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
		selfieBox.SetPixels((selfie.renderer.material.mainTexture as WebCamTexture).GetPixels());
		selfieBox.Apply(); 
		sprite = Sprite.Create(selfieBox, new Rect(0,0,selfieBox.width,selfieBox.height), new Vector2(0,0));
		GameObject.Find("selfieBox").GetComponent<Image>().overrideSprite = sprite;
		//GameObject.Find("userimg").GetComponent<Image>().overrideSprite = sprite;
		//changePage("page2", "page3");

	} 
	
	

	public void changePage(string prev, string next){

		GameObject exitPage = GameObject.Find(prev);
		GameObject enterPage = GameObject.Find(next);
		RectTransform rt = exitPage.GetComponent<RectTransform>();
		Hashtable args = new Hashtable();
		args.Add("position",new Vector3(-xx, rt.localPosition.y, rt.localPosition.z));
		args.Add("time",timeTrans);
		args.Add("islocal", true);
		iTween.MoveTo(rt.gameObject, args);
		//args.Remove("position");
		args["position"] = new Vector3(0, rt.localPosition.y, rt.localPosition.z);
		iTween.MoveTo(enterPage, args);


	}
}
