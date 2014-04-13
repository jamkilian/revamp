﻿using UnityEngine;
using System.Collections;


public class WeaponBomb : MonoBehaviour 
{
	private float counter = 0;
	private float counter2 = 0;
	private float rad = 5;
	private bool explode = false;
	private float attackDamage = 100f;

	public AudioClip bombSound;

	GameObject spawnedExpl;
	Object explosion;

	void Start()
	{
		explosion = Resources.Load("explosion2");
	}

	void Update () 
	{
		counter += Time.deltaTime;
		if (counter >= 1.5)
		{
			BombExplode();
		}
		if (explode == true)
		{
			counter2 += Time.deltaTime;
			Debug.Log(counter2);
			if (counter2 >= 0.09)
			{
				spawnedExpl = (GameObject)Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
				AudioSource.PlayClipAtPoint(bombSound, transform.position);
				Destroy(this.gameObject);
				Destroy(this.spawnedExpl, 1.0f);
			}
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if((other.gameObject.tag == "Enemy"))
		{
			Destroy(other.gameObject);
			BombExplode();
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(this.gameObject.transform.position, rad);
	}


	void BombExplode()
	{
		Collider[] hitTargets;
		hitTargets = Physics.OverlapSphere(this.gameObject.transform.position, rad);
		foreach (Collider hit in hitTargets)
		{
			if (hit.tag == "Enemy")
			{
				hit.SendMessage("TakeDamage",attackDamage);
			}
		}
		explode = true;
	}
}