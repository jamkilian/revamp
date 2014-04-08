using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
	float framecounter;
	int maxFrames = 3;
	public Texture2D robotWalk1;
	public Texture2D robotWalk2;
	public Texture2D robotWalk3;
	public bool iswalk =  false;
	public Texture2D robotStill;

	void Update()
	{
		if (iswalk == true)
		{
			renderer.material.mainTexture = robotStill;
		}
		else{
			framecounter += Time.deltaTime;
			if ((framecounter >= 0) && (framecounter <= 0.2))
			{
				renderer.material.mainTexture = robotWalk1;
			}
			if ((framecounter >= 0.21) && (framecounter <= 0.4))
			{
				renderer.material.mainTexture = robotWalk2;
			}
			if ((framecounter >= 0.41) && (framecounter <= 0.6))
			{
				renderer.material.mainTexture = robotWalk3;
			}
			if (framecounter > 0.61)
			{
				framecounter = 0;
			}
		}
	}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="basePath">Should be in the form "Boss/Lane/Boss-robot" e.g. "Boss/Middle/Boss-robot"</param>
    public void EnableWalking(string basePath)
    {
        //This works since we just want the second frame, which is arms down
        robotStill = Resources.Load<Texture2D>(basePath + "2");
        robotWalk1 = Resources.Load<Texture2D>(basePath + "1");
        robotWalk2 = Resources.Load<Texture2D>(basePath + "2");
        robotWalk3 = Resources.Load<Texture2D>(basePath + "3");
    }
}

