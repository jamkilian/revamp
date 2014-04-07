using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackState : IState
{
    GameObject target;
    protected Agent owner;
    private float attackDamage;
    private float attackDelay = 3.0f;
    private float attackRefresh = 0f;

    public AttackState(Agent owner, GameObject target, float attackDamage)
    {
        this.owner = owner;
        this.target = target;
        this.attackDamage = attackDamage;
    }

    public void Enter()
    {
        Debug.Log("Entering the Attack state");
        owner.StartCoroutine("StateWrapper", this.Execute());
    }

    /// <summary>
    /// While the target is in range and not dead, keep attacking
    /// </summary>
    /// <returns></returns>
    public IEnumerator Execute()
    {
        while (target)
        {
            if (attackRefresh <= Time.time)
            {
                target.SendMessage("TakeDamage", attackDamage);
                attackRefresh = Time.time + attackDelay;
            }
            yield return null;
        }
        this.Exit();
    }

    public void Exit()
    {
        Debug.Log("Exiting Attack State");
    }
}