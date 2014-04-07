using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour
{
    public StateMachine FSM;

    void Awake()
    {
        this.FSM = new StateMachine(this);
    }

    public IEnumerator StateWrapper(IEnumerator state)
    {
        while (state.MoveNext())
        {
            Debug.Log("I'm in " + state);
            yield return state.Current;
        }
    }
	
	public void AgentAttack(GameObject go, float damage)
    {
        this.FSM.ChangeState(new AttackState(this, go, damage));
    }

    public void AgentDestroy()
    {
        //If we want to change state we call
        this.FSM.ChangeState(new DeadState(this));
    }
}