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
            yield return state.Current;
        }
    }

    void Destroy()
    {
        //If we want to change state we call
        this.FSM.ChangeState(new DeadState(this));
    }
}