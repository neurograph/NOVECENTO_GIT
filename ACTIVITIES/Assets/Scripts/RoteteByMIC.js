#pragma strict

var speed:float;

function Start () {

}

function Update () {
//scales the gameObject heigt based on input stream gathered from MicControl.loudness
//transform.localScale=Vector3(1,MicControl.loudness,1);

transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);

if(MicControl.loudness > 10 && MicControl.loudness < 30){
speed = Mathf.Lerp(0,MicControl.loudness*10,6);
}else{
if(speed > 0)
speed -= 0.2;
}

//print(speed);



}