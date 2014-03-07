using UnityEngine;
using System.Collections;

public class IncrementScore : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log ("Killed Enemy");
			Kills.kills++;
		}

	}
}