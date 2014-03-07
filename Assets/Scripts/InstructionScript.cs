using UnityEngine;
using System.Collections;

public class InstructionScript : MonoBehaviour 
{
	
	void OnGUI() 
	{
			
	
		//Make a background box
		//GUI.Box (new Rect(10,10,100,90));
		
		//Make the first button, if pressed load level
		if(GUI.Button(new Rect(20,40,80,20), "Back"))
		{
			Application.LoadLevel("Menu");
		}

		
		
	
	}
}
