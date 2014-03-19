using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour 
{
    private float distance = 10f;
    private TrailRenderer swordTrail;
    private Object swordObject;
    private GameObject swordGO;
    private Vector3 swordOffset = new Vector3(0f, 0, 2.3f);
    public bool isReady = true;

    //Transforms for Lerp
    private Vector3 startPos;
    private Vector3 endPos;
    public Quaternion startForwardRot;
    public Quaternion startBackwardRot;
    private float speed = 20f;
    private float startTime;
    private float swordLength;
    private float timer = 0.0f;
    private float lastDistance;
    [HideInInspector]
    public bool isAttacking = false;
    [HideInInspector]

    // Use this for initialization
	void Start ()
    {
        LoadSword();
        swordGO.collider.isTrigger = true;
    }

    private float DetectForward()
    {
        return this.gameObject.transform.forward.z;
    }
	
	public void StartRotation(int direction)
	{
		if (direction == 1)//Forward
		{
			swordGO.transform.rotation = startForwardRot;
		}
		else if (direction == 0) //Backward
		{
			swordGO.transform.rotation = startBackwardRot;
		}
	}

    public void Attack()
    {
        startTime = Time.time;
        SwordOn();
		isAttacking = true;
		if (DetectForward() == -1)
			swordGO.transform.rotation = startBackwardRot;
		else
			swordGO.transform.rotation = startForwardRot;			
    }

    private void LoadSword()
    {
        swordObject = Resources.Load("Sword");
        swordGO = (GameObject)Instantiate(swordObject, this.gameObject.transform.position + swordOffset, new Quaternion(0, 180, 180, 0));
        swordGO.transform.parent = this.gameObject.transform;
        startForwardRot = swordGO.transform.rotation;
        startBackwardRot = new Quaternion(90f,0,0,90f);
        Debug.Log(startForwardRot + " " + startBackwardRot);

        //Get Trail Renderer
        swordTrail = swordGO.gameObject.GetComponent<TrailRenderer>();
        SwordOff();
    }

    private void SwordOff()
    {
        swordGO.renderer.enabled = false;
        swordGO.collider.enabled = false;
        swordTrail.enabled = false;
    }

    private void SwordOn()
    {
        swordGO.renderer.enabled = true;
        swordGO.collider.enabled = true;
        swordTrail.enabled = true;
    }

	// Update is called once per frame
	void Update ()
    {
        if (isAttacking)
        {
            if (DetectForward() == -1)
            {
                startPos = this.gameObject.transform.position + new Vector3(swordOffset.x, swordOffset.y, -(swordOffset.z));
                endPos = startPos + new Vector3(swordOffset.z + 1f, 0f, swordOffset.z + 1f);
            }
            else
            {
                startPos = this.gameObject.transform.position + swordOffset;
                endPos = startPos + new Vector3(-(swordOffset.z) - 1f, 0f, -(swordOffset.z) - 1f);
            }
            swordLength = Vector3.Distance(startPos, endPos);
            isReady = false;
			Debug.Log(swordGO.transform.rotation);
            MoveSword();
        }
	}

    void MoveSword()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracDistance = distCovered / swordLength;
        swordGO.transform.position = Vector3.Lerp(startPos, endPos, fracDistance);
        swordGO.transform.Rotate(0, 0, CalcRotation(fracDistance, lastDistance));
        lastDistance = fracDistance;
        if (swordGO.transform.position == endPos)
        {
            isAttacking = false;
            swordGO.transform.position = startPos;
            lastDistance = 0;
            isReady = true;
            SwordOff();
        }
    }

    /// <summary>
    /// To keep rotation equivilent to the distance traveled. For every 10% of the distance,
    /// -8 on the z gives the right look
    /// </summary>
    /// <param name="newDistance">Just calculated distance</param>
    /// <param name="oldDistance">Last distance</param>
    /// <returns></returns>
    private float CalcRotation(float newDistance, float oldDistance)
    {
        float newRotation;
        if (DetectForward() == 1)
            newRotation = (newDistance - oldDistance) * -105f;
        else 
            newRotation = (newDistance - oldDistance) * 105f;
        //Debug.Log(string.Format("new: {0}   old: {1}   Rot: {2}", newDistance, oldDistance, newRotation));
        return newRotation;
    }

   
}
