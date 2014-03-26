using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackState : IState
{
    protected Agent owner;
    private int counter;

    public AttackState(Agent owner)
    {
        this.owner = owner;
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
        while (counter < 10)
        {
            Debug.Log("Executing Attack State");
            counter++;
            yield return null;
        }
        this.Exit();
    }

    public void Exit()
    {
        Debug.Log("Exiting Attack State");
    }
}