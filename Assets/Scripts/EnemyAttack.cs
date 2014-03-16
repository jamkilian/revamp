using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject target;
	public ServerHealth sh;


	//Use this for initialization
	void Start () 
	{
		target = GameObject.Find("Server");
		sh = (ServerHealth)target.GetComponent("ServerHealth");
		
	
	}
	
	 //Update is called once per frame
	void Update () 
	{
		
	}
	
	

	void OnTriggerEnter (Collider other)
	{
		 if (other.gameObject.name == "Server")
		{
			//Debug.Log("Collided with server");
			EnemyAnimation walk;
			walk = this.GetComponent<EnemyAnimation>();
			walk.iswalk = true;
			sh.AddjustCurrentHealth(-10);
			
		}
		
	}
}
	
