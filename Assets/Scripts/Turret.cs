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
	private float turretDistance = 15;
	public Ray hitRange;

	// Use this for initialization
	void Start()
	{
		hitRange = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward * turretDistance);
	}

	// Update is called once per frame
	void Update()
	{
		Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.forward * 15, Color.cyan, 5f);

	}

	Collider SearchForTarget()
	{
		RaycastHit hit;
		if (Physics.Raycast(hitRange, out hit))
		{

			return hit.collider;
		}
		else{
			return hit.collider;
		}
	}
}