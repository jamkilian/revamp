using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	/* 1) Turrets should only attack enemies in it's lane
	 * 2) Turrets should attack closest enemy
	 *
	 * 
	 * 
	 */
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	    Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.forward, Color.cyan, 5f);
	}
}
