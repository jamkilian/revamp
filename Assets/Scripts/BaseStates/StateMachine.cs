using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine
{
    private Agent owner;
    private IState currentState;

    public StateMachine(Agent owner)
    {
        this.owner = owner;
    }

    public void ChangeState(IState newState)
    {
        if (this.currentState != null)
        {
            this.currentState.Exit();
        }
        this.currentState = newState;
        this.currentState.Enter();
    }
}
