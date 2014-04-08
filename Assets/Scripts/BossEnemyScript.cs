using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossEnemyScript : EnemyScript
{
    private List<float> laneList;
    private float[] possibleLanes = {   21,
                                        14,
                                        7,
                                        0,
                                        -7  };
    private Dictionary<float, string> laneColors;
    private GameObject[] clones;
    private float zLanePosition;
    private Object cloneResource;

    void Awake()
    {
        //Set Speed
        currentSpeed = 2f;
        normalSpeed = 2f;

        //Set Health
        currentHealth = 1000f;
        maxHealth = 1000f;

        //Sort LaneColors
        laneColors = new Dictionary<float, string>();
        laneColors.Add(possibleLanes[0],"Boss/TopMost/Boss-robot");
        laneColors.Add(possibleLanes[1], "Boss/Top/Boss-robot");
        laneColors.Add(possibleLanes[2],"Boss/Middle/Boss-robot");
        laneColors.Add(possibleLanes[3], "Boss/Bottom/Boss-robot");
        laneColors.Add(possibleLanes[4], "Boss/BottomMost/Boss-robot");
        
        this.zLanePosition = DetermineLane();
        ColorBossForLane(zLanePosition);

        //Load in Duplicates
        CreateDecoys();
        

    }

    void ColorBossForLane(float z)
    {
        EnemyAnimation myAnimator = gameObject.GetComponent<EnemyAnimation>();
        myAnimator.EnableWalking(laneColors[z]);
    }

    //BossEnemy inherits Enemy to keep it stream lined.
    //Appears in all lanes functionality
    //Damage to phantom gives damage boost to boss

    void CreateDecoys()
    {
        Object prefab = Resources.Load("BossEnemy");
        float currentZ = 14;
        Debug.Log(transform.position.z);
        GameObject tits = Instantiate(prefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, currentZ), Quaternion.identity) as GameObject;
        Debug.Log(tits);
        if (currentZ != this.gameObject.transform.position.z)
        {
        }
    }

}
    