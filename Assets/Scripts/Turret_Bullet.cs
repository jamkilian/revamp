using UnityEngine;
using System.Collections;

public class Turret_Bullet : MonoBehaviour {
	private GameObject target;	
	private Collider targetCollider;
	public float speed = 7.0f;
	
	// Use this for initialization
	void Start () {
		//Pass the target from the collison on the turret to the 
		//new bullet instance
		this.target = tc.gameObject;
		this.targetCollider = tc;
	}
	
	// Update is called once per frame
	void Update () {
		TraceToTarget();
	}
	
	private void TraceToTarget(){
		float step = speed * Time.deltaTime;
		this.gameObject.transform.position = Vector3.MoveTowards(
			this.gameObject.transform.position, targetPosition, step);
	}
}
