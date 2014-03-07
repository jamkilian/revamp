using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	float framecounter1;
	float framecounter2;
	public Texture2D playerWalk1;
	public Texture2D playerWalk2;
	public Texture2D playerStill1;
	public Texture2D playerStill2;

	void Update()
	{
			framecounter1 += Time.deltaTime;
			if ((framecounter1 >= 0) && (framecounter1 <= 0.2))
				renderer.material.mainTexture = playerWalk1;
			if ((framecounter1 >= 0.21) && (framecounter1 <= 0.4))
				renderer.material.mainTexture = playerWalk2;
			if (framecounter1 >= 0.41)
				framecounter1 = 0;
	}
}