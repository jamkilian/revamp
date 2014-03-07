using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public int maxHealth = 100;
	public int curHealth = 100;
	public bool istrig = false;
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
		
		GUI.Box (new Rect(10,40,healthBarLength,20), curHealth + "/" + maxHealth);
	}
	public void AddjustCurrentHealth(int adj)
	{
		curHealth += adj;
		
		if(curHealth < 1)
		{
			curHealth = 0;
		}
		
		if(curHealth == 0)
		{
			Object.Destroy(this.gameObject);
			Application.LoadLevel("Credits");
		}
		
		if(curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}
		
		if(maxHealth < 1)
		{
			maxHealth = 1;
		}
		
		healthBarLength = (Screen.width/2) * (curHealth / (float)maxHealth);
	}
	void OnTriggerStay(Collider other)
	{
		//Debug.Log("OnTriggerEnter");
		if (other.gameObject.tag == "Enemy")
			istrig = true;
		else
			istrig = false;
		
	}
}