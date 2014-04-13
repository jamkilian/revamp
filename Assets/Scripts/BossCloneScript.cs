using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossCloneScript : BossEnemyScript
{
    private BossEnemyScript parentScript;
    private float powerToGive = 10f;
    private float parentLaneZ;
    
    private void Instantiate(float parentLaneZ)
    {
        this.parentLaneZ = parentLaneZ;
        GameObject parent = GameObject.Find("BossEnemy(Clone)");
        parentScript = parent.GetComponent<BossEnemyScript>();
        ColorBossForLane(parentLaneZ);
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
        }
    }

    private void TakeDamage(float damage)
    {
        SendParentPower();
        Debug.Log("I'm giving the parent power!");
    }

    private void SendParentPower()
    {
        parentScript.GainPower(powerToGive);
    }

    protected override void Destroy()
    {
        spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
        Destroy(spawnedFlame, 3f);
    }
}