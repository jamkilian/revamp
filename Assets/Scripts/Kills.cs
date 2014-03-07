using UnityEngine;
using System.Collections;

public class Kills : MonoBehaviour 
{
	public static int kills;
	// Use this for initialization
	void Start () 
	{
		kills= 0;
	}
	void Update ()
	{
		PlayerPrefs.SetInt("Kills", kills);
		PlayerPrefs.SetString("PlayerName", "Dracula");
		PlayerPrefs.Save();

	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		GUI.Label(new Rect(0,30,100,25), "Kills: " + kills);
	}
}
