using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float currentSpeed = 5f;
    public float normalSpeed = 5f;
    private bool keepWalking = true;
    private GameObject target;
    private Vector3 targetPosition;
    private ServerHealth sh; 
    Object flameObject;
    GameObject spawnedFlame;


    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Server");
        sh = (ServerHealth)target.GetComponent("ServerHealth");
        float zLanePosition = DetermineLane();
        targetPosition = new Vector3(target.collider.transform.position.x, target.collider.transform.position.y, zLanePosition);
        flameObject = Resources.Load("Flame");
    }

    private float DetermineLane()
    {
        float lane = this.gameObject.transform.position.z;
        return lane;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepWalking)//Hasn't collided with server colliderbox
        {
            float step = currentSpeed * Time.deltaTime;
            this.gameObject.transform.position = Vector3.MoveTowards(
                this.gameObject.transform.position, targetPosition, step);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Server")
        {
            //Debug.Log("Collided with server");
            keepWalking = false;
            EnemyAnimation walk;
            walk = this.GetComponent<EnemyAnimation>();
            walk.iswalk = true;
            sh.AddjustCurrentHealth(-10);
        }
    }

    public void TakeDamage(float damage)
    {
        if ((currentHealth -= damage) <= 0)
            this.Destroy();

    }

    public void Destroy()
    {
        spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
        Destroy(spawnedFlame, 3f);
    }

    void NormalSpeed()
    {
        currentSpeed = normalSpeed;
    }
    public void SetSpeed(float S)
    {
        currentSpeed = S;
        normalSpeed = S;
    }
}
