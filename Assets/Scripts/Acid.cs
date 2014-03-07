using System.Collections;
using UnityEngine;

public class Acid : MonoBehaviour {

    public int maxAcid = 3;
    public int acidRefresh = 7;

	public Vector3 ObjectSpawnPosition;
    public Object acidObject;
	public Vector3 acidOffSet;
    private float countAcid = 0;
    private float counterTime = 0;
    public bool isReady = true;


	void Start()
	{
		acidOffSet = this.gameObject.transform.right * -1.5f;
        acidObject = Resources.Load("Acid");
	}

    void Update()
    {
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

    }

    public void Attack(float direction)
    {
        if (countAcid < maxAcid)
        {
            Instantiate(acidObject, this.gameObject.transform.position + (direction * acidOffSet), Quaternion.identity);
            countAcid++;
        }
    }

}