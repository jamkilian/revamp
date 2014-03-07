using UnityEngine;
using System.Collections;


public class Bomb : MonoBehaviour
{
    public int maxBomb = 2;
    public int bombRefresh = 10;

    private Object bombObject;
    private Vector3 bombOffset;
    private int countBomb = 0;
    private float counterTime = 0.0f;
    [HideInInspector]
    public bool isReady = true;

    void Update () 
    {

        Debug.Log(string.Format("Total bombs: {0}", countBomb));
	    if (countBomb > 0)
        {
	        counterTime += Time.deltaTime;
	    
            if (counterTime >= bombRefresh)
            {
                if (--countBomb < 0)
                {
                    countBomb = 0;
                    counterTime = 0;
                    Debug.Log(countBomb);
                }
                else
                {
                    Debug.Log("Decremented");
                    counterTime = 0;
                }
		    }
	    }
        if (countBomb >= 2)
            isReady = false;
        else
            isReady = true;
    }

    void Start()
    {
        bombObject = Resources.Load("Bomb");
        bombOffset = this.gameObject.transform.right + new Vector3(3,0,0);
    }

    public void Attack(float direction)
    {
        if (countBomb < maxBomb)
        {
            GameObject bombInstance = (GameObject)Instantiate(bombObject, this.gameObject.transform.position + -(direction * bombOffset), transform.rotation);
            bombInstance.gameObject.rigidbody.AddForce(transform.right * -100);
            countBomb++;
        }
	    /*
            GameObject bombInstance = (GameObject)Instantiate(bombObject, transform.position, transform.rotation);
	        bombInstance.gameObject.rigidbody.AddForce(transform.right * 100);
	        countBomb += 1;
         }*/
    }
}