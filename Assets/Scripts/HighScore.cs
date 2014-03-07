using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	void OnGUI()
	{
		/*if(GUI.Button(new Rect(240,90,160,40),"Play Again"))
		{
			Application.LoadLevel("level1");
		}
		
		if(GUI.Button(new Rect(240,140,160,40),"Back to Menu"))
		{
			Application.LoadLevel("Menu");
		}*/

		if(GUI.Button(new Rect(20,100,80,20),"Clear Kills"))
		{
			PlayerPrefs.DeleteAll();
			//PlayerPrefs.DeleteKey("Score")
		}
		if(PlayerPrefs.HasKey("Kills"))
		{
			GUI.Label(new Rect(20,130,160,40), PlayerPrefs.GetString("PlayerName")+" : " + PlayerPrefs.GetInt("Kills"));
		}
		else
		{
			GUI.Label(new Rect(20,130,160,40),"No kills Yet!");
		}
	}
}