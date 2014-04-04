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
    private Dictionary<float, Object> laneColors;
    private float zLanePosition;

    void Awake()
    {
        //Set Speed
        currentSpeed = 2f;
        normalSpeed = 2f;

        //Set Health
        currentHealth = 1000f;
        maxHealth = 1000f;

        //Sort LaneColors
        laneColors = new Dictionary<float, Object>();
        laneColors.Add(possibleLanes[0], Resources.Load("Boss/TopMost/Boss-robot1"));
        laneColors.Add(possibleLanes[1], Resources.Load("Boss/Top/Boss-robot1"));
        laneColors.Add(possibleLanes[2], Resources.Load("Boss/Middle/Boss-robot1"));
        laneColors.Add(possibleLanes[3], Resources.Load("Boss/Bottom/Boss-robot1"));
        laneColors.Add(possibleLanes[4], Resources.Load("Boss/BottomMost/Boss-robot1"));
        this.zLanePosition = DetermineLane();
        ColorBossForLane(zLanePosition);

        //Load in Duplicates

    }

    void ColorBossForLane(float z)
    {
        this.gameObject.renderer.material.SetTexture("_MainTex", (Texture2D)laneColors[z]);
    }

    //BossEnemy inherits Enemy to keep it stream lined.
    //Appears in all lanes functionality
    //Damage to phantom gives damage boost to boss    void CreateDecoys()
    {
        foreach (float z in possibleLanes)
        {
            if (this.transform.position.z != z)
            {
                
            }
        }

    }
}
    