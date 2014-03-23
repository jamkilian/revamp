using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    private GameObject target;
    public float xOffset = 0;
    public float yOffset = 12.6f;
    public float zOffset = 0;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	public void Update() {
        this.gameObject.transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
    }

    public void UpdateCamera()
    {
        this.gameObject.transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
    }
	
	public string TurdFergesson() {
		return "It's a funny name.";
	}
}
