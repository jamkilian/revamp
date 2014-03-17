using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour 
{
    public float speed = 5f;
    public float normalSpeed = 9f;
    public Vector3 target = new Vector3(3000, 0, 0);
    private float zLanePosition;
	Object flameObject;
	GameObject spawnedFlame;
    Dictionary<string, float> enemySpeeds = new Dictionary<string,float>();


	// Use this for initialization
	void Start () 
    {
        zLanePosition = DetermineLane();
        target = new Vector3(target.x, target.y, zLanePosition);
		flameObject = Resources.Load("Flame");
	}

    private float DetermineLane()
    {
        float lane = this.gameObject.transform.position.z;
        return lane;
    }

	// Update is called once per frame
	void Update () 
    {
        float step = speed * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(
            this.gameObject.transform.position, target, step);

	}

    void OnTriggerEnter()
    {

    }

	void Destroy()
	{
		spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
		Destroy(this.gameObject);
		Destroy(spawnedFlame, 3f);
	}

    void NormalSpeed()
    {
        speed = normalSpeed;
    }
}
