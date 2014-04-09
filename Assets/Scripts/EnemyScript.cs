using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : BaseDestroyable
{
    
    public float currentSpeed = 5f;
    public float normalSpeed = 5f;
    private bool keepWalking = true;
    private Vector3 targetPosition;
    private Health sh;
    private Agent agentScript;
    
    // Use this for initialization
    protected void Start()
    {
        this.BaseStart();
        target = GameObject.Find("Server");
        sh = (Health)target.GetComponent("Health");
        float zLanePosition = DetermineLane();
        targetPosition = new Vector3(target.collider.transform.position.x, target.collider.transform.position.y, zLanePosition);

        //Load in Agent script on this object, to track states
        agentScript = gameObject.GetComponent<Agent>();
    }

    protected float DetermineLane()
    {
        float lane = this.gameObject.transform.position.z;
        return lane;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (keepWalking)//Hasn't collided with server colliderbox
        {
            float step = currentSpeed * Time.deltaTime;
            this.gameObject.transform.position = Vector3.MoveTowards(
                this.gameObject.transform.position, targetPosition, step);
        }
		Debug.Log(agentScript.FSM);
    }

    protected void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enemy was entered by: " + other.gameObject.name);
        if (other.gameObject.name == "Server" || other.gameObject.name == "Turret")
        {
            keepWalking = false;
            EnemyAnimation walk;
            walk = this.GetComponent<EnemyAnimation>();
            walk.iswalk = true;
            agentScript.AgentAttack(other.gameObject, attackDamage);
        }
    }

    
	
    void ContinueWalking()
    {
        keepWalking = true;
        EnemyAnimation walk;
        walk = this.GetComponent<EnemyAnimation>();
	walk.iswalk = false;
    }

    protected void NormalSpeed()
    {
        currentSpeed = normalSpeed;
    }
    public void SetSpeed(float S)
    {
        currentSpeed = S;
        normalSpeed = S;
    }

    public void Destroy()
    {
        this.agentScript.AgentDestroy();
        spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
        Destroy(spawnedFlame, 3f);
    }
}
