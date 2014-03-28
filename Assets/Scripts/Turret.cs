using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
	/* 1) Turrets should only attack enemies in it's lane
	 * 2) Turrets should attack closest enemy
	 *
	 * 
	 * 
	 */
	private Object bulletPrefab;
	private float turretDistance = 15;
	public Ray hitRange;
	public float turretDelay = 2.7f;
	private Queue<float> turretRefreshTimes;

	// Use this for initialization
	private void Start()
	{
		bulletPrefab = Resources.Load("TurretBullet");
		hitRange = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward * turretDistance);

		turretRefreshTimes = new Queue<float>();
	}
	
	//Initiailize the bullet with location, and target
	private void ShootBullet(Collider targetCollider)
	{
		//Debug.Log("Shooting!");
		Transform barrelPosition = transform.Find("Turret_Barrel");
		GameObject bullet = Instantiate(bulletPrefab, barrelPosition.position, Quaternion.identity) as GameObject;
		Turret_Bullet bulletScript = bullet.GetComponent<Turret_Bullet>();
		bulletScript.Initialize(targetCollider);
		turretRefreshTimes.Enqueue(Time.time + turretDelay);
	}

	// Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.forward * turretDistance, Color.cyan, 5f);
        if (turretRefreshTimes.Count > 0)
        {
            if (turretRefreshTimes.Peek() <= Time.time)
            {
                AttackTarget(SearchForTarget());
                turretRefreshTimes.Dequeue();
            }
        }
        else
        {
            AttackTarget(SearchForTarget());
            turretRefreshTimes.Enqueue(Time.time);
            
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
        Debug.Log(targetCollider);
        if (targetCollider != null)
        {
            if (targetCollider.tag == "Enemy")
            {
                ShootBullet(targetCollider);
            }
        }
    }

	
}