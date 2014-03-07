using UnityEngine;
using System.Collections;

public class CreditScript : MonoBehaviour 
{
	
	void OnGUI() 
	{
			
	
		//Make a background box
		//GUI.Box (new Rect(10,10,100,90));
		
		//Make the first button, if pressed load level
		if(GUI.Button(new Rect(20,40,80,20), "Play Again"))
		{
			Application.LoadLevel("Level1");
		}
		// Second Button
		if(GUI.Button(new Rect(20,70,80,20), "Exit"))
		{
			Application.Quit();
		}
		
		
		// Third button
		/*if(GUI.Button(new Rect(20,100,80,20),"HighScore"))
		{
			Application.LoadLevel("HighScore");
		}*/
	}
}
