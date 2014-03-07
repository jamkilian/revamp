<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
=======
﻿using System.Collections;
using UnityEngine;
>>>>>>> cdffd55... Initial Commit of project

public class Acid : MonoBehaviour {

    public int maxAcid = 3;
<<<<<<< HEAD
    public float acidRefresh = 7;
    private Queue<float> acidRefreshTimes;
=======
    public int acidRefresh = 7;
>>>>>>> cdffd55... Initial Commit of project

	public Vector3 ObjectSpawnPosition;
    public Object acidObject;
	public Vector3 acidOffSet;
    private float countAcid = 0;
    private float counterTime = 0;
<<<<<<< HEAD
    [HideInInspector]
    public bool isReady;

	void Start()
	{
        acidRefreshTimes = new Queue<float>();
    	acidOffSet = this.gameObject.transform.right * -1.5f;
=======
    public bool isReady = true;


	void Start()
	{
		acidOffSet = this.gameObject.transform.right * -1.5f;
>>>>>>> cdffd55... Initial Commit of project
        acidObject = Resources.Load("Acid");
	}

    void Update()
    {
<<<<<<< HEAD
        if (acidRefreshTimes.Count > 0)
        {
            if (acidRefreshTimes.Peek() <= Time.time)
                acidRefreshTimes.Dequeue();
        }

        if (acidRefreshTimes.Count >= maxAcid)
            isReady = false;
        else
            isReady = true;
=======
        if (countAcid >= maxAcid)
        {
            counterTime += Time.deltaTime;

            if (counterTime >= acidRefresh)
            {
                if (--countAcid < 0)
                {
                    countAcid = 0;
                    counterTime = 0;
                    //Debug.Log(countAcid);
                }
                else
                {
                    //Debug.Log("Decremented");
                    counterTime = 0;
                }
            }
        }

>>>>>>> cdffd55... Initial Commit of project
    }

    public void Attack(float direction)
    {
<<<<<<< HEAD
        if (acidRefreshTimes.Count < maxAcid)
        {
            Instantiate(acidObject, this.gameObject.transform.position + 
                (direction * acidOffSet), Quaternion.identity);
            acidRefreshTimes.Enqueue(Time.time + acidRefresh);
        }
    }
=======
        if (countAcid < maxAcid)
        {
            Instantiate(acidObject, this.gameObject.transform.position + (direction * acidOffSet), Quaternion.identity);
            countAcid++;
        }
    }

>>>>>>> cdffd55... Initial Commit of project
}