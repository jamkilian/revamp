using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour 
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
	 public abstract void OnGUI();
    public abstract void TakeDamage(float damage);
	
		
	
	
	 
}
