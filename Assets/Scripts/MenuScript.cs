using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	public Texture2D background,LOGO;
	public GUISkin myskin;
	
	private string clicked ="";
	
	private void OnGUI()
	{
		//background
		if(background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background);
		
		
		{
			//LOGO
			if(LOGO != null)
				GUI.DrawTexture(new Rect((Screen.width/2)-225,100,500,150),LOGO);
		}
		if (clicked=="")	
		{
			GUI.skin=myskin;
			//Buttons
			if(GUI.Button (new Rect((Screen.width/2)-150,Screen.height/2,300,30),"Play Game"))
		{
			// code after clicking play game
				Application.LoadLevel("Level1");
		}
		if(GUI.Button (new Rect((Screen.width/2)-150,(Screen.height/2)+50,300,30),"Quit"))
		{
			Application.Quit();
		}
			if(GUI.Button (new Rect((Screen.width/2)-150,(Screen.height/2)+100,300,30),"Credits"))
		{
			// code after clicking play game
				Application.LoadLevel("Credits");
		}
				if(GUI.Button (new Rect((Screen.width/2)-150,(Screen.height/2)+150,300,30),"Instructions"))
		{
			// code after clicking play game
				Application.LoadLevel("Instructions");
		}
		
		
	
	}
		
	
}
}
