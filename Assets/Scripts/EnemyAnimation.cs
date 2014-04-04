using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
	float framecounter;
	
	public Texture2D robotWalk1;
	public Texture2D robotWalk2;
	public Texture2D robotWalk3;
	public bool iswalk =  false;
	public Texture2D robotstill;

	void Update()
	{
		if (iswalk == true)
		{
			renderer.material.mainTexture = robotstill;
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
}

