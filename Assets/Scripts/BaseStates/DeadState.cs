using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeadState : IState
{
	protected Agent owner;
	private int counter;
	public delegate void DeadEventHandler();
	public static event DeadEventHandler OnDeath;
	

	public DeadState(Agent owner)
	{
		this.owner = owner;
	}

	public void Enter()
	{
		Debug.Log("Entering the Dead state");
		OnDeath();
		owner.StartCoroutine("StateWrapper", this.Execute());
	}

	/// <summary>
	/// While the target is in range and not dead, keep Deading
	/// </summary>
	/// <returns></returns>
	public IEnumerator Execute()
	{
		Debug.Log("Executing Dead State");
		yield return null;
		this.Exit();
	}
	public void Exit()
	{
		Debug.Log("Exiting Dead State");
	}
}