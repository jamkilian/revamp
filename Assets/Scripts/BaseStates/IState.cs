using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IState
{
    void Enter();
    System.Collections.IEnumerator Execute();
    void Exit();
}

