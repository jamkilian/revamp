using UnityEngine;
using System.Collections;

public class WeaponSword : MonoBehaviour 
{
	public AudioClip deathSound;

	// Use this for initialization
	void Start () 
    {
        
	}

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Enemy")
        {
			other.SendMessage("Destroy");
            Kills.kills++;
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
