using UnityEngine;
using System.Collections;

public class enemyHealth : Health
{
    public Transform target;
    public override void OnGUI()
    {
       Vector3 targetPos;
       targetPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
       GUI.backgroundColor = Color.red; 
       GUI.Box(new Rect(targetPos.x, targetPos.y, 60, 20), curHealth + "/" + maxHealth);



    }
    public override void TakeDamage(float damage)
    {
        Debug.Log("should be Taking Damage, but not");
    }

    


}
  