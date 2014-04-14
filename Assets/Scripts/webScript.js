#pragma strict

function Start () 
{
	var url = "http://nathanwalczak.net/revampDB/signIN.php?Data=nate";
	var www:WWW = new WWW(url);

	yield www;
}

function Update () 
{

}