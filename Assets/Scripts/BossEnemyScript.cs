using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossEnemyScript : EnemyScript
{
    protected List<float> laneList;
    protected float[] possibleLanes = {   21,
                                        14,
                                        7,
                                        0,
                                        -7  };
    protected Dictionary<float, string> laneColors;
    protected GameObject[] clones;
    protected float zLanePosition;
    private Object cloneResource;

    protected void Awake()
    {
        cloneResource = Resources.Load("BossClone");
        //Set Speed
        currentSpeed = 2f;
        normalSpeed = 2f;

        //Set Health
        currentHealth = 1000f;
        maxHealth = 1000f;

        //Sort LaneColors
        laneColors = new Dictionary<float, string>();
        laneColors.Add(possibleLanes[0], "Boss/TopMost/Boss-robot");
        laneColors.Add(possibleLanes[1], "Boss/Top/Boss-robot");
        laneColors.Add(possibleLanes[2], "Boss/Middle/Boss-robot");
        laneColors.Add(possibleLanes[3], "Boss/Bottom/Boss-robot");
        laneColors.Add(possibleLanes[4], "Boss/BottomMost/Boss-robot");

        this.zLanePosition = DetermineLane();
        ColorBossForLane(zLanePosition);
        clones = new GameObject[possibleLanes.Length - 1];

        //Load in Duplicates
        if (this.gameObject.name == "BossEnemy(Clone)")
        {
            CreateDecoys();
        }
    }

    protected void ColorBossForLane(float z)
    {
        EnemyAnimation myAnimator = gameObject.GetComponent<EnemyAnimation>();
        myAnimator.EnableWalking(laneColors[z]);
    }

    //BossEnemy inherits Enemy to keep it stream lined.
    //Appears in all lanes functionality
    //Damage to phantom gives damage boost to boss

    private void CreateDecoys()
    {
        //cloneIndex, only to have the array in an a sane fashion. Didn't want to make a big dict for no reason
        int cloneIndex = 0;
        foreach (float currentZ in possibleLanes)
        {
            if (currentZ != zLanePosition)
            {
                clones[cloneIndex] = Instantiate(cloneResource, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, currentZ), Quaternion.identity) as GameObject;
                clones[cloneIndex].SendMessage("Instantiate", zLanePosition);
                cloneIndex++;
            }
        }
    }

    public void GainPower(float powerGained)
    {
        this.attackDamage += powerGained;
    }

    protected virtual void AdditionalDestroy()
    {
        foreach (GameObject clone in clones)
        {
            Debug.Log(clone);
            clone.SendMessage("Destroy");
        }
    }

    //We need destroy defined again due to the clone destroy logic
    protected override void Destroy()
    {
        this.agentScript.AgentDestroy();
        spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        AdditionalDestroy();
        Destroy(this.gameObject);
        Destroy(spawnedFlame, 3f);
    }

}
