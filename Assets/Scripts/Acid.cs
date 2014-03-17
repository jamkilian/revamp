using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Acid : MonoBehaviour {

	public int maxAcid = 3;
	public float acidRefresh = 7;
	private Queue<float> acidRefreshTimes;

	public Vector3 ObjectSpawnPosition;
	public Object acidObject;
	public Vector3 acidOffSet;
<<<<<<< HEAD
	[HideInInspector]
	public bool isReady;

	void Start()
	{
		acidRefreshTimes = new Queue<float>();
		acidOffSet = this.gameObject.transform.right * -1.5f;
		acidObject = Resources.Load("Acid");
=======
    private float countAcid = 0;
    private float counterTime = 0;

    [HideInInspector]
    public bool isReady;

	void Start()
	{
        acidRefreshTimes = new Queue<float>();
    	acidOffSet = this.gameObject.transform.right * -1.5f;

        acidObject = Resources.Load("Acid");
>>>>>>> master
	}

	void Update()
	{
		if (acidRefreshTimes.Count > 0)
		{
			if (acidRefreshTimes.Peek() <= Time.time)
				acidRefreshTimes.Dequeue();
		}

<<<<<<< HEAD
		if (acidRefreshTimes.Count >= maxAcid)
			isReady = false;
		else
			isReady = true;
	}
=======
        if (acidRefreshTimes.Count >= maxAcid)
            isReady = false;
        else
            isReady = true;

    }
>>>>>>> master

	public void Attack(float direction)
	{
		if (acidRefreshTimes.Count < maxAcid)
		{
			Instantiate(acidObject, this.gameObject.transform.position + 
				(direction * acidOffSet), Quaternion.identity);
			acidRefreshTimes.Enqueue(Time.time + acidRefresh);
		}
	}
}