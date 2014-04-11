using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : BaseDestroyable
{
	/* 1) Turrets should only attack enemies in it's lane
	 * 2) Turrets should attack closest enemy
	 */
	private Object bulletPrefab;
	private float turretDistance = 15;
	public Ray hitRange;
	public float firingDelay = 1.3f;
	private float turretRefreshTimes = 0;

	// Use this for initialization
	private void Start()
	{
		this.BaseStart();
		bulletPrefab = Resources.Load("TurretBullet");
		hitRange = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward * turretDistance);
	}
	
	//Initiailize the bullet with location, and target
	private void ShootBullet(Collider targetCollider)
	{
		//Debug.Log("Shooting!");
		Transform barrelPosition = transform.Find("Turret_Barrel");
		GameObject bullet = Instantiate(bulletPrefab, barrelPosition.position, Quaternion.identity) as GameObject;
		Turret_Bullet bulletScript = bullet.GetComponent<Turret_Bullet>();
		bulletScript.Initialize(targetCollider);
		turretRefreshTimes = Time.time + firingDelay;
	}

	// Update is called once per frame
	private void Update()
	{
		Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.up * turretDistance, Color.cyan, 5f);
		if (turretRefreshTimes <= Time.time)
		{
			AttackTarget(SearchForTarget());
		}
	}

	private Collider SearchForTarget()
	{
		RaycastHit hit;
		if (Physics.Raycast(hitRange, out hit, turretDistance))
		{
			return hit.collider;
		}
		else
		{
			return hit.collider;
		}
	}

	private void AttackTarget(Collider targetCollider)
	{
		//Debug.Log(targetCollider);
		if (targetCollider != null)
		{
			if (targetCollider.tag == "Enemy")
			{
				ShootBullet(targetCollider);
			}
		}
	}

	
}