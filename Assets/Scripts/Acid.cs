using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {

    public int maxAcid = 3;
    public float acidRefresh = 7;
    private List<float> acidRefreshTimes;

	public Vector3 ObjectSpawnPosition;
    public Object acidObject;
	public Vector3 acidOffSet;
    private float countAcid = 0;
    private float counterTime = 0;
    public bool isReady = true;


	void Start()
	{
        acidRefreshTimes = new List<float>();
    	acidOffSet = this.gameObject.transform.right * -1.5f;
        acidObject = Resources.Load("Acid");
	}

    void Update()
    {
        if (acidRefreshTimes.Count > 0)
        {
            if (acidRefreshTimes[0] <= Time.time)
                acidRefreshTimes.Remove(acidRefreshTimes[0]);
        }
    }

    public void Attack(float direction)
    {
        if (acidRefreshTimes.Count < maxAcid)
        {
            Instantiate(acidObject, this.gameObject.transform.position + 
                (direction * acidOffSet), Quaternion.identity);
            acidRefreshTimes.Add(Time.time + acidRefresh);
        }
    }
}