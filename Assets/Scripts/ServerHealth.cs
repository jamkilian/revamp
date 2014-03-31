using UnityEngine;
using System.Collections;

public class ServerHealth : MonoBehaviour 
{
	public float maxHealth = 100f;
	public float curHealth = 100f;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () 
	{
		
		healthBarLength = Screen.width/2;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//AddjustCurrentHealth(0);
	
	}
	void OnGUI()
	{
		GUI.Box (new Rect(10,10,healthBarLength,20), curHealth + "/" + maxHealth);
	}
	public void TakeDamage(float damage)
	{
		
		
		if((curHealth -= damage) <= 0)
		{
			Application.LoadLevel("Credits");
			//Object.Destroy(this.gameObject);
			//Application.LoadLevel("Credits");
		}
		else if(curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}
		
		if(maxHealth < 1)
		{
			maxHealth = 1;
		}
		
		healthBarLength = (Screen.width/2) * (curHealth / (float)maxHealth);
	}
	
	 
}
