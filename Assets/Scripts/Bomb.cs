using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    public int maxBomb = 2;
    public float bombRefresh = 10;
    private Queue<float> bombRefreshTimes;

    private Object bombObject;
    private Vector3 bombOffset;
    private int countBomb = 0;
    private float counterTime = 0.0f;
    [HideInInspector]
    public bool isReady;

    void Start()
    {
        bombRefreshTimes = new Queue<float>();
        bombObject = Resources.Load("Bomb");
        bombOffset = this.gameObject.transform.right + new Vector3(3, 0, 0);
    }

    void Update () 
    {

        if (bombRefreshTimes.Count > 0)
        {
            if (bombRefreshTimes.Peek() <= Time.time)
                bombRefreshTimes.Dequeue();
        }

        if (bombRefreshTimes.Count >= maxBomb)
            isReady = false;
        else
            isReady = true;

    }

    

    public void Attack(float direction)
    {
        if (countBomb < maxBomb)
        {
            GameObject bombInstance = (GameObject)Instantiate(bombObject, this.gameObject.transform.position + -(direction * bombOffset), transform.rotation);
            bombInstance.gameObject.rigidbody.AddForce(transform.right * -100);
            bombRefreshTimes.Enqueue(Time.time + bombRefresh);
        }
    }
}