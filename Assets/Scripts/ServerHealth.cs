using UnityEngine;
using System.Collections;

public class ServerHealth : Health
{
    public override void TakeDamage(float damage)
    {


        if ((curHealth -= damage) <= 0)
        {
            Application.LoadLevel("Credits");
            //Object.Destroy(this.gameObject);
            //Application.LoadLevel("Credits");
        }
        else if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
    public override void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
    }

}
