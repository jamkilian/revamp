﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject target;
	public ServerHealth eh;


	 //Use this for initialization
	void Start () 
	{
		target = GameObject.Find("Server");
		eh = (ServerHealth)target.GetComponent("Server");
		
	
	}
	
	 //Update is called once per frame
	void Update () 
	{
		
	}
	
	

	void OnTriggerEnter (Collider other)
	{
		 if (other.gameObject.name == "Server")
		{
<<<<<<< HEAD
 			//Debug.Log("Collided with server");
=======
 			Debug.Log("Collided with server");
>>>>>>> cdffd55... Initial Commit of project
			EnemyAnimation walk;
			walk = this.GetComponent<EnemyAnimation>();
			walk.iswalk = true;
			ServerHealth eh = (ServerHealth)target.GetComponent("ServerHealth");
			eh.AddjustCurrentHealth(-10);
       		
		}
		
	}
}
	
