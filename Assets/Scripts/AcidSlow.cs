using UnityEngine;
using System.Collections;

public class AcidSlow : MonoBehaviour 
{
	private float counter = 0;
	public float slow = 2f;
	//bool fast = false;
	void Update()
	{
		counter += Time.deltaTime;
		if(counter >=5)
		{
			//fast = true;
			Destroy (this.gameObject);

		}

	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log("trigger");
		if(other.gameObject.tag == "Enemy")
		{
			Debug.Log (other);
			EnemyScript enemy;
			enemy = other.GetComponent<EnemyScript>();
			Debug.Log (enemy);
			enemy.currentSpeed = slow;
			Debug.Log("Acid");

			/*if (fast == true)
			{
				//enemy = other.GetComponent<EnemyScript>();
				Debug.Log ("enemyfast");
				enemy.speed = 5f;

			}*/
		}
		
	}
}
