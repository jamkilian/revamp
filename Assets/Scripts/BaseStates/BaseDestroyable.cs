using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseDestroyable : MonoBehaviour
{
    public float attackDamage = 15f;
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    protected GameObject target;
    protected Object flameObject;
    protected GameObject spawnedFlame;

    public void BaseStart()
    {
        flameObject = Resources.Load("Flame");
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(this.name + " is Taking damage! " + damage);
        if ((currentHealth -= damage) <= 0)
            this.Destroy();
    }

    public void Destroy()
    {
        spawnedFlame = (GameObject)Instantiate(flameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
        Destroy(spawnedFlame, 3f);
    }


}