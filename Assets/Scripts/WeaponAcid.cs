using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponAcid : MonoBehaviour 
{
	private float counter = 0;
	public float slow = 2f;
    private EnemyScript enemy;
    private List<Collider> slowedEnemies;

    void Start()
    {
        slowedEnemies = new List<Collider>();
    }

	void Update()
	{
		counter += Time.deltaTime;
		if(counter >=5)
		{
            DestroyingAcid();
		}

	}

    void DestroyingAcid()
    {
        foreach (Collider other in slowedEnemies)
        {
            if (other)
                other.SendMessage("NormalSpeed");
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(string.Format("WeaponAcid: OnTriggerEnter: {0}", other));
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.GetComponent<EnemyScript>();
            enemy.speed = slow;
            slowedEnemies.Add(other);
        }
    }

	void OnTriggerExit(Collider other)
	{
        //Debug.Log(string.Format("WeaponAcid: OnTriggerExit: {0}", other));
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("NormalSpeed");
        }
	}
}
