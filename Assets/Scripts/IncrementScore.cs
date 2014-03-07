using UnityEngine;
using System.Collections;

public class IncrementScore : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
<<<<<<< HEAD
			//Debug.Log ("Killed Enemy");
=======
			Debug.Log ("Killed Enemy");
>>>>>>> cdffd55... Initial Commit of project
			Kills.kills++;
		}

	}
}