using UnityEngine;
using System.Collections;

public class EnemyHealthGUI : Health
{
    public Transform target;
    private EnemyScript es;

    private void Awake()
    {
        es = this.gameObject.GetComponent<EnemyScript>();
    }
    public override void OnGUI()
    {
       Vector3 targetPos;
       targetPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
       GUI.backgroundColor = Color.red; 
       GUI.Box(new Rect(targetPos.x, targetPos.y, 60, 20), es.currentHealth + "/" + es.maxHealth);



    }
    public override void TakeDamage(float damage)
    {
        Debug.Log("should be Taking Damage, but not");
    }

    


}
  