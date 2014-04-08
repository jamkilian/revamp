using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	private int score = 0;
	
	void Awake()
	{
		DeadState.OnDeath += IncreaseScore;
	}
	
	void IncreaseScore()
	{
		score += 10;
		Debug.Log(score);	
	}
	
	void OnGUI()
	{

		if(GUI.Button(new Rect(20,100,80,20),"Clear Kills"))
		{
			PlayerPrefs.DeleteAll();
			//PlayerPrefs.DeleteKey("Score")
		}
		if(PlayerPrefs.HasKey("Kills"))
		{
            GUI.Label(new Rect(20, 130, 160, 40), PlayerPrefs.GetString("PlayerName") + " : " + PlayerPrefs.GetInt("Kills") + " : " + PlayerPrefs.GetInt("Waves"));
		}
        
	}
}