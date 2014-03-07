using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 170;
	public GUISkin myskin;
	bool paused = false;
	
			


	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		Time.timeScale = 1;	
		
			
	}
	
	void OnGUI ()
	{
		
		GUI.skin=myskin;
		if(paused)
		{
			GUI.BeginGroup(new Rect(((Screen.width/2) - (groupWidth/2)),((Screen.height/2) - (groupHeight/2)),groupWidth, groupHeight));
			if(GUI.Button (new Rect(0,0,buttonWidth, buttonHeight),"Main Menu"))
			{
				Application.LoadLevel("Menu");
			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Restart Game"))
			{
				Application.LoadLevel("Level1");
			}
			if(GUI.Button (new Rect(0,120,buttonWidth,buttonHeight),"Quit Game"))
			{
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			paused = togglePause();
		
	}
	bool togglePause()
	{
		if(Time.timeScale == 0)
		{
			GameObject.Find("Player").GetComponent<PlayerScript>().enabled = true;
			Screen.lockCursor = true;
			Time.timeScale = 1;
			Screen.showCursor = false;
			return(false);
		

		}
		else
		{
			GameObject.Find("Player").GetComponent<PlayerScript>().enabled = false;
			Screen.lockCursor = false;
			Time.timeScale = 0;
			Screen.showCursor = true;
			return(true);
			
		}
	}
}
