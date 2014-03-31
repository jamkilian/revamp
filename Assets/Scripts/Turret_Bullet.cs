using UnityEngine;
using System.Collections;

public class Turret_Bullet : MonoBehaviour
{
	private GameObject target;	
	private Collider targetCollider;
	private float speed = 15f;
	private float attackDamage = 50f;
	
	// Use this for initialization
	void Start () {	
	}
	
	public void Initialize(Collider tc)
	{
		this.target = tc.gameObject;
		this.targetCollider = tc;
	}
	
	// Update is called once per frame
	void Update () {
		TraceToTarget();
	}
	
	private void TraceToTarget(){
		float step = speed * Time.deltaTime;
		//Debug.Log(step);
		try{
			this.gameObject.transform.position = Vector3.MoveTowards(
			this.gameObject.transform.position, target.transform.position, step);
			//Debug.Log("I'm at : " + gameObject.transform.position + " to : " + target.transform.position);
		}
		catch(MissingReferenceException){
			//Target was destroyed
			Destroy(this.gameObject);
		}
	}

	
	private void OnTriggerStay(Collider hit)
	{
		Debug.Log("I Hit " + hit);

		if(hit.tag == "Enemy")
		{
			hit.SendMessage("TakeDamage", attackDamage);
			Destroy(this.gameObject);
		}
	}
}
