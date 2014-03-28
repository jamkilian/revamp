using UnityEngine;
using System.Collections;

public class Turret_Bullet : MonoBehaviour
{
	private GameObject target;	
	private Collider targetCollider;
	private float speed = 15f;
	
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
		}
		catch(MissingReferenceException){
			//Target was destroyed
			Destroy(this.gameObject);
		}
	}

	
	private void OnTriggerEnter(Collider hit)
	{
		if(hit.tag == "Enemy")
		{
			hit.SendMessage("Destroy");	
			Destroy (this.gameObject);
		}
	}
}
